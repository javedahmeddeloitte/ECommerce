using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _config;

        public DbConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString =  new SqlConnection(
                _config.GetConnectionString("DBConnection"));
            return connectionString;
        }
    }
}
    