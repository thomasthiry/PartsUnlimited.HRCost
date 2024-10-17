using System.Data.SqlClient;
using Dapper;

namespace PartsUnlimited.HRCost.IntegrationTests;

public class Database
{
    private readonly string _databaseName;
    public string ConnectionStringMaster { get; }
    public string ConnectionString => ConnectionStringMaster.Replace("=master", $"={_databaseName}");

    public Database(string connectionStringMaster, string databaseName)
    {
        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var randomId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        
        _databaseName = $"{databaseName}_{timestamp}_{randomId}";
        ConnectionStringMaster = connectionStringMaster;
    }

    public Task Create()
    {
        return ExecuteWithoutUsing($@"CREATE DATABASE {_databaseName};");
    }

    public async Task Execute(string script)
    {
        var scriptUsingDb = $"USE {_databaseName};\n {script}";
        await ExecuteWithoutUsing(scriptUsingDb);
    }
    
    private async Task ExecuteWithoutUsing(string script)
    {
        await using var connection = new SqlConnection(ConnectionStringMaster);
        
        await connection.OpenAsync();

        var numberOfRowasAffected = await connection.ExecuteAsync(script);
    }

    public async Task Drop()
    {
        await ExecuteWithoutUsing($"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
        await ExecuteWithoutUsing($"DROP DATABASE [{_databaseName}]");
    }
}