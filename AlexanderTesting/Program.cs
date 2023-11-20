using AlexanderTesting.Models.Context;
using AlexanderTesting.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;  

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddDevExpressBlazor();
services.AddLocalization(options => options.ResourcesPath = "Resources");

services.AddDbContext<AlexanderTestingBaseContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
    });

services.AddScoped<PeopleRepository>();

services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture("ru");
    var supportedCultures = new List<CultureInfo>() { new CultureInfo("ru") };
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();