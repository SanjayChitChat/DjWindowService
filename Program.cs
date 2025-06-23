using MyWindowServiceApplication;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Enables Windows Service behavior
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole(); // For manual run via console
        logging.AddEventLog(); // Logs to Windows Event Viewer
    });

// Optional: Set current directory for file-dependent services
Directory.SetCurrentDirectory(AppContext.BaseDirectory);

await builder.Build().RunAsync();