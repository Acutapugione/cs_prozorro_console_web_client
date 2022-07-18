using Prozorro.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Prozorro;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication
            .CreateBuilder(args);
        builder.Services
            .AddDbContext<ProzorroContext>(options =>
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            )
            .AddTransient<ProzorroDbInitializer>()
            .AddControllersWithViews();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var initializer = new ProzorroDbInitializer(
                scope.ServiceProvider.GetService<ProzorroContext>(),
                new Prozorro.ClientExtentions.ClientExecutor(
                    Prozorro.Models.Enums.Mode.Dev,
                    "https://catalog-api-staging.prozorro.gov.ua")
                );
            await initializer.SeedDataAsync();
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }
}