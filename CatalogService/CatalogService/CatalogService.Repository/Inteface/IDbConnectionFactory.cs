using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CatalogService.Repository.Inteface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();

    }
}
