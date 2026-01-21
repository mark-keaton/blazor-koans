using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            HTTP POST REQUESTS                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  POST requests send data to the server to create new resources.              ║
/// ║  PostAsJsonAsync automatically serializes objects to JSON.                   ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Sending data via POST                                              │  ║
/// ║  │  var response = await httpClient.PostAsJsonAsync("api/items", item);   │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Reading the created resource from response                         │  ║
/// ║  │  var created = await response.Content.ReadFromJsonAsync<Item>();       │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_PostRequests : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task PostAsJsonAsync_sends_object_as_JSON()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Sending JSON Data with PostAsJsonAsync
        // ═══════════════════════════════════════════════════════════════════════
        //
        // PostAsJsonAsync serializes an object to JSON and sends it as a POST
        // request. The server typically responds with a status code indicating
        // success (2xx) or failure.
        //
        // EXERCISE: Does the POST response indicate success?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - configuring fake handler to return Created status
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the response successful?                     ║
        // ║                                                                    ║
        // ║  HINT: HttpStatusCode.Created (201) is a success status code       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if IsSuccessStatusCode matches your answer
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, response.IsSuccessStatusCode);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task PostAsJsonAsync_returns_created_resource()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reading the Created Resource from POST Response
        // ═══════════════════════════════════════════════════════════════════════
        //
        // POST endpoints often return the created resource in the response body.
        // You can deserialize it using ReadFromJsonAsync on the response content.
        //
        // EXERCISE: What is the Summary value of the created forecast?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - configuring fake handler with created forecast
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the Summary of the created forecast?    ║
        // ║                                                                    ║
        // ║  HINT: Look at the createdForecast object configured above         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The result's Summary should match your answer
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Equal(answer, result.Summary);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task WeatherService_CreateForecastAsync_uses_POST()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Wrapping POST Calls in Service Methods
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Service methods wrap PostAsJsonAsync for cleaner component code.
        // This encapsulates HTTP details and provides a typed API.
        //
        // EXERCISE: Does the service return a forecast with Summary "Warm"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating WeatherService with fake HTTP client
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the result have Summary "Warm"?            ║
        // ║                                                                    ║
        // ║  HINT: Check if result.Summary equals "Warm"                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The service should return the created forecast
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Equal(answer, result.Summary == "Warm");
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task POST_requests_can_include_complex_objects()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Serializing Complex Nested Objects
        // ═══════════════════════════════════════════════════════════════════════
        //
        // PostAsJsonAsync automatically serializes complex nested objects,
        // including anonymous types with nested properties and arrays.
        //
        // EXERCISE: Is the complex object serialization automatic?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - configuring handler and complex nested object
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the POST succeed with complex objects?     ║
        // ║                                                                    ║
        // ║  HINT: Check if the response indicates success (200 OK)            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Complex objects should serialize and POST successfully
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, response.IsSuccessStatusCode);
    }
}
