using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FulfilmentService.Repository.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();

    }
}
