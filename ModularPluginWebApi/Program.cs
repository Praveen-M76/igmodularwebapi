using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Plugin folder path
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

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Root URL redirect to Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// Map Controllers
app.MapControllers();

// Run App
app.Run();
