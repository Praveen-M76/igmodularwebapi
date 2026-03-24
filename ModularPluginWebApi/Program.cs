using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

/* Load Plugins */
var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

if (Directory.Exists(pluginPath))
{
    var mvcBuilder = builder.Services.AddControllers();

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

    // This makes Swagger open at /index.html
    c.RoutePrefix = "index";

    // This makes URL change when you click controller/endpoint
    c.EnableDeepLinking();
});

app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapControllers();

/* Render PORT FIX */
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");