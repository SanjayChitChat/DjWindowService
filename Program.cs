using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWindowServiceApplication;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Enables running as Windows Service
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
