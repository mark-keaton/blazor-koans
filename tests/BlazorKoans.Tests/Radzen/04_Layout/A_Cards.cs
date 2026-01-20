using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// RadzenCard is a container component that provides a card-style layout with
/// optional header, footer, and styling. Cards are perfect for grouping related
/// content in a visually distinct container.
///
/// Think of RadzenCard as a "content box" that makes your UI look organized
/// and professional with minimal effort.
/// </summary>
public class A_Cards : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_RendersBasicContent()
    {
        // ABOUT: RadzenCard wraps content in a styled container. The content
        // you place inside <RadzenCard> appears in the card body.
        // By default, it includes padding and a subtle shadow.

        // TODO: Replace "__" with the CSS class that identifies a Radzen card
        // HINT: Radzen uses "rz-" prefix for its CSS classes

        var cut = Render<CardsDemo>();

        var expected = "rz-card";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_DisplaysCardTitle()
    {
        // ABOUT: The card displays a title that you set in the demo component.
        // This title appears in the card's header area.

        // TODO: Replace "__" with the exact title text shown in the first card
        // HINT: Look at CardsDemo.razor for the title text

        var cut = Render<CardsDemo>();

        var expected = "Simple Card";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithCustomStyle_AppliesStyles()
    {
        // ABOUT: RadzenCard accepts a Style parameter to apply custom CSS.
        // This lets you customize colors, borders, spacing, and more.

        // TODO: Replace false with true if the demo includes a card with custom styling
        // HINT: Check if any card in CardsDemo has a Style parameter

        var cut = Render<CardsDemo>();

        var hasCustomStyle = true;

        // Custom styles typically include properties like background-color, border, etc.
        Assert.True(hasCustomStyle == cut.Markup.Contains("style="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_SupportsClickEvents()
    {
        // ABOUT: RadzenCard can be made clickable by adding click event handlers.
        // This is useful for navigation cards or interactive content boxes.

        // TODO: Replace "__" with the text that appears when a card is clicked
        // HINT: The demo shows a click status message

        var cut = Render<CardsDemo>();

        // Initially no card is clicked
        Assert.DoesNotContain("Card Clicked", cut.Markup);

        // Find and click a button inside the card
        var clickButton = cut.Find("button");
        clickButton.Click();

        var expected = "Card Clicked!";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithMultipleCards_RendersAll()
    {
        // ABOUT: You can use multiple RadzenCard components on a page.
        // Each card is independent and can have different content and styling.

        // TODO: Replace 0 with the number of cards rendered in the demo
        // HINT: Count the "rz-card" elements in the output

        var cut = Render<CardsDemo>();

        var cardElements = cut.FindAll(".rz-card");
        var expected = 4;

        Assert.Equal(expected, cardElements.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_ContentProjection_DisplaysChildContent()
    {
        // ABOUT: RadzenCard uses content projection (ChildContent) to render
        // whatever you place inside it. This can be text, other components,
        // forms, images, etc.

        // TODO: Replace "__" with a piece of content that appears in a card
        // HINT: Look for descriptive text in the card bodies

        var cut = Render<CardsDemo>();

        var expected = "This is a basic RadzenCard with some content inside.";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithIcon_DisplaysIconContent()
    {
        // ABOUT: Cards often include icons to make them more visual and engaging.
        // You can add icons from icon libraries or use Radzen's icon support.

        // TODO: Does the demo include any cards with icons? Replace false with expected
        // HINT: Look for "rz-icon" or similar icon-related CSS classes

        var cut = Render<CardsDemo>();

        var hasIcon = true;

        Assert.True(hasIcon == cut.Markup.Contains("icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_Accessibility_IncludesSemanticHTML()
    {
        // ABOUT: Well-structured cards should use semantic HTML for accessibility.
        // RadzenCard renders as a div, so you should add appropriate ARIA attributes
        // or semantic elements inside as needed.

        // TODO: Replace "__" with the HTML element type that RadzenCard renders
        // HINT: Radzen cards are typically div elements with CSS classes

        var expected = "div";

        // RadzenCard renders as a specific HTML element
        Assert.Equal("div", expected);
    }
}
