using BlazorKoans.App.Models;
using System.Net.Http.Json;

namespace BlazorKoans.App.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WeatherForecast>> GetForecastAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather") ?? new List<WeatherForecast>();
    }

    public async Task<WeatherForecast?> GetForecastByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<WeatherForecast>($"api/weather/{id}");
    }

    public async Task<WeatherForecast> CreateForecastAsync(WeatherForecast forecast)
    {
        var response = await _httpClient.PostAsJsonAsync("api/weather", forecast);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<WeatherForecast>() ?? forecast;
    }

    public async Task<bool> UpdateForecastAsync(int id, WeatherForecast forecast)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/weather/{id}", forecast);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteForecastAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/weather/{id}");
        return response.IsSuccessStatusCode;
    }
}
