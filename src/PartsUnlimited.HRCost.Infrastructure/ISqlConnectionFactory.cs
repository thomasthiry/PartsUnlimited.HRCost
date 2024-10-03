using System.Data;

namespace PartsUnlimited.HRCost.Infrastructure;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}