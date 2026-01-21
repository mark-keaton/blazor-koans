using Bunit;
using Bunit.TestDoubles;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          NAVIGATION MANAGER                                  ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  NavigationManager is Blazor's service for programmatic navigation.          ║
/// ║  Use it to navigate in code, get the current URL, or respond to changes.     ║
/// ║                                                                              ║
/// ║  Key methods and properties:                                                 ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  NavigateTo("/path")     → Navigate to a URL                         │  ║
/// ║  │  Uri                      → Current absolute URL                       │  ║
/// ║  │  BaseUri                  → Base URL of the app                        │  ║
/// ║  │  LocationChanged event    → Fires when URL changes                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_NavigationManager : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_IsInjectedWithDirective()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Injecting NavigationManager
        // ═══════════════════════════════════════════════════════════════════════
        //
        // NavigationManager is a built-in Blazor service. Inject it like any service:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @inject NavigationManager Navigation                                │
        // │                             ↑                                        │
        // │                 Property name for use in component                   │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void GoHome() => Navigation.NavigateTo("/");                   │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // bUnit automatically provides a fake NavigationManager for testing.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE & VERIFY: NavigationManager is available
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<SearchPage>();

        var navManager = Services.GetRequiredService<NavigationManager>();
        Assert.NotNull(navManager);
        Assert.Contains("localhost", navManager.Uri);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_NavigateTo()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Programmatic Navigation with NavigateTo()
        // ═══════════════════════════════════════════════════════════════════════
        //
        // NavigateTo() navigates to a URL from C# code (not a link click).
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  void NavigateToHome()                                              │
        // │  {                                                                  │
        // │      Navigation.NavigateTo("/");   ← Navigate to home               │
        // │  }                                                                  │
        // │                                                                     │
        // │  Options:                                                           │
        // │    NavigateTo("/path", forceLoad: true)  ← Full page reload         │
        // │    NavigateTo("/path", replace: true)    ← Replace history entry    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Add Navigation.NavigateTo("/") to NavigateToHome method
        //           in SearchPage.razor (this is a code modification exercise)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and clicking the navigation button
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<SearchPage>();
        var navManager = Services.GetRequiredService<BunitNavigationManager>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ACTION - Add this code to SearchPage.razor:              ║
        // ║                                                                    ║
        // ║      void NavigateToHome()                                         ║
        // ║      {                                                             ║
        // ║          Navigation.NavigateTo("/");                               ║
        // ║      }                                                             ║
        // ╚════════════════════════════════════════════════════════════════════╝

        var button = cut.Find("button");
        button.Click();

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Navigation history should show navigation to "/"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Single(navManager.History);
        Assert.Equal("/", navManager.History.First().Uri);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_HistoryTracksAllNavigations()
    {
        // ABOUT: bUnit's BunitNavigationManager tracks all NavigateTo calls in History.
        // Each entry records the URI that was navigated to.
        // This lets you verify navigation behavior in tests.

        // TODO: This test clicks the button twice. After adding NavigateTo("/") to NavigateToHome,
        // the History should contain two navigation entries.

        var cut = Render<SearchPage>();
        var navManager = Services.GetRequiredService<BunitNavigationManager>();

        var button = cut.Find("button");
        button.Click();
        button.Click();

        // History should have two entries from the two button clicks
        Assert.Equal(2, navManager.History.Count);
    }
}
