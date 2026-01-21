using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._01_GettingStarted;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                      RADZEN COMPONENT LIBRARY SETUP                          ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Radzen Blazor provides 100+ native Blazor components without JS deps.       ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // 1. Install: dotnet add package Radzen.Blazor                       │  ║
/// ║  │  // 2. Register services in Program.cs:                                │  ║
/// ║  │  builder.Services.AddRadzenComponents();                               │  ║
/// ║  │  // 3. Add CSS in App.razor:                                           │  ║
/// ║  │  <link href="_content/Radzen.Blazor/css/material.css" rel="stylesheet">│  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_RadzenSetup : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_RendersWithText()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenButton Fundamentals
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenButton is a fundamental Radzen component that renders an HTML
        // button with Radzen styling. It's the building block for interactive
        // actions in your Blazor app.
        //
        // EXERCISE: What text does the RadzenButton display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the RadzenSetupDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text does the button display?              ║
        // ║                                                                    ║
        // ║  HINT: Check the RadzenSetupDemo component to see the button text  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The button text appears in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_HasCorrectCssClass()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Radzen CSS Class Naming Convention
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Radzen components use CSS classes that start with "rz-" prefix.
        // This naming convention helps identify Radzen components and avoid
        // conflicts with other CSS frameworks.
        //
        // EXERCISE: What CSS class identifies Radzen buttons?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the RadzenSetupDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the CSS class for RadzenButton?         ║
        // ║                                                                    ║
        // ║  HINT: All Radzen components use the "rz-" prefix                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The CSS class appears in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"class=\"{answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_RendersContainer()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenCard Container Component
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard is a container component that displays content in a styled
        // card layout. It's commonly used to group related information and
        // provide visual hierarchy. Cards render as div elements.
        //
        // EXERCISE: What CSS class identifies Radzen cards?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the RadzenSetupDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the CSS class for RadzenCard?           ║
        // ║                                                                    ║
        // ║  HINT: Follow the same "rz-" naming pattern                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The CSS class appears in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"class=\"{answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_DisplaysContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenCard Content
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard displays content within a styled container. You can add
        // any HTML or Blazor components inside it, including headings,
        // paragraphs, and other Radzen components.
        //
        // EXERCISE: What is the h4 heading text inside the RadzenCard?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the RadzenSetupDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the card title text?                    ║
        // ║                                                                    ║
        // ║  HINT: Look for the h4 heading text inside the RadzenCard          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The title text appears in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCard_DisplaysBodyContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenCard ChildContent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard can contain multiple elements including paragraphs. All
        // content placed inside a RadzenCard becomes part of its ChildContent
        // RenderFragment.
        //
        // EXERCISE: What text describes how many components Radzen provides?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the RadzenSetupDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text mentions the component count?         ║
        // ║                                                                    ║
        // ║  HINT: Look for the paragraph that mentions "100+" in the demo     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The body content appears in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_CanHandleClick()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenButton Click Events
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenButton supports the Click event parameter, which you can bind
        // to a method in your component. When clicked, it triggers your event
        // handler just like a standard HTML button.
        //
        // EXERCISE: After clicking once, how many clicks should be shown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render and click the button once
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();
        var button = cut.Find("button");
        button.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the click count after one click?        ║
        // ║                                                                    ║
        // ║  HINT: The demo component tracks click count                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The click count appears in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Button clicked {answer} time", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenButton_TracksMultipleClicks()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Radzen State Management Integration
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Each click event increments the counter, demonstrating that Radzen
        // components properly integrate with Blazor's state management and
        // re-rendering lifecycle.
        //
        // EXERCISE: After clicking 3 times, what should the count be?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render and click the button three times
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenSetupDemo>();
        var button = cut.Find("button");
        button.Click();
        button.Click();
        button.Click();

        // ╔════════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the click count after three clicks?         ║
        // ╚════════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The click count appears in the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Button clicked {answer} times", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenComponents_RequireInteractiveRenderMode()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Interactive Render Mode Requirement
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Radzen components require interactive render mode to work properly.
        // This is because they use JavaScript interop for features like
        // dropdowns, dialogs, and data grids.
        //
        // EXERCISE: What render mode attribute should be used for Radzen?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the render mode attribute value?        ║
        // ║                                                                    ║
        // ║  HINT: In .NET 10 Blazor Server, use @rendermode InteractiveServer ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The render mode matches the expected value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("InteractiveServer", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenServices_MustBeRegistered()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Radzen Service Registration
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Radzen requires services to be registered in the DI container. This
        // is done by calling a specific extension method in Program.cs.
        // Without this registration, Radzen components won't function properly.
        //
        // EXERCISE: What extension method registers Radzen services?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What method registers Radzen services?          ║
        // ║                                                                    ║
        // ║  HINT: builder.Services.______() in Program.cs                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The method name matches the expected value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("AddRadzenComponents", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTheme_RequiresCssReference()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Radzen CSS Themes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Radzen components require CSS to be loaded for proper styling. The
        // CSS file should be referenced in your App.razor or layout.
        // Common themes: material, fluent, standard.
        //
        // EXERCISE: What is the base path for Radzen CSS files?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the path prefix for Radzen CSS?         ║
        // ║                                                                    ║
        // ║  HINT: Uses format "_content/PackageName"                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The path matches the expected value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("_content/Radzen.Blazor", answer);
    }
}
