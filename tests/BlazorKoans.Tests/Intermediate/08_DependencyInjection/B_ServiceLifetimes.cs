using Bunit;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

public class B_ServiceLifetimes : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ServiceLifetimes_Singleton()
    {
        // ABOUT: Singleton services are created once per application lifetime
        // The same instance is used for all requests

        // TODO: Replace "__" with "same" or "different"
        // HINT: Singleton means one instance for the entire application

        Services.AddSingleton<ICounterService, CounterService>();

        var service1 = Services.GetRequiredService<ICounterService>();
        var service2 = Services.GetRequiredService<ICounterService>();

        var expected = "same"; // SOLUTION: "same"

        var actual = ReferenceEquals(service1, service2) ? "same" : "different";
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ServiceLifetimes_Transient()
    {
        // ABOUT: Transient services are created each time they're requested
        // Each injection gets a new instance

        // TODO: Replace "__" with "same" or "different"
        // HINT: Transient creates a new instance every time

        Services.AddTransient<ICounterService, CounterService>();

        var service1 = Services.GetRequiredService<ICounterService>();
        var service2 = Services.GetRequiredService<ICounterService>();

        var expected = "different"; // SOLUTION: "different"

        var actual = ReferenceEquals(service1, service2) ? "same" : "different";
        Assert.Equal(expected, actual);
    }
}
