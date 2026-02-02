using FulfilmentService.CQRS.Command;
using FulfilmentService.Model;
using FulfilmentService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Business.Interface
{
    public interface IFulfillmentCommandService
    {
        Task<Fulfillment> OrderFulfilmentAsync(OrderFulfillmentCommand cmd);
    }
}
