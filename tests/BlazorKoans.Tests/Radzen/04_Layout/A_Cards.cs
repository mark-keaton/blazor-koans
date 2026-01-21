using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                              RADZEN CARDS                                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenCard is a container component that provides a card-style layout       ║
/// ║  with optional header, footer, and styling for grouping content.             ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenCard&gt;                                                          │  ║
/// ║  │      &lt;h3&gt;Card Title&lt;/h3&gt;                                               │  ║
/// ║  │      &lt;p&gt;Card content goes here&lt;/p&gt;                                     │  ║
/// ║  │  &lt;/RadzenCard&gt;                                                         │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenCard Style="background-color: #f5f5f5;"&gt;                       │  ║
/// ║  │      Custom styled card                                                │  ║
/// ║  │  &lt;/RadzenCard&gt;                                                         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_Cards : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_RendersBasicContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenCard CSS Classes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard wraps content in a styled container. The content you place
        // inside <RadzenCard> appears in the card body. By default, it includes
        // padding and a subtle shadow. Radzen uses the "rz-" prefix for CSS classes.
        //
        // EXERCISE: What CSS class identifies a Radzen card in the DOM?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class identifies a Radzen card?        ║
        // ║                                                                    ║
        // ║  HINT: Radzen uses "rz-" prefix for its CSS classes                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The card CSS class exists in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_DisplaysCardTitle()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Card Titles
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The card displays a title that you set in the demo component. This
        // title appears in the card's header area and helps identify the card's
        // purpose to users.
        //
        // EXERCISE: What is the exact title text shown in the first card?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What title text appears in the first card?      ║
        // ║                                                                    ║
        // ║  HINT: Look at CardsDemo.razor for the title text                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The title appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithCustomStyle_AppliesStyles()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Card Styling
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard accepts a Style parameter to apply custom CSS. This lets
        // you customize colors, borders, spacing, and more. Custom styles
        // typically include properties like background-color, border, etc.
        //
        // EXERCISE: Does the demo include a card with custom styling?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include custom styled cards?      ║
        // ║                                                                    ║
        // ║  HINT: Check if any card in CardsDemo has a Style parameter        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Custom styles are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("style="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_SupportsClickEvents()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Card Click Events
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard can be made clickable by adding click event handlers. This
        // is useful for navigation cards or interactive content boxes. The demo
        // shows a click status message when a card button is clicked.
        //
        // EXERCISE: What text appears when a card is clicked?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo and click a button
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();
        Assert.DoesNotContain("Card Clicked", cut.Markup);
        
        var clickButton = cut.Find("button");
        clickButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears when a card is clicked?       ║
        // ║                                                                    ║
        // ║  HINT: The demo shows a click status message                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The click message appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithMultipleCards_RendersAll()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Cards
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can use multiple RadzenCard components on a page. Each card is
        // independent and can have different content and styling. Count the
        // cards by looking for "rz-card" elements.
        //
        // EXERCISE: How many cards are rendered in the demo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();
        var cardElements = cut.FindAll(".rz-card");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many cards are rendered?                    ║
        // ║                                                                    ║
        // ║  HINT: Count the "rz-card" elements in the output                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The expected number of cards are rendered
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cardElements.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_ContentProjection_DisplaysChildContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Content Projection (ChildContent)
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCard uses content projection (ChildContent) to render whatever
        // you place inside it. This can be text, other components, forms,
        // images, etc.
        //
        // EXERCISE: What content appears inside one of the cards?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What content appears in a card?                 ║
        // ║                                                                    ║
        // ║  HINT: Look for descriptive text in the card bodies                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The content appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_WithIcon_DisplaysIconContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Cards with Icons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Cards often include icons to make them more visual and engaging. You
        // can add icons from icon libraries or use Radzen's built-in icon
        // support with the "rz-icon" CSS class.
        //
        // EXERCISE: Does the demo include any cards with icons?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the CardsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<CardsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include cards with icons?         ║
        // ║                                                                    ║
        // ║  HINT: Look for "rz-icon" or similar icon-related CSS classes      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Icons are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Card_Accessibility_IncludesSemanticHTML()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Card Semantic HTML
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Well-structured cards should use semantic HTML for accessibility.
        // RadzenCard renders as a div element, so you should add appropriate
        // ARIA attributes or semantic elements inside as needed.
        //
        // EXERCISE: What HTML element type does RadzenCard render as?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What HTML element does RadzenCard render?       ║
        // ║                                                                    ║
        // ║  HINT: Radzen cards are typically div elements with CSS classes    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: RadzenCard renders as a div element
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("div", answer);
    }
}
