using Efcoreinmemory.Models;

namespace Efcoreinmemory.Services;

public interface IWeatherService
{
    Task<List<WeatherForecast>> GetAllAsync();
    Task<WeatherForecast?> GetByIdAsync(int id);
    Task<WeatherForecast> CreateAsync(WeatherForecast forecast);
    Task<bool> DeleteAsync(int id);
    
}