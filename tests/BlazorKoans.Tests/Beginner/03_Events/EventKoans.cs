using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;
using Microsoft.AspNetCore.Components;

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

        // TODO: The EventDemo component has a button that increments a click count.
        // Click the button 3 times. What is the final click count?
        // Replace 0 with the expected count.

        var cut = Render<EventDemo>();

        var button = cut.Find("button.click-counter");
        button.Click();
        button.Click();
        button.Click();

        var expectedCount = 0;

        cut.MarkupMatches($@"
            <div>
                <button class=""click-counter"">Clicked: {expectedCount}</button>
                <button class=""event-callback-button"">Click Me</button>
                <p class=""message""></p>
                <input type=""text"" />
                <button class=""submit-button"">Submit</button>
                <p class=""submitted-value""></p>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_EventCallback()
    {
        // ABOUT: EventCallback is used to pass event notifications from child to parent.
        // A component can expose an EventCallback parameter that the parent can subscribe to.
        // This enables child components to communicate with their parents.

        // TODO: The EventDemo component has an EventCallback parameter called OnButtonClick.
        // When the "Click Me" button is clicked, what message is displayed?
        // Replace "__" with the expected message.

        var wasClicked = false;

        var cut = Render<EventDemo>(parameters => parameters
            .Add(p => p.OnButtonClick, EventCallback.Factory.Create(this, () => wasClicked = true)));

        var button = cut.Find("button.event-callback-button");
        button.Click();

        var expectedMessage = "__";

        Assert.True(wasClicked);
        cut.MarkupMatches($@"
            <div>
                <button class=""click-counter"">Clicked: 0</button>
                <button class=""event-callback-button"">Click Me</button>
                <p class=""message"">{expectedMessage}</p>
                <input type=""text"" />
                <button class=""submit-button"">Submit</button>
                <p class=""submitted-value""></p>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_EventCallbackWithValue()
    {
        // ABOUT: EventCallback<T> is a typed event callback that passes a value.
        // This is useful when you need to send data along with the event notification.
        // For example, passing form data or user input to a parent component.

        // TODO: The EventDemo component has an EventCallback<string> for form submission.
        // Type "test" in the input and click Submit. What value is passed to the callback?
        // Replace "__" with the expected value.

        var submittedValue = string.Empty;

        var cut = Render<EventDemo>(parameters => parameters
            .Add(p => p.OnSubmit, EventCallback.Factory.Create<string>(this, value => submittedValue = value)));

        var input = cut.Find("input[type='text']");
        input.Change("test");

        var submitButton = cut.Find("button.submit-button");
        submitButton.Click();

        var expectedValue = "__";

        Assert.Equal(expectedValue, submittedValue);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_PreventDefault()
    {
        // ABOUT: @onclick:preventDefault prevents the default browser action.
        // This is useful for forms where you want to handle submission in Blazor
        // instead of letting the browser submit the form traditionally.

        // TODO: The EventDemo component uses preventDefault on the submit button.
        // Does the component prevent the default form submission behavior?
        // Replace false with true if it prevents default, or keep false if it doesn't.

        var cut = Render<EventDemo>();

        var submitButton = cut.Find("button.submit-button");

        var preventsDefault = false;

        // The button should have @onclick:preventDefault attribute
        Assert.True(preventsDefault);
    }
}
