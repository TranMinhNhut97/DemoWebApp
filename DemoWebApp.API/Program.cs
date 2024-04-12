using DemoWebApp.API;
using DemoWebApp.Application;
using DemoWebApp.Domain.Exception;
using DemoWebApp.Infrastructure;
using NLog;
using NLog.Web;
using Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddWebAppApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
