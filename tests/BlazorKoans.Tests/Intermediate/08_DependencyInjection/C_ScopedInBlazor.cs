using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    SCOPED SERVICES IN BLAZOR SERVER                          ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  In Blazor Server, a "circuit" is the connection between browser and server. ║
/// ║  SCOPED services live for the lifetime of that circuit (user session).       ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  User A opens app → New circuit → New scoped services                  │  ║
/// ║  │  User A clicks around → Same scoped service instances                  │  ║
/// ║  │  User A closes browser → Circuit ends → Services disposed              │  ║
/// ║  │                                                                        │  ║
/// ║  │  User B opens app → Different circuit → Different service instances   │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_ScopedInBlazor : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ScopedServices_PerCircuit()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Initial State of Scoped Services
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a circuit starts, scoped services are created fresh.
        // CounterService starts with an initial value.
        //
        // EXERCISE: What is the initial counter value?
        //           (Check the CounterService implementation)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering scoped services and rendering
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial counter value?                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Counter value appears in markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Counter: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ScopedServices_StatePersistence()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Scoped Services Maintain State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Scoped services persist state throughout the circuit.
        // When you modify the counter, it stays modified for that user.
        //
        // EXERCISE: What is the counter value after clicking increment once?
        //           (Counter starts at 0, Increment() adds 1)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and clicking the increment button
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var button = cut.Find("button");
        button.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is counter after clicking increment?         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Counter value should be incremented
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Counter: {answer}", cut.Markup);
    }
}
