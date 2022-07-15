
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
            .AddDbContext<ProzorroContext>())
    .Build();


ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");

await host.RunAsync();


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

static async Task LoadItemsFromApiAsync()
{
    ClientExecutor Client = new(Mode.Dev, "https://catalog-api-staging.prozorro.gov.ua");
    Console.OutputEncoding = Encoding.UTF8;

    await LoadItems<OfferDTO>(Client, "offers");

    await LoadItems<VendorDTO>(Client, "vendors");

    await LoadItems<CategoryDTO>(Client, "categories");

    await LoadItems<ProfileDTO>(Client, "profiles");

    await LoadItems<ProductDTO>(Client, "products");

}

static async Task<HashSet<T>> LoadItems<T>(ClientExecutor client, string typeName = "products")
{
    try
    {
        HashSet<BaseItemDTO> indexes = await client
            .LoadIndexesByType(
            typeName: typeName,
            count: 100);

        var items = await client
            .LoadObjectsByType<T>(
            indexes,
            typeName: typeName,
            count: 100);

        return items;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return new();
    }
}
