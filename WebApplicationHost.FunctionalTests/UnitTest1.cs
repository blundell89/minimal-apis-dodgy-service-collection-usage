using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApplicationHost.FunctionalTests;

public class UnitTest1
{
    private readonly Harness _harness = new();
    
    [Fact]
    public async Task Test()
    {
        var client = _harness.CreateDefaultClient();

        var response = await client.GetStringAsync("hello");
        
        Assert.Equal("Hello", response);
    }
}

public class Harness : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        Program.Configure = AddServices;
        
        return base.CreateHost(builder);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IConnectionStringProvider, StubConnectionStringProvider>();
    }
}


public class StubConnectionStringProvider : IConnectionStringProvider
{
    public string Get()
    {
        return "lols it works";
    }
}