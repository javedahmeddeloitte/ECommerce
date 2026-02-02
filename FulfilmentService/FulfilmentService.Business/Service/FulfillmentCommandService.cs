using FulfilmentService.Business.Interface;
using FulfilmentService.CQRS.Command;
using FulfilmentService.Model;
using FulfilmentService.Repository.DBModels;
using FulfilmentService.Repository.Interface;
using FulfilmentService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace FulfilmentService.Business.Service
{
    internal class FulfillmentCommandService : IFulfillmentCommandService
    {
        private readonly IFulfillmentCommandRepository _fulfillmentCommandRepository;
        private readonly IFulfillmentQueryRepository _fulfillmentQueryRepository;
        private static readonly object _lock = new();

        public FulfillmentCommandService(IFulfillmentCommandRepository fulfillmentCommandRepository, IFulfillmentQueryRepository fulfillmentQueryRepository)
        {
            _fulfillmentCommandRepository = fulfillmentCommandRepository;
            _fulfillmentQueryRepository = fulfillmentQueryRepository;
        }
        public async Task<Fulfillment> OrderFulfilmentAsync(OrderFulfillmentCommand cmd)
        {

            var result = await _fulfillmentQueryRepository.GetByOrderId(cmd.orderId);
            if (result != null) return result;
            
                var obj = new Fulfillment();
            obj.UpdatedAt = DateTime.Now;
            obj.CreatedAt = DateTime.Now;
            obj.Id = Guid.NewGuid();
            obj.OrderId =  cmd.orderId;
            obj.TrackingNumber = Guid.NewGuid().ToString();
            var orderDetails = await GetOrderByOrderId(cmd.orderId);
            obj.UserId = Guid.Parse(orderDetails.UserId);
            await _fulfillmentCommandRepository.AddAsync(obj);
            if (orderDetails != null) {
                var reserved = await RequestCatalogUpdate(orderDetails.Items);
                obj.Status = reserved.IsSuccess == true ? OrderUpdate.Shipped.ToString() : OrderUpdate.Failed.ToString();
                await _fulfillmentCommandRepository.UpdateStatusAsync(obj.Id, obj.Status);
            }
            return obj;
        }

        private async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            var url = $"https://localhost:44317/api/orders/OrderByOrderId/{orderId}";

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"HTTP {(int)response.StatusCode} {response.ReasonPhrase}: {body}");

            var order = await response.Content.ReadFromJsonAsync<Order>();
            return order;
        }

        private async Task<StockUpdateResponseModel> RequestCatalogUpdate(List<OrderItem> items)
        {
                using var http = new HttpClient();
                var url = "https://localhost:44300/api/catalog/reserveStock";
                var response = await http.PostAsJsonAsync(url, items);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                    var result = JsonSerializer.Deserialize<StockUpdateResponseModel>(
                            responseBody,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }

                var body = await response.Content.ReadAsStringAsync();
                var obje = new StockUpdateResponseModel();
                obje.Message = body; obje.IsSuccess = false;
                return obje;    
        }
    }
}
