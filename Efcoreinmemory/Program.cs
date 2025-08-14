using Efcoreinmemory.Data;
using Microsoft.EntityFrameworkCore;
using Efcoreinmemory.Services;

using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("WeatherDb"));
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddControllers();

var app = builder.Build();


app.MapControllers();
app.Run();