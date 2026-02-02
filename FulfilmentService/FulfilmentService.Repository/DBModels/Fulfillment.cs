using System;
using System.Collections.Generic;

namespace FulfilmentService.Repository.DBModels;

public partial class Fulfillment
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid UserId { get; set; }

    public string Status { get; set; } = null!;

    public string? TrackingNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}


