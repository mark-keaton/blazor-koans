using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

public class C_StateChanged : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void NotifyStateChanged_triggers_re_render()
    {
        // ABOUT: Components subscribe to state change notifications
        // to know when to re-render.

        // TODO: When state container fires OnChange, components re-render.
        // What pattern does ShoppingCart use?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        stateContainer.Increment();

        var expected = false;

        cut.WaitForAssertion(() =>
            Assert.Equal(expected, cut.Markup.Contains("Cart Items: 1")));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Components_must_subscribe_in_OnInitialized()
    {
        // ABOUT: Components typically subscribe to state changes
        // in OnInitialized lifecycle method.

        // TODO: The ShoppingCart subscribes to OnChange in OnInitialized.
        // Does it receive updates?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        var initialMarkup = cut.Markup;

        stateContainer.Increment();

        var expected = false;

        cut.WaitForAssertion(() =>
            Assert.NotEqual(initialMarkup, cut.Markup));

        Assert.Equal(expected, cut.Markup != initialMarkup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Components_should_unsubscribe_on_dispose()
    {
        // ABOUT: Components implementing IDisposable should unsubscribe
        // from events to prevent memory leaks.

        // TODO: ShoppingCart implements IDisposable and unsubscribes.
        // Does it properly clean up?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        var eventsFiredBeforeDispose = 0;
        stateContainer.OnChange += () => eventsFiredBeforeDispose++;

        cut.Dispose();

        stateContainer.Increment();

        var expected = "__";

        // After dispose, ShoppingCart's handler should not increment the count
        // Only our test handler fires, so count should be 1
        Assert.Equal(expected, eventsFiredBeforeDispose.ToString());
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Multiple_components_can_share_same_state()
    {
        // ABOUT: Multiple component instances can subscribe to the same
        // state container and all receive updates.

        // TODO: Create two ShoppingCart instances with shared state.
        // When one increments, do both update?

        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cart1 = Render<ShoppingCart>();
        var cart2 = Render<ShoppingCart>();

        cart1.Find("button").Click(); // Add item in first cart

        var expected = false;

        cart2.WaitForAssertion(() =>
            Assert.Equal(expected, cart2.Markup.Contains("Cart Items: 1")));
    }
}
