using Bunit;
using BlazorKoans.App.Components.Exercises.Radzen;
using Xunit;

namespace BlazorKoans.Tests.Radzen._01_GettingStarted;

/// <summary>
/// Radzen Blazor is a component library providing 100+ native Blazor components
/// without JavaScript dependencies. It includes forms, data grids, charts, and more.
///
/// Getting started with Radzen requires:
/// 1. Installing the Radzen.Blazor NuGet package
/// 2. Adding Radzen services to DI container
/// 3. Including Radzen CSS in your app
/// 4. Using Radzen components in your pages
///
/// This koan verifies that Radzen is properly configured and working.
/// </summary>
public class A_RadzenSetup : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_RendersWithText()
    {
        // ABOUT: RadzenButton is a fundamental Radzen component that renders
        // an HTML button with Radzen styling. It's the building block for
        // interactive actions in your Blazor app.
        //
        // The button should display the text we provide to it.

        // TODO: Replace "__" with the expected button text
        // HINT: Check the RadzenSetupDemo component to see what text the button displays

        var cut = Render<RadzenSetupDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_HasCorrectCssClass()
    {
        // ABOUT: Radzen components use CSS classes that start with "rz-" prefix.
        // This naming convention helps identify Radzen components and avoid conflicts
        // with other CSS frameworks.
        //
        // The RadzenButton component applies the base "rz-button" class.

        // TODO: Replace "__" with the CSS class that identifies Radzen buttons
        // HINT: All Radzen components use the "rz-" prefix

        var cut = Render<RadzenSetupDemo>();

        var expected = "__";

        Assert.Contains($"class=\"{expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_RendersContainer()
    {
        // ABOUT: RadzenCard is a container component that displays content
        // in a styled card layout. It's commonly used to group related information
        // and provide visual hierarchy.
        //
        // Cards render as div elements with Radzen-specific CSS classes.

        // TODO: Replace "__" with the CSS class for Radzen cards
        // HINT: Follow the same "rz-" naming pattern

        var cut = Render<RadzenSetupDemo>();

        var expected = "__";

        Assert.Contains($"class=\"{expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_DisplaysHeader()
    {
        // ABOUT: RadzenCard can have a header section using the CardHeader
        // RenderFragment parameter. This creates a visually distinct title area.
        //
        // The header text should be visible in the rendered output.

        // TODO: Replace "__" with the card header text from RadzenSetupDemo
        // HINT: Look for the text inside the CardHeader section

        var cut = Render<RadzenSetupDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_DisplaysBodyContent()
    {
        // ABOUT: The main content of a RadzenCard goes in the ChildContent
        // RenderFragment. This is where you place paragraphs, lists, forms,
        // or any other content you want in the card.

        // TODO: Replace "__" with the welcome message from the card body
        // HINT: It's the first line of text in the ChildContent

        var cut = Render<RadzenSetupDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_CanHandleClick()
    {
        // ABOUT: RadzenButton supports the Click event parameter, which you
        // can bind to a method in your component. When clicked, it triggers
        // your event handler just like a standard HTML button.
        //
        // The demo component tracks click count to demonstrate this.

        // TODO: After clicking the button, how many clicks should be shown?
        // Replace 0 with the expected count

        var cut = Render<RadzenSetupDemo>();

        // Find and click the button
        var button = cut.Find("button");
        button.Click();

        var expected = 0;

        Assert.Contains($"Button clicked {expected} time", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_TracksMultipleClicks()
    {
        // ABOUT: Each click event increments the counter, demonstrating
        // that Radzen components properly integrate with Blazor's state
        // management and re-rendering lifecycle.

        // TODO: After clicking 3 times, what should the count be?

        var cut = Render<RadzenSetupDemo>();

        var button = cut.Find("button");
        button.Click();
        button.Click();
        button.Click();

        var expected = 0;

        Assert.Contains($"Button clicked {expected} times", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenComponents_RequireInteractiveRenderMode()
    {
        // ABOUT: Radzen components require interactive render mode to work
        // properly. This is because they use JavaScript interop for features
        // like dropdowns, dialogs, and data grids.
        //
        // In .NET 10 Blazor Server, use @rendermode InteractiveServer.

        // TODO: What render mode attribute should be on components using Radzen?
        // Replace "__" with the attribute value (e.g., "InteractiveServer")

        var expected = "__";

        Assert.Equal("InteractiveServer", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenServices_MustBeRegistered()
    {
        // ABOUT: Radzen requires services to be registered in the DI container.
        // This is done by calling AddRadzenComponents() in Program.cs.
        //
        // Without this registration, Radzen components won't function properly.

        // TODO: What extension method registers Radzen services?
        // Replace "__" with the method name

        var expected = "__";

        Assert.Equal("AddRadzenComponents", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTheme_RequiresCssReference()
    {
        // ABOUT: Radzen components require CSS to be loaded for proper styling.
        // The CSS file should be referenced in your App.razor or layout.
        //
        // Common themes include:
        // - material (Material Design)
        // - fluent (Microsoft Fluent)
        // - standard (Radzen default)

        // TODO: What is the base path for Radzen CSS files?
        // Replace "__" with the path prefix (e.g., "_content/PackageName")

        var expected = "__";

        Assert.Equal("_content/Radzen.Blazor", expected);
    }
}
