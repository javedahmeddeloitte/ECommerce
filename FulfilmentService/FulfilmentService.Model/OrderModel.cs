using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FulfilmentService.Model
{
    public class Order
    {

        public string OrderId { get; set; }
        public string UserId { get; set; } = default!;
        public List<OrderItem> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "CREATED";
    }
    public class OrderItem
    {
        public string ProductId { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
