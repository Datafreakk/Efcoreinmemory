using Efcoreinmemory.Data;
using Efcoreinmemory.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core In-Memory database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("WeatherDb"));

// Add your services
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Add controllers
builder.Services.AddControllers();

// ✅ Add Swagger generator
builder.Services.AddEndpointsApiExplorer();  // Optional, helps with minimal APIs
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger middleware in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Efcoreinmemory API v1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI available at the root URL
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
