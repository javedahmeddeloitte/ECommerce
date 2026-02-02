using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UserService.Repository.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();

    }
}
