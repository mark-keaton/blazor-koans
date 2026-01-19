using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

public class B_StateContainer : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_shares_state_across_components()
    {
        // ABOUT: A state container is a service that holds shared state
        // accessible to multiple components.

        // TODO: Create a CounterStateContainer and inject it into ShoppingCart.
        // What is the initial count?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        var expected = 0; // SOLUTION: 0

        Assert.Contains($"Cart Items: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_updates_are_shared()
    {
        // ABOUT: When state in the container changes, all components
        // using it can see the update.

        // TODO: Call Increment() on the state container.
        // What is the new count?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        stateContainer.Increment();

        var expected = 0; // SOLUTION: 1

        cut.WaitForAssertion(() =>
            Assert.Contains($"Cart Items: {expected}", cut.Markup));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_uses_events_to_notify_changes()
    {
        // ABOUT: State containers use events (like OnChange) to notify
        // components when state changes.

        // TODO: Subscribe to OnChange event in the state container.
        // How many times does it fire when Increment is called?

        var stateContainer = new CounterStateContainer();
        var eventCount = 0;

        stateContainer.OnChange += () => eventCount++;

        stateContainer.Increment();
        stateContainer.Increment();

        var expected = 0; // SOLUTION: 2

        Assert.Equal(expected, eventCount);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Components_must_call_StateHasChanged()
    {
        // ABOUT: When state container changes, components should call
        // StateHasChanged() to trigger re-rendering.

        // TODO: The ShoppingCart component subscribes to OnChange.
        // Does it call StateHasChanged when the event fires?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        cut.Find("button").Click(); // Clicks "Add Item"

        var expected = false; // SOLUTION: true

        Assert.Equal(expected, cut.Markup.Contains("Cart Items: 1"));
    }
}
