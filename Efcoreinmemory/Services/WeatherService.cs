using Efcoreinmemory.Data;
using Efcoreinmemory.Models;
using Microsoft.EntityFrameworkCore;

namespace Efcoreinmemory.Services;

public class WeatherService : IWeatherService
{
    private readonly AppDbContext _context;

    public WeatherService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherForecast>> GetAllAsync() =>
        await _context.WeatherForecasts.ToListAsync();
    
    public async Task<WeatherForecast?> GetByIdAsync(int id) =>
        await _context.WeatherForecasts.FindAsync(id);

    public async Task<WeatherForecast> CreateAsync(WeatherForecast forecast)
    {
        _context.WeatherForecasts.Add(forecast);
        await _context.SaveChangesAsync();
        return forecast;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.WeatherForecasts.FindAsync(id);
        if (entity == null) return false;
        _context.WeatherForecasts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
    