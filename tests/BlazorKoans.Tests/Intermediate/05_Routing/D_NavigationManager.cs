using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class D_NavigationManager : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_ProvidesCurrentUri()
    {
        // ABOUT: NavigationManager provides access to the current URI
        // It's injected into components that need navigation functionality

        // TODO: Replace "__" with the base URI scheme
        // HINT: bUnit uses a test URI by default

        var cut = Render<SearchPage>();
        var navManager = Services.GetRequiredService<NavigationManager>();

        var expected = "__";

        Assert.StartsWith(expected, navManager.Uri);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NavigationManager_NavigateTo()
    {
        // ABOUT: NavigationManager.NavigateTo() programmatically navigates to a URL

        // TODO: Replace "__" with the path the button navigates to
        // HINT: Look at the NavigateToHome method in SearchPage.razor

        var cut = Render<SearchPage>();
        var navManager = Services.GetRequiredService<NavigationManager>();

        var button = cut.Find("button");
        button.Click();

        var expected = "__";

        Assert.EndsWith(expected, navManager.Uri);
    }
}
