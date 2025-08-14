using Microsoft.EntityFrameworkCore;
using Efcoreinmemory.Models;

namespace Efcoreinmemory.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    //Adding db entities
    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
}