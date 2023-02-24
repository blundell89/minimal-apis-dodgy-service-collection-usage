using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

Configure?.Invoke(builder.Services);

builder.Services.TryAddSingleton<IConnectionStringProvider, NetworkBasedConnectionStringProvider>();

/* mimic codat stuff building the container and invoking stuff */
var connectionStringResolver = builder.Services.BuildServiceProvider().GetRequiredService<IConnectionStringProvider>();
connectionStringResolver.Get();

var app = builder.Build();

app.MapGet("/hello", () => "Hello");

app.Run();

public interface IConnectionStringProvider
{
    string Get();
}

public class NetworkBasedConnectionStringProvider : IConnectionStringProvider
{
    public string Get()
    {
        throw new NotImplementedException();
    }
}

public partial class Program
{
    public static Action<IServiceCollection>? Configure { get; set; } 
}