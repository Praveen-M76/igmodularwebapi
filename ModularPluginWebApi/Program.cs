using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
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

// Enable Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IG Modular Web API V1");
    c.RoutePrefix = string.Empty; // Opens Swagger at root URL
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();