using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PartsUnlimited.HRCost.Web;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCostTests
{
    [Fact]
    public async Task Yearly_cost_is_12_times_monthly_gross_salary()
    {
        var context = AppBuilder.AnApp().Build();
        
        // useful to test aspnet configuration
        var response = await context.Client.GetAsync("/WeatherForecast/Brussels");
    }
}

public class AppBuilder
{
    public static AppBuilder AnApp()
    {
        return new AppBuilder();
    }

    public TestingAppContext Build()
    {
        var factory = new WebApplicationFactoryOverridingDependencies();
        // var factory = new WebApplicationFactoryOverridingDependencies(services =>
        //     services.AddTransient<ITemperatures>(_ =>
        //     {
        //         return _temperaturesMock;
        //     }));
        return new TestingAppContext
        {
            Client = factory.CreateClient()
        };
    }
}

public class TestingAppContext
{
    public HttpClient Client { get; set; }
}

public class WebApplicationFactoryOverridingDependencies : WebApplicationFactory<Program>
{
    private readonly Action<IServiceCollection>? _overrideDependencies;

    public WebApplicationFactoryOverridingDependencies(Action<IServiceCollection>? overrideDependencies = null)
    {
        _overrideDependencies = overrideDependencies;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => _overrideDependencies?.Invoke(services));
    }
}