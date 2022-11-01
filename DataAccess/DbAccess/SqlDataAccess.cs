using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess
    {
        public IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameter)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameter);
                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameter)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameter);
            }
        }
    }
}
