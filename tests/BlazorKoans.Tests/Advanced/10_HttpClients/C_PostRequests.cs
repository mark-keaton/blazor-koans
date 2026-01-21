using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

public class C_PostRequests : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task PostAsJsonAsync_sends_object_as_JSON()
    {
        // ABOUT: PostAsJsonAsync serializes an object to JSON and sends it as POST.

        // TODO: Send a WeatherForecast via POST.
        // Does the response indicate success?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddJsonResponse("https://api.test.com/api/weather",
            new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 22, Summary = "Mild" },
            HttpStatusCode.Created);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var newForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 22,
            Summary = "Mild"
        };

        var response = await httpClient.PostAsJsonAsync("api/weather", newForecast);

        var expected = false;

        Assert.Equal(expected, response.IsSuccessStatusCode);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task PostAsJsonAsync_returns_created_resource()
    {
        // ABOUT: POST endpoints often return the created resource in the response body.

        // TODO: Extract the created forecast from the response.
        // What is the Summary value?

        var fakeHandler = new FakeHttpMessageHandler();
        var createdForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 15,
            Summary = "Chilly"
        };

        fakeHandler.AddJsonResponse("https://api.test.com/api/weather",
            createdForecast,
            HttpStatusCode.Created);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var newForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 15,
            Summary = "Chilly"
        };

        var response = await httpClient.PostAsJsonAsync("api/weather", newForecast);
        var result = await response.Content.ReadFromJsonAsync<WeatherForecast>();

        var expected = "__";

        Assert.NotNull(result);
        Assert.Equal(expected, result.Summary);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task WeatherService_CreateForecastAsync_uses_POST()
    {
        // ABOUT: Service methods wrap PostAsJsonAsync for cleaner component code.

        // TODO: Use WeatherService.CreateForecastAsync().
        // Does it return the created forecast?

        var fakeHandler = new FakeHttpMessageHandler();
        var createdForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 28,
            Summary = "Warm"
        };

        fakeHandler.AddJsonResponse("https://api.test.com/api/weather",
            createdForecast,
            HttpStatusCode.Created);

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var service = new WeatherService(httpClient);
        var result = await service.CreateForecastAsync(createdForecast);

        var expected = false;

        Assert.NotNull(result);
        Assert.Equal(expected, result.Summary == "Warm");
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task POST_requests_can_include_complex_objects()
    {
        // ABOUT: PostAsJsonAsync automatically serializes complex nested objects.

        // TODO: Send a complex object with nested properties.
        // Is the serialization automatic?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.SetResponseFactory(request =>
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"success\":true}", System.Text.Encoding.UTF8, "application/json")
            };
        });

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var complexData = new
        {
            Name = "Test",
            Nested = new { Value = 42 },
            Items = new[] { 1, 2, 3 }
        };

        var response = await httpClient.PostAsJsonAsync("api/complex", complexData);

        var expected = false;

        Assert.Equal(expected, response.IsSuccessStatusCode);
    }
}
