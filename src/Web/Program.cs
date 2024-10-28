using OneInc.Server.Application;
using OneInc.Server.Web;

var builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment environment = builder.Environment;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddApplicationServices();
builder.Services.AddWebServices();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowWebClient");

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
