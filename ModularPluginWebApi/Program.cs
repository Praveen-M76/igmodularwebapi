using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Load plugin DLLs (if any exist in Plugins folder)
var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

if (Directory.Exists(pluginPath))
{
    foreach (var file in Directory.GetFiles(pluginPath, "*.dll"))
    {
        var assembly = Assembly.LoadFrom(file);

        builder.Services.AddControllers()
            .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
    }
}

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable static files (required for swagger-login.js)
app.UseStaticFiles();

// Enable Swagger
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModularPluginWebApi v1");

    // Inject custom JavaScript for login popup
    c.InjectJavascript("/swagger-login.js");
});

// Redirect root URL to Swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

// Map controllers
app.MapControllers();

// Render deployment port fix
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");