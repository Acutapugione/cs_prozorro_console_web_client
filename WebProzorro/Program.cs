using Microsoft.EntityFrameworkCore;
using Prozorro.Data;
using Microsoft.Extensions.DependencyInjection;
using WebProzorro.Data;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<WebProzorroContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("WebProzorroContext") ?? throw new InvalidOperationException("Connection string 'WebProzorroContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebProzorroContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WebProzorroContext"))
    );
builder.Services.AddTransient<ProzorroWebDbInitializer>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var initializer = new ProzorroWebDbInitializer(
        scope.ServiceProvider.GetService<WebProzorroContext>(),
        new Prozorro.ClientExtentions.ClientExecutor(
            Prozorro.Models.Enums.Mode.Dev, 
            "https://catalog-api-staging.prozorro.gov.ua")
        );
    await initializer.SeedDataAsync();
    //var seeder = scope.ServiceProvider.GetService<ProzorroDbInitializer>();
    //await seeder?.SeedDataAsync();
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
