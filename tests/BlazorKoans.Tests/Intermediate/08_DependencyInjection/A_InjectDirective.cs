using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    DEPENDENCY INJECTION: @INJECT DIRECTIVE                   ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Dependency Injection (DI) provides services to components without the       ║
/// ║  component needing to know how to create them.                               ║
/// ║                                                                              ║
/// ║  The @inject directive:                                                      ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @inject IWeatherService Weather     ← Service type + property name    │  ║
/// ║  │  @inject IUserService UserService    ← Can inject multiple services    │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;p&gt;@Weather.GetForecast()&lt;/p&gt;       ← Use the service like any prop  │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Services must be registered in Program.cs:                                  ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  builder.Services.AddScoped&lt;IWeatherService, WeatherService&gt;();        │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_InjectDirective : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectDirective_InjectsService()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Injecting Services with @inject
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The @inject directive requests a service from the DI container.
        // Blazor creates or retrieves the service and assigns it to the property.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @inject IGreetingService Greeter                                   │
        // │          ↑                ↑                                         │
        // │     Service type     Property name                                  │
        // │                                                                     │
        // │  <p>@Greeter.Greet()</p>    ← Calls method on injected service      │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: ServiceDemo injects IGreetingService and calls Greet().
        //           What string does GreetingService.Greet() return?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering services (normally done in Program.cs)
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What does GreetingService.Greet() return?       ║
        // ║                                                                    ║
        // ║  HINT: Look at the GreetingService class implementation            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The greeting should appear in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Greeting: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectDirective_MultipleServices()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Injecting Multiple Services
        // ═══════════════════════════════════════════════════════════════════════
        //
        // A component can inject as many services as it needs.
        // Just add multiple @inject directives.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @inject IGreetingService Greeter                                   │
        // │  @inject ICounterService Counter                                    │
        // │  @inject IUserService Users                                         │
        // │                                                                     │
        // │  @code {                                                            │
        // │      // Use all services as needed                                  │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: ServiceDemo also displays the service type.
        //           What does GreetingService.GetServiceType() return?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering both services
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What does GetServiceType() return?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The service type should appear in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Service Type: {answer}", cut.Markup);
    }
}
