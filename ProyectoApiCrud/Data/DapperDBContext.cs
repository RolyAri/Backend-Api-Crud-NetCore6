using System.Data;
using System.Data.SqlClient;

namespace ProyectoApiCrud.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(this._connectionString);
    }
}
