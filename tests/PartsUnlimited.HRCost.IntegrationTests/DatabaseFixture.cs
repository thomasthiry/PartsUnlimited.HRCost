namespace PartsUnlimited.HRCost.IntegrationTests;

public class DatabaseFixture : IDisposable
{
    private readonly Database _database;
    private const string ConnectionStringMaster = "Server=localhost;Database=master;User Id=sa;Password=Evolve11!;";
    public string ConnectionString => _database.ConnectionString;

    public DatabaseFixture()
    {
        _database = new Database(ConnectionStringMaster, "HRCosts");
        
        _database.Create().GetAwaiter().GetResult();

        var initializeScript = File.ReadAllText(@"..\..\..\..\..\database\Initialize.sql");
        _database.Execute(initializeScript).GetAwaiter().GetResult();
    }
    
    public void Dispose()
    {
        _database.Drop().GetAwaiter().GetResult();
    }
}