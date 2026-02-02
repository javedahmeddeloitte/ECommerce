using FulfilmentService.Business.Interface;
using FulfilmentService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Business.Service
{
    internal class FulfillmentQueryService : IFulfillmentQueryService
    {
        private readonly IFulfillmentQueryRepository _fulfillmentQueryRepository;
        public FulfillmentQueryService(IFulfillmentQueryRepository fulfillmentQueryRepository)
        {
            _fulfillmentQueryRepository = fulfillmentQueryRepository;
        }
        public async Task<bool> IsOrderExist(Guid Id)
        {
            var result =  await _fulfillmentQueryRepository.GetByOrderId(Id);
            return result != null;
        }
    }
}
