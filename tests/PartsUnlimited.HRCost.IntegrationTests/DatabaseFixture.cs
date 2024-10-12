namespace PartsUnlimited.HRCost.IntegrationTests;

public class DatabaseFixture : IDisposable
{
    private Database _database;

    public DatabaseFixture()
    {
        _database = new Database("Server=localhost;Database=master;User Id=sa;Password=Evolve11!;", "HRCosts");
        
        _database.Create().GetAwaiter().GetResult();

        var initializeScript = File.ReadAllText(@"..\..\..\..\..\database\Initialize.sql");
        _database.Execute(initializeScript).GetAwaiter().GetResult();
    }
    
    public void Dispose()
    {
        _database.Drop().GetAwaiter().GetResult();
    }
}