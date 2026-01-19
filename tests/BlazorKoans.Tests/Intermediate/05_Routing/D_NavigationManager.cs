using Bunit;
using Bunit.TestDoubles;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class D_NavigationManager : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_IsInjectedWithDirective()
    {
        // ABOUT: NavigationManager is injected into components using @inject.
        // The syntax is: @inject NavigationManager PropertyName
        // This gives the component access to navigation functionality.

        // TODO: Look at SearchPage.razor's @inject directive.
        // What property name is NavigationManager injected as?

        var cut = Render<SearchPage>();

        // The component should have access to NavigationManager via the injected property
        // bUnit provides a fake NavigationManager automatically
        var navManager = Services.GetRequiredService<NavigationManager>();
        Assert.NotNull(navManager);
        Assert.Contains("localhost", navManager.Uri);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_NavigateTo()
    {
        // ABOUT: NavigationManager.NavigateTo() programmatically navigates to a URL.
        // When called, bUnit's fake NavigationManager records the navigation in History.

        // TODO: In SearchPage.razor, add Navigation.NavigateTo("/") to the NavigateToHome method.
        // This will navigate to the home page when the button is clicked.

        var cut = Render<SearchPage>();
        var navManager = Services.GetRequiredService<BunitNavigationManager>();

        var button = cut.Find("button");
        button.Click();

        // After clicking, the navigation history should contain a navigation to "/"
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
