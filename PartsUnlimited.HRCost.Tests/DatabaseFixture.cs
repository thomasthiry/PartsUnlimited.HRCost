using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace PartsUnlimited.HRCost.Tests;

public class DatabaseFixture : IDisposable
{
    private Database _database;

    public DatabaseFixture()
    {
        _database = new Database("Server=localhost;Database=master;User Id=sa;Password=Evolve11!;", "HRCosts");
        
        _database.Create().GetAwaiter().GetResult();

        var initializeScript = File.ReadAllText(@"..\..\..\..\database\Initialize.sql");
        _database.Execute(initializeScript).GetAwaiter().GetResult();
    }
    
    public void Dispose()
    {
        _database.Drop().GetAwaiter().GetResult();
    }
}

public class Database
{
    private readonly string _databaseName;
    public string ConnectionString { get; }

    public Database(string connectionString, string databaseName)
    {
        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        
        _databaseName = $"{databaseName}_{timestamp}";
        ConnectionString = connectionString;
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
        await using var connection = new SqlConnection(ConnectionString);
        
        await connection.OpenAsync();

        var numberOfRowasAffected = await connection.ExecuteAsync(script);
    }

    public async Task Drop()
    {
        await ExecuteWithoutUsing($"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
        await ExecuteWithoutUsing($"DROP DATABASE [{_databaseName}]");
    }
}