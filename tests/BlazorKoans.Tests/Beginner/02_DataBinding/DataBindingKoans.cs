using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.DataBinding;

public class DataBindingKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_OneWayBinding()
    {
        // ABOUT: One-way data binding uses @ to display a value from code.
        // The syntax @variableName renders the value into the HTML.
        // When the variable changes and the component re-renders, the display updates.

        // TODO: Look at the Counter component to understand how it works.
        // After clicking the button 3 times, what count value is displayed?
        // Replace "__" with the expected count as a string.

        var cut = Render<Counter>();

        var button = cut.Find("button");
        button.Click();
        button.Click();
        button.Click();

        var expectedCount = "3";

        cut.MarkupMatches($@"
            <div>
                <p>Count: {expectedCount}</p>
                <button>Increment</button>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_TwoWayBinding()
    {
        // ABOUT: Two-way data binding uses @bind to connect an input to a property.
        // Changes to the input update the property, and changes to the property
        // update the input. This creates a synchronized relationship.

        // TODO: Look at the BindingDemo component. The input uses @bind="text" and
        // a paragraph displays the same variable with @text.
        // After these input changes, what text appears in the paragraph?
        // Replace "__" with the final displayed text.

        var cut = Render<BindingDemo>();

        var input = cut.Find("input");
        input.Change("Hello");
        input.Change("World");
        input.Change("Blazor!");

        var paragraphText = "Blazor!";

        Assert.Equal(paragraphText, cut.Find("p.display").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_BindModifiers()
    {
        // ABOUT: @bind can be customized with modifiers:
        // - @bind:event changes when the binding updates (default is "onchange")
        // - @bind:format specifies how to format the value (useful for dates/numbers)

        // TODO: The BindingDemo component has a datetime input with formatting.
        // What format string is used for displaying the date?
        // Replace "__" with the format string (e.g., "yyyy-MM-dd").

        var cut = Render<BindingDemo>();

        var dateInput = cut.Find("input[type='datetime-local']");

        var expectedFormatString = "yyyy-MM-ddTHH:mm";

        // The component should use this format for the datetime-local input
        Assert.NotNull(dateInput);
        Assert.Equal(expectedFormatString, "yyyy-MM-ddTHH:mm");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_BindAfter()
    {
        // ABOUT: @bind:after executes a callback after the binding updates.
        // This is useful for performing actions when a value changes,
        // like validation, logging, or triggering other updates.

        // TODO: The BindingDemo component updates a character count after text changes.
        // When you type "test" (4 characters), what is the character count displayed?
        // Replace "__" with the expected count.

        var cut = Render<BindingDemo>();

        var input = cut.Find("input");
        input.Change("test");

        var expectedCount = "4";

        // Check the character count display
        Assert.Contains($"Characters: {expectedCount}", cut.Markup);
    }
}
