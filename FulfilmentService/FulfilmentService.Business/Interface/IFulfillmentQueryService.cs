using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Business.Interface
{
    public interface IFulfillmentQueryService
    {
        Task<bool> IsOrderExist(Guid Id);
    }
}
