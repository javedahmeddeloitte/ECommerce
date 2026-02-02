using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Model
{
    public class FulfillmentModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; } = "Pending";
        public string? TrackingNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
