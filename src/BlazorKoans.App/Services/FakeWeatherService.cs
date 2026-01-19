using BlazorKoans.App.Models;

namespace BlazorKoans.App.Services;

public class FakeWeatherService : IWeatherService
{
    private readonly List<WeatherForecast> _forecasts = new()
    {
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "Sunny" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 20, Summary = "Cloudy" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 15, Summary = "Rainy" }
    };

    public Task<List<WeatherForecast>> GetForecastAsync()
    {
        return Task.FromResult(_forecasts);
    }

    public Task<WeatherForecast?> GetForecastByIdAsync(int id)
    {
        return Task.FromResult(_forecasts.ElementAtOrDefault(id));
    }

    public Task<WeatherForecast> CreateForecastAsync(WeatherForecast forecast)
    {
        _forecasts.Add(forecast);
        return Task.FromResult(forecast);
    }

    public Task<bool> UpdateForecastAsync(int id, WeatherForecast forecast)
    {
        if (id < _forecasts.Count)
        {
            _forecasts[id] = forecast;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> DeleteForecastAsync(int id)
    {
        if (id < _forecasts.Count)
        {
            _forecasts.RemoveAt(id);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
