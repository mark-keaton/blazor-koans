using Bunit;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          SERVICE LIFETIMES                                   ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Services have LIFETIMES that control when instances are created/shared.     ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  SINGLETON:  One instance for entire application lifetime            │  ║
/// ║  │               AddSingleton&lt;IService, Service&gt;()                      │  ║
/// ║  │               → Same instance everywhere                             │  ║
/// ║  │                                                                        │  ║
/// ║  │  SCOPED:     One instance per scope (per request/circuit)             │  ║
/// ║  │               AddScoped&lt;IService, Service&gt;()                          │  ║
/// ║  │               → Same instance within a user's session                 │  ║
/// ║  │                                                                        │  ║
/// ║  │  TRANSIENT:  New instance every time it's requested                   │  ║
/// ║  │               AddTransient&lt;IService, Service&gt;()                       │  ║
/// ║  │               → Fresh instance each injection                         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_ServiceLifetimes : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ServiceLifetimes_Singleton()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Singleton - One Instance Forever
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Singleton: ONE instance shared by everyone, for the entire app lifetime.
        // Good for: Caches, configuration, logging.
        //
        // EXERCISE: When you request a singleton twice, do you get the
        //           "same" or "different" instance?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering as singleton
        // ──────────────────────────────────────────────────────────────────────
        Services.AddSingleton<ICounterService, CounterService>();

        var service1 = Services.GetRequiredService<ICounterService>();
        var service2 = Services.GetRequiredService<ICounterService>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are singleton instances "same" or "different"?   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if instances are the same object
        // ──────────────────────────────────────────────────────────────────────
        var actual = ReferenceEquals(service1, service2) ? "same" : "different";
        Assert.Equal(answer, actual);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ServiceLifetimes_Transient()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Transient - New Instance Every Time
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Transient: NEW instance created every time the service is requested.
        // Good for: Lightweight, stateless services.
        //
        // EXERCISE: When you request a transient twice, do you get the
        //           "same" or "different" instance?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering as transient
        // ──────────────────────────────────────────────────────────────────────
        Services.AddTransient<ICounterService, CounterService>();

        var service1 = Services.GetRequiredService<ICounterService>();
        var service2 = Services.GetRequiredService<ICounterService>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are transient instances "same" or "different"?   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if instances are the same object
        // ──────────────────────────────────────────────────────────────────────
        var actual = ReferenceEquals(service1, service2) ? "same" : "different";
        Assert.Equal(answer, actual);
    }
}
