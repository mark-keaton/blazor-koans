using BlazorKoans.App.Models;

namespace BlazorKoans.App.Services;

public interface IWeatherService
{
    Task<List<WeatherForecast>> GetForecastAsync();
    Task<WeatherForecast?> GetForecastByIdAsync(int id);
    Task<WeatherForecast> CreateForecastAsync(WeatherForecast forecast);
    Task<bool> UpdateForecastAsync(int id, WeatherForecast forecast);
    Task<bool> DeleteForecastAsync(int id);
}
