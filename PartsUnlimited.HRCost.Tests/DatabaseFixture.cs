using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace PartsUnlimited.HRCost.Tests;

public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        var database = new Database("Server=localhost;Database=master;User Id=sa;Password=Evolve11!;", "HRCosts");
        
        database.Create().GetAwaiter().GetResult();

        var initializeScript = File.ReadAllText(@"..\..\..\..\database\Initialize.sql");
        database.Execute(initializeScript).GetAwaiter().GetResult();
    }
    public void Dispose()
    {
        
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
        return Execute(ConnectionString, $@"CREATE DATABASE {_databaseName};");
    }

    public async Task Execute(string script)
    {
        var scriptUsingDb = $"USE {_databaseName};\n {script}";
        await Execute(ConnectionString, scriptUsingDb);
    }
    
    private async Task Execute(string connectionString, string script)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            var numberOfRowasAffected = await connection.ExecuteAsync(script);
        }
    }
}