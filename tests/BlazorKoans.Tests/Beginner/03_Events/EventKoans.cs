using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.Events;

public class EventKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_BasicEvents()
    {
        // ABOUT: Event handlers in Blazor use the @onclick syntax (and similar for other events).
        // When a user clicks an element, the handler method executes.
        // This is how you make your UI interactive.

        // TODO: Look at the EventDemo component. It has increment (+) and decrement (-) buttons.
        // After these clicks, what is the final count displayed?
        // Replace "__" with the expected count as a string.

        var cut = Render<EventDemo>();

        var increment = cut.Find("button.increment");
        var decrement = cut.Find("button.decrement");

        increment.Click();
        increment.Click();
        increment.Click();
        increment.Click();
        increment.Click();

        decrement.Click();
        decrement.Click();

        var expectedCount = "3";

        Assert.Equal(expectedCount, cut.Find("span.click-count").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_EventCallback()
    {
        // ABOUT: EventCallback is used to pass event notifications from child to parent.
        // A parent component passes a handler to a child via an EventCallback parameter.
        // When the child invokes the callback, the parent's handler executes.

        // TODO: Look at ParentWithEventDemo - it contains EventDemo as a child.
        // The parent passes HandleChildClick to the child's OnButtonClick parameter.
        // When you click the "Click Me" button in the child, what message does the PARENT display?
        // Replace "__" with the message shown in <p class="parent-message">.

        var cut = Render<ParentWithEventDemo>();

        var button = cut.Find("button.event-callback-button");
        button.Click();

        var expectedParentMessage = "__";

        Assert.Equal(expectedParentMessage, cut.Find("p.parent-message").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_EventCallbackWithValue()
    {
        // ABOUT: EventCallback<T> is a typed event callback that passes a value.
        // This is useful when you need to send data along with the event notification.
        // For example, passing form data or user input to a parent component.

        // TODO: Look at ParentWithFormDemo - it contains EventDemo as a child.
        // The parent passes HandleChildSubmit to the child's OnSubmit parameter.
        // Type "Blazor" in the input and click Submit.
        // What text does the PARENT display in <p class="received-value">?
        // Replace "__" with the expected text.

        var cut = Render<ParentWithFormDemo>();

        var input = cut.Find("input[type='text']");
        input.Change("Blazor");

        var submitButton = cut.Find("button.submit-button");
        submitButton.Click();

        var expectedReceivedText = "__";

        Assert.Equal(expectedReceivedText, cut.Find("p.received-value").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_PreventDefault()
    {
        // ABOUT: @onclick:preventDefault prevents the default browser action.
        // Blazor renders this as a special attribute: blazor:onclick:preventdefault
        // This is useful for forms where you want to handle submission in Blazor
        // instead of letting the browser submit the form traditionally.

        // TODO: Look at the EventDemo component's submit button.
        // Examine the rendered HTML below - what attribute indicates preventDefault is enabled?
        // Replace "__" with the attribute name that Blazor adds for preventDefault.

        var cut = Render<EventDemo>();

        var submitButton = cut.Find("button.submit-button");

        // Hint: The rendered HTML looks like:
        // <button class="submit-button" blazor:onclick="5" ???="">Submit</button>
        var preventDefaultAttribute = "__";

        Assert.True(submitButton.HasAttribute(preventDefaultAttribute));
    }
}
