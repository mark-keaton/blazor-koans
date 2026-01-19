using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

public class A_InjectDirective : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectDirective_InjectsService()
    {
        // ABOUT: @inject directive injects services into Blazor components
        // Syntax: @inject IServiceType PropertyName

        // TODO: Replace "__" with the greeting returned by the service
        // HINT: Look at GreetingService.Greet() implementation

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var expected = "__";

        Assert.Contains($"Greeting: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectDirective_MultipleServices()
    {
        // ABOUT: You can inject multiple services in the same component

        // TODO: Replace "__" with the service type returned
        // HINT: Check the GreetingService.GetServiceType() method

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var expected = "__";

        Assert.Contains($"Service Type: {expected}", cut.Markup);
    }
}
