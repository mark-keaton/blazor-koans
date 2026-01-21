using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    STATE CHANGE NOTIFICATIONS IN BLAZOR                      ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Components must subscribe to state changes to know when to re-render.       ║
/// ║  The pattern involves subscribing in OnInitialized and unsubscribing         ║
/// ║  in Dispose to prevent memory leaks.                                         ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  protected override void OnInitialized()                               │  ║
/// ║  │  {                                                                     │  ║
/// ║  │      StateContainer.OnChange += StateHasChanged;  // Subscribe         │  ║
/// ║  │  }                                                                     │  ║
/// ║  │                                                                        │  ║
/// ║  │  public void Dispose()                                                 │  ║
/// ║  │  {                                                                     │  ║
/// ║  │      StateContainer.OnChange -= StateHasChanged;  // Unsubscribe       │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_StateChanged : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void NotifyStateChanged_triggers_re_render()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnChange Event Triggers Re-Rendering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Components subscribe to state change notifications to know when to
        // re-render. When state container fires OnChange, subscribed components
        // call StateHasChanged() and update their UI.
        //
        // EXERCISE: After Increment(), does the component show "Cart Items: 1"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering component and incrementing state
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        stateContainer.Increment();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does UI show "Cart Items: 1" after Increment()?  ║
        // ║     HINT: ShoppingCart subscribes to OnChange and re-renders        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The component should re-render with updated count
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            Assert.Equal(answer, cut.Markup.Contains("Cart Items: 1").ToString().ToLower()));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Components_must_subscribe_in_OnInitialized()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Subscribe to State Changes in OnInitialized
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Components typically subscribe to state changes in the OnInitialized
        // lifecycle method. This ensures they receive updates as soon as they
        // are rendered.
        //
        // EXERCISE: After Increment(), does the markup change from initial?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - capturing initial markup and incrementing
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        var initialMarkup = cut.Markup;

        stateContainer.Increment();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the markup change after Increment()?        ║
        // ║     HINT: ShoppingCart subscribes in OnInitialized and receives     ║
        // ║           updates when state changes                                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The markup should be different after state change
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            Assert.NotEqual(initialMarkup, cut.Markup));

        Assert.Equal(answer, (cut.Markup != initialMarkup).ToString().ToLower());
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Components_should_unsubscribe_on_dispose()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Unsubscribe on Dispose to Prevent Memory Leaks
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Components implementing IDisposable should unsubscribe from events
        // to prevent memory leaks. If you don't unsubscribe, the event handler
        // keeps a reference to the disposed component.
        //
        // EXERCISE: After dispose, how many times does our test handler fire?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - subscribing test handler and disposing component
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        var eventsFiredAfterDispose = 0;
        stateContainer.OnChange += () => eventsFiredAfterDispose++;

        cut.Dispose();

        stateContainer.Increment();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many times does our handler fire?            ║
        // ║     HINT: After dispose, only our test handler fires (not the       ║
        // ║           component's handler), so count should be 1                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Only our test handler should fire after dispose
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, eventsFiredAfterDispose.ToString());
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Multiple_components_can_share_same_state()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Components Share the Same State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Multiple component instances can subscribe to the same state container
        // and all receive updates. When one component changes state, all others
        // see the change.
        //
        // EXERCISE: When cart1 adds an item, does cart2 also show 1 item?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering two cart instances with shared state
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cart1 = Render<ShoppingCart>();
        var cart2 = Render<ShoppingCart>();

        cart1.Find("button").Click(); // Add item in first cart

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does cart2 show "Cart Items: 1"?                  ║
        // ║     HINT: Both carts share the same state container                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Both carts should show the updated count
        // ──────────────────────────────────────────────────────────────────────
        cart2.WaitForAssertion(() =>
            Assert.Equal(answer, cart2.Markup.Contains("Cart Items: 1").ToString().ToLower()));
    }
}
