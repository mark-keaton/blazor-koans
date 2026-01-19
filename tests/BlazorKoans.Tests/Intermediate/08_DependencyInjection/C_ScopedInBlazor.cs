using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

public class C_ScopedInBlazor : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ScopedServices_PerCircuit()
    {
        // ABOUT: In Blazor Server, Scoped services are created once per circuit
        // A circuit represents a user's interactive session

        // TODO: Replace 0 with the initial counter value
        // HINT: Check the CounterService constructor/initialization

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var expected = 0; // SOLUTION: 0

        Assert.Contains($"Counter: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ScopedServices_StatePersistence()
    {
        // ABOUT: Scoped services maintain state throughout the circuit lifetime

        // TODO: Replace 0 with the counter value after clicking increment
        // HINT: The counter starts at 0, and Increment() adds 1

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var button = cut.Find("button");
        button.Click();

        var expected = 0; // SOLUTION: 1

        Assert.Contains($"Counter: {expected}", cut.Markup);
    }
}
