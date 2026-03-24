using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllers();

/* Load Plugins */
var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

if (Directory.Exists(pluginPath))
{
    foreach (var file in Directory.GetFiles(pluginPath, "*.dll"))
    {
        var assembly = Assembly.LoadFrom(file);
        mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
    }
}

/* Swagger */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModularPluginWebApi v1");

    // Swagger root la open aagum
    c.RoutePrefix = string.Empty;

    // Click panna URL hash change aagum
    c.EnableDeepLinking();
});

app.MapControllers();

/* Render PORT FIX */
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");