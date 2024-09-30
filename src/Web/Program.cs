using OneInc.Server.Application;
using OneInc.Server.Infrastructure;
using OneInc.Server.Web;

var builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment environment = builder.Environment;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .Build();

Console.WriteLine($"Environment: {environment.EnvironmentName}");

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, environment);
builder.Services.AddWebServices();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");

app.UseExceptionHandler();

app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


app.Run();

public partial class Program;
