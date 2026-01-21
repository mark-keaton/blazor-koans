using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using Xunit;
using System.Net.Http.Json;

namespace BlazorKoans.Tests.Advanced.HttpClients;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            HTTP GET REQUESTS                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  HTTP GET requests are used to retrieve data from APIs. In Blazor, we        ║
/// ║  typically use HttpClient with extension methods like GetFromJsonAsync       ║
/// ║  to fetch and deserialize JSON responses in a single call.                   ║
/// ║                                                                              ║
/// ║  Key Concepts You'll Learn:                                                  ║
/// ║  1. GetFromJsonAsync combines GET request + JSON deserialization             ║
/// ║  2. Services wrap HttpClient to provide typed API access                     ║
/// ║  3. Empty arrays and single objects are handled seamlessly                   ║
/// ║  4. FakeHttpMessageHandler allows testing without real HTTP calls            ║
/// ║                                                                              ║
/// ║  Example usage pattern:                                                      ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  var forecasts = await httpClient                                      │  ║
/// ║  │      .GetFromJsonAsync&lt;List&lt;WeatherForecast&gt;&gt;("api/weather");          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_GetRequests : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task A_GetFromJsonAsync_deserializes_JSON_response()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: GetFromJsonAsync - The Convenience Method
        // ═══════════════════════════════════════════════════════════════════════
        //
        // GetFromJsonAsync is an extension method that combines two operations:
        // 1. Sending an HTTP GET request to the specified URL
        // 2. Deserializing the JSON response into a strongly-typed object
        //
        // Without GetFromJsonAsync (the hard way):
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  var response = await httpClient.GetAsync("api/weather");           │
        // │  var json = await response.Content.ReadAsStringAsync();             │
        // │  var data = JsonSerializer.Deserialize<List<Weather>>(json);        │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // With GetFromJsonAsync (the easy way):
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  var data = await httpClient.GetFromJsonAsync<List<Weather>>(url);  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: The test data contains 2 weather forecasts.
        //           How many items will be in the result?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setting up fake HTTP handler with test weather data
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the value with the correct count        ║
        // ║  HINT: Count the WeatherForecast objects in testData above         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the result
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Equal(answer, result.Count);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task B_WeatherService_uses_GetFromJsonAsync()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Service Classes Wrap HttpClient
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In real applications, we don't use HttpClient directly in components.
        // Instead, we create service classes that encapsulate API calls:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  public class WeatherService                                        │
        // │  {                                                                  │
        // │      private readonly HttpClient _httpClient;                       │
        // │                                                                     │
        // │      public WeatherService(HttpClient httpClient)                   │
        // │          => _httpClient = httpClient;                               │
        // │                                                                     │
        // │      public Task<List<WeatherForecast>> GetForecastAsync()          │
        // │          => _httpClient.GetFromJsonAsync<List<WeatherForecast>>(    │
        // │              "api/weather");                                        │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Benefits: testability, single responsibility, easier refactoring
        //
        // EXERCISE: We mock the API to return a forecast with Summary = "Scorching".
        //           What is the summary of the first forecast returned?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setting up WeatherService with mocked HTTP response
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace "__" with the correct summary string    ║
        // ║  HINT: Look at the Summary property in the testData above          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the result
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(answer, result[0].Summary);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task C_GetFromJsonAsync_handles_empty_arrays()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Handling Empty Responses
        // ═══════════════════════════════════════════════════════════════════════
        //
        // API endpoints often return empty arrays when no data matches the query.
        // GetFromJsonAsync handles this gracefully - it returns an empty list,
        // not null.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // API returns: []                                                 │
        // │  var items = await http.GetFromJsonAsync<List<Item>>("api/items");  │
        // │  // items is an empty List<Item>, NOT null                          │
        // │  // items.Count == 0                                                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // This is important because you can safely iterate or check .Count
        // without null checks.
        //
        // EXERCISE: The mock returns an empty array.
        //           How many items should be in the result?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setting up fake handler with empty weather array
        // ──────────────────────────────────────────────────────────────────────
        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddJsonResponse("https://api.test.com/api/weather", new List<WeatherForecast>());

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the value with the correct count        ║
        // ║  HINT: An empty array has how many items?                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the result
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Equal(answer, result.Count);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task D_GetFromJsonAsync_returns_single_objects()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Fetching Single Objects
        // ═══════════════════════════════════════════════════════════════════════
        //
        // GetFromJsonAsync works with both collections and single objects.
        // When fetching a specific resource by ID, APIs typically return
        // a single object instead of an array.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // Fetch all items - returns List<Item>                            │
        // │  var items = await http.GetFromJsonAsync<List<Item>>("api/items");  │
        // │                                                                     │
        // │  // Fetch single item by ID - returns Item                          │
        // │  var item = await http.GetFromJsonAsync<Item>("api/items/1");       │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: The mock returns a single WeatherForecast with TemperatureC = 18.
        //           What is the TemperatureC value of the result?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setting up fake handler with single weather forecast
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the value with the correct temperature  ║
        // ║  HINT: Look at the TemperatureC property in testData above         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the result
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(result);
        Assert.Equal(answer, result.TemperatureC);
    }
}
