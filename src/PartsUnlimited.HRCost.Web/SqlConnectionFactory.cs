using System.Data;
using System.Data.SqlClient;
using PartsUnlimited.HRCost.Infrastructure;

namespace PartsUnlimited.HRCost.Web;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Create()
    {
        return new SqlConnection(_connectionString);
    }
}