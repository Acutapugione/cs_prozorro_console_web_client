
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prozorro.ClientExtentions;
using Prozorro.Data;
using Prozorro.Models;
using Prozorro.Models.Enums;
using Prozorro.Models.Implementations;
using Prozorro.Models.Interfaces;
using System.Text;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<ITransientOperation, DefaultOperation>()
            .AddScoped<IScopedOperation, DefaultOperation>()
            .AddSingleton<ISingletonOperation, DefaultOperation>()
            .AddTransient<OperationLogger>()
            .AddDbContext<ProzorroContext>()
            .AddTransient<ProzorroDbInitializer>()
            )
    .Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(host);
else
{
    ExemplifyScoping(host.Services, "Scope 1");
    ExemplifyScoping(host.Services, "Scope 2");
}


await host.RunAsync();



void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        //ClientExecutor Client = new(Mode.Dev, "https://catalog-api-staging.prozorro.gov.ua");
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"Seeding data...");
        var service = scope.ServiceProvider.GetService<ProzorroDbInitializer>();
        service.SeedDataAsync().Wait();
    }
}

static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    OperationLogger logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

    Console.WriteLine();
}



