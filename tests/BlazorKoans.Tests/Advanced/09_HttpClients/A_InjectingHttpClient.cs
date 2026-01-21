using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                     INJECTING HTTP CLIENT IN BLAZOR                          ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  HttpClient is how Blazor apps communicate with web APIs.                    ║
/// ║  It's injected via DI and typically wrapped in service classes.              ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @inject HttpClient Http                                             │  ║
/// ║  │  @inject IWeatherService WeatherService                              │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Or in code-behind:                                                │  ║
/// ║  │  [Inject] public HttpClient Http { get; set; }                        │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Best practice: wrap in service class                              │  ║
/// ║  │  public class WeatherService : IWeatherService { ... }                │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_InjectingHttpClient : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void HttpClient_can_be_injected_via_dependency_injection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The @inject Directive for HttpClient
        // ═══════════════════════════════════════════════════════════════════════
        //
        // HttpClient is injected using the same directive as other services.
        // In .razor files: @inject HttpClient Http
        //
        // EXERCISE: What directive is used? (without the @ symbol)
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What directive injects services?                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The directive is "inject"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("inject", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void IWeatherService_can_be_injected_and_used()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Using Custom Service Wrappers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Custom services like IWeatherService wrap HttpClient logic.
        // FakeWeatherService returns a predefined set of forecasts for testing.
        //
        // EXERCISE: How many forecasts does FakeWeatherService return?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering fake service and rendering
        // ──────────────────────────────────────────────────────────────────────
        Services.AddSingleton<IWeatherService>(new FakeWeatherService());

        var cut = Render<WeatherDisplay>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many forecasts does FakeWeatherService return?║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The count should match the fake service's return
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            cut.MarkupMatches($"<h3>Weather Display</h3><div>Count: {answer}</div>"));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void HttpClient_requires_base_address_configuration()
    {
        // ABOUT: HttpClient needs a base address to know where to send requests.
        // In Blazor Server, this is typically configured in Program.cs.

        // TODO: What property of HttpClient holds the base URL for API requests?
        // Replace "__" with the property name

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.example.com/");

        var expected = "__";

        Assert.Equal("https://api.example.com/", httpClient.BaseAddress?.ToString());
        Assert.Equal("BaseAddress", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Custom_services_encapsulate_HttpClient_logic()
    {
        // ABOUT: Best practice is to wrap HttpClient in service classes
        // rather than injecting HttpClient directly into components.

        // TODO: The WeatherService class wraps HttpClient.
        // What interface does it implement?

        var fakeHandler = new FakeHttpMessageHandler();
        var httpClient = new HttpClient(fakeHandler);
        var weatherService = new WeatherService(httpClient);

        var expected = "__";

        Assert.IsAssignableFrom(typeof(IWeatherService), weatherService);
        Assert.Equal("IWeatherService", expected);
    }
}
