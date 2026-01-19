using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.Components;

public class ComponentKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_CreatingComponents()
    {
        // ABOUT: Components are the building blocks of Blazor applications.
        // A component is a self-contained chunk of UI that can render HTML markup.
        // The simplest component just returns static HTML.

        // TODO: Look at the HelloWorld component in src/BlazorKoans.App/Components/Exercises/Beginner/
        // Find what text it displays and replace "__" below with that text.

        var cut = Render<HelloWorld>();

        var expected = "Hello, Blazor!"; // SOLUTION: "Hello, Blazor!"

        cut.MarkupMatches($"<h1>{expected}</h1>");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_ComponentParameters()
    {
        // ABOUT: Components can accept parameters using the [Parameter] attribute.
        // Parameters allow you to pass data into a component from its parent.
        // This makes components reusable with different data.

        // TODO: The Greeting component accepts a Name parameter.
        // Pass "World" as the Name parameter to make this test pass.
        // Replace "__" with the correct parameter value.

        var parameterValue = "World"; // SOLUTION: "World"

        var cut = Render<Greeting>(parameters => parameters
            .Add(p => p.Name, parameterValue));

        cut.MarkupMatches("<p>Hello, World!</p>");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_ChildContent()
    {
        // ABOUT: Components can accept child content using RenderFragment.
        // The ChildContent parameter is a special convention that lets you
        // pass markup between the component's opening and closing tags.

        // TODO: Look at the Card component. It wraps its ChildContent in something.
        // What is the FULL HTML output when Card receives "<p>This is card content</p>"?
        // Replace "__" with the complete expected markup.

        var cut = Render<Card>(parameters => parameters
            .AddChildContent("<p>This is card content</p>"));

        var expectedMarkup = @"<div class=""card""><p>This is card content</p></div>";

        cut.MarkupMatches(expectedMarkup);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_RenderFragments()
    {
        // ABOUT: RenderFragment<T> is a typed render fragment that receives a parameter.
        // This is useful for creating template components like lists where each
        // item needs to be rendered with custom markup.

        // TODO: The ItemList component uses RenderFragment<string> to render each item.
        // It renders a list of fruits. What HTML tag surrounds each item?
        // Replace "__" with the tag name (e.g., "li", "div", "span").

        var items = new[] { "Apple", "Banana", "Orange" };

        var cut = Render<ItemList<string>>(parameters => parameters
            .Add(p => p.Items, items)
            .Add(p => p.ItemTemplate, item => $"<li>{item}</li>"));

        var tagName = "ul"; // SOLUTION: "ul"

        cut.MarkupMatches($@"<{tagName}>
            <li>Apple</li>
            <li>Banana</li>
            <li>Orange</li>
        </{tagName}>");
    }
}
