using FulfilmentService.Model;
using FulfilmentService.Repository.DBModels;
using FulfilmentService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Repository.Repository
{
    public class FulfillmentCommandRepository : IFulfillmentCommandRepository
    {
        private readonly FulfilmentDbContext _db;

        public FulfillmentCommandRepository(FulfilmentDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Fulfillment fulfillment)
        {
            fulfillment.Status = OrderUpdate.Pending.ToString();
            _db.Fulfillments.Add(fulfillment);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(Guid id, string status)
        {
            var f = await _db.Fulfillments.FindAsync(id);
            f.Status = status;
            f.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }

}
