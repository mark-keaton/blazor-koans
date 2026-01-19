using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using Xunit;
using System.Net.Http.Json;

namespace BlazorKoans.Tests.Advanced.HttpClients;

public class B_GetRequests : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task GetFromJsonAsync_deserializes_JSON_response()
    {
        // ABOUT: GetFromJsonAsync is a convenience method that combines
        // sending a GET request and deserializing the JSON response.

        // TODO: Set up a fake HTTP response and use GetFromJsonAsync.
        // How many items are returned?

        var fakeHandler = new FakeHttpMessageHandler();
        var testData = new List<WeatherForecast>
        {
            new() { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 20, Summary = "Sunny" },
            new() { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 25, Summary = "Hot" }
        };

        fakeHandler.AddJsonResponse("https://api.test.com/api/weather", testData);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");

        var expected = 2; // SOLUTION: 2

        Assert.NotNull(result);
        Assert.Equal(expected, result.Count);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task WeatherService_uses_GetFromJsonAsync()
    {
        // ABOUT: Service classes use GetFromJsonAsync to fetch typed data from APIs.

        // TODO: Mock an HTTP response and call WeatherService.GetForecastAsync().
        // What is the summary of the first forecast?

        var fakeHandler = new FakeHttpMessageHandler();
        var testData = new List<WeatherForecast>
        {
            new() { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 30, Summary = "Scorching" }
        };

        fakeHandler.AddJsonResponse("https://api.test.com/api/weather", testData);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var service = new WeatherService(httpClient);
        var result = await service.GetForecastAsync();

        var expected = "Scorching"; // SOLUTION: "Scorching"

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected, result[0].Summary);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task GetFromJsonAsync_handles_empty_arrays()
    {
        // ABOUT: API endpoints may return empty arrays.
        // GetFromJsonAsync properly deserializes them.

        // TODO: Mock an empty array response.
        // How many items should be in the result?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddJsonResponse("https://api.test.com/api/weather", new List<WeatherForecast>());

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");

        var expected = 0; // SOLUTION: 0

        Assert.NotNull(result);
        Assert.Equal(expected, result.Count);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task GetFromJsonAsync_returns_single_objects()
    {
        // ABOUT: GetFromJsonAsync works with both collections and single objects.

        // TODO: Fetch a single WeatherForecast object.
        // What is the TemperatureC value?

        var fakeHandler = new FakeHttpMessageHandler();
        var testData = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 18,
            Summary = "Cool"
        };

        fakeHandler.AddJsonResponse("https://api.test.com/api/weather/1", testData);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var result = await httpClient.GetFromJsonAsync<WeatherForecast>("api/weather/1");

        var expected = 18; // SOLUTION: 18

        Assert.NotNull(result);
        Assert.Equal(expected, result.TemperatureC);
    }
}
