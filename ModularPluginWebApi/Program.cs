using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IG Modular Web API",
        Version = "v1",
        Description = "Plugin Based Web API"
    });
});

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IG Modular Web API v1");
});

// Redirect root URL to Swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

// Map controllers
app.MapControllers();

// Render port configuration
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"[http://0.0.0.0:{port}](http://0.0.0.0:{port})");
