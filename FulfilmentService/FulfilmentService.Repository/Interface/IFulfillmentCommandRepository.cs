using FulfilmentService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Repository.Interface
{
    public interface IFulfillmentCommandRepository
    {
        Task AddAsync(Fulfillment fulfillment);
        Task UpdateStatusAsync(Guid id, string status);
    }

}
