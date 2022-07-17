
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prozorro.ClientExtentions;
using Prozorro.Data;
using Prozorro.Models;
using Prozorro.Models.Enums;
using Prozorro.Models.Implementations;
using Prozorro.Models.Interfaces;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Prozorro
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .Build();
            SeedData(host);

            var context = host.Services.GetService<ProzorroContext>();
            foreach (var item in await context.OfferDTOs.ToListAsync())
            {
                Console.WriteLine(item.Comment);
            }
        }
        public static void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Seeding data...");
                var service = scope.ServiceProvider.GetService<ProzorroDbInitializer>();
                service.SeedDataAsync("https://catalog-api-staging.prozorro.gov.ua").Wait();
            }
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProzorroContext>()
                  .AddTransient<ProzorroDbInitializer>();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHost(
                     webHost => webHost
                         .UseKestrel(kestrelOptions => { kestrelOptions.ListenAnyIP(5005); })
                         .ConfigureServices(ConfigureServices)
                         .Configure(app => app
                            .Run(
                                async context =>
                                {
                                    var numberOfFoos = 5;
                                    // Resolve IFooService here
                                    var prozorroContext = context.RequestServices.GetRequiredService<ProzorroContext>();
                                    await context.Response.WriteAsync(numberOfFoos.ToString());
                                    //foreach (var item in prozorroContext.OfferDTOs)
                                    //{
                                    //await context.Response.WriteAsync(item.RelatedProduct);
                                    //
                                    //}

                                }
                            )));

    }

}
//    

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//    SeedData(host);
//else
//{
//    ExemplifyScoping(host.Services, "Scope 1");
//    ExemplifyScoping(host.Services, "Scope 2");
//}
//}

//await host.RunAsync();





//static void ExemplifyScoping(IServiceProvider services, string scope)
//{
//    using IServiceScope serviceScope = services.CreateScope();
//    IServiceProvider provider = serviceScope.ServiceProvider;

//    OperationLogger logger = provider.GetRequiredService<OperationLogger>();
//    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

//    Console.WriteLine("...");

//    logger = provider.GetRequiredService<OperationLogger>();
//    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

//    Console.WriteLine();
//}



//public static IHostBuilder CreateHostBuilder(string[] args) =>
//  Host.CreateDefaultBuilder(args)
//      .ConfigureWebHost(
//          webHost => webHost
//              .UseKestrel(kestrelOptions => { kestrelOptions.ListenAnyIP(5005); })
//              .Configure(app => app
//                  .Run(
//                      async context =>
//                      {
//                          await context.Response.WriteAsync("Hello World!");
//                      }
//                  )));