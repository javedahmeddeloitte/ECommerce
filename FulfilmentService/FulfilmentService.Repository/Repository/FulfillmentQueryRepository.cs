using Dapper;
using FulfilmentService.Repository.DBModels;
using FulfilmentService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FulfilmentService.Repository.Repository
{
    public class FulfillmentQueryRepository : IFulfillmentQueryRepository
    {
        private readonly IDbConnectionFactory _db;

        public FulfillmentQueryRepository(IDbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<Fulfillment?> GetByOrderId(Guid orderId)
        {
            using var conn = _db.CreateConnection();

            return  await conn.QueryFirstOrDefaultAsync<Fulfillment>(
                "SELECT * FROM Fulfillments WHERE OrderId=@orderId",
                new { orderId });
        }
    }

}
