using FulfilmentService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Repository.Interface
{
    public interface IFulfillmentQueryRepository
    {
        Task<Fulfillment?> GetByOrderId(Guid orderId);
    }

}
