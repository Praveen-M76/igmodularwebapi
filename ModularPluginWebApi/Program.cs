using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IG Modular Web API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IG Modular Web API V1");
});

// Redirect root to swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.MapControllers();

/* Render PORT FIX */
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");