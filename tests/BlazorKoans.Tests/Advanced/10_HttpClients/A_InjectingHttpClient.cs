using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

public class A_InjectingHttpClient : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void HttpClient_can_be_injected_via_dependency_injection()
    {
        // ABOUT: HttpClient is a core service in Blazor for making HTTP requests.
        // It should be injected using the @inject directive or [Inject] attribute.

        // TODO: What directive is used to inject HttpClient in a Blazor component?
        // Replace "__" with the correct directive (without the @ symbol)

        var expected = "__";

        Assert.Equal("inject", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void IWeatherService_can_be_injected_and_used()
    {
        // ABOUT: Custom services like IWeatherService can be registered with DI
        // and injected into components just like HttpClient.

        // TODO: Register a FakeWeatherService and render WeatherDisplay component.
        // How many forecasts does the FakeWeatherService return by default?

        Services.AddSingleton<IWeatherService>(new FakeWeatherService());

        var cut = Render<WeatherDisplay>();

        var expected = 0;

        cut.WaitForAssertion(() =>
            cut.MarkupMatches($"<h3>Weather Display</h3><div>Count: {expected}</div>"));
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
