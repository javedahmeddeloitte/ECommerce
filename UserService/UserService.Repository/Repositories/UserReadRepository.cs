using Dapper;
using Microsoft.Data.SqlClient;
using UserService.Model.Models;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly IDbConnectionFactory _connection;

        public UserReadRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            using var conn = _connection.CreateConnection();


            //var cs = "Server=localhost\\MSSQLSERVER01;Database=Users;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            var cs = "Server=localhost\\MSSQLSERVER01;Database=Users;Trusted_Connection=True;TrustServerCertificate=True;";
            //await using var conn = new SqlConnection(cs);
            //await conn.OpenAsync(); // will authenticate as the running Windows user


            //var who = await conn.QuerySingleAsync<string>("SELECT SUSER_SNAME();");
            //var rese = conn.QuerySingleAsync<string>("select DB_NAME()");

            var res =  await conn.QueryAsync<UserEntity>("select * from [dbo].[User]");
            return res;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid id, string email)
        {
            using var conn = _connection.CreateConnection();
            if (id != Guid.Empty)
                return await conn.QueryFirstOrDefaultAsync<UserEntity>(
                    "SELECT * FROM [dbo].[User] WHERE Id = @Id ", new { Id = id });
            return await conn.QueryFirstOrDefaultAsync<UserEntity>(
                    "SELECT * FROM [dbo].[User] WHERE Email = @email ", new { Email = email });
        }
    }
}
