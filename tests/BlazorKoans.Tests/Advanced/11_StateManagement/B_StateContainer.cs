using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.App.Services;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                   STATE CONTAINER PATTERN IN BLAZOR                          ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  A state container is a SERVICE that holds shared state for components.      ║
/// ║  Components subscribe to change events to know when to re-render.            ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  public class StateContainer                                          │  ║
/// ║  │  {                                                                    │  ║
/// ║  │      public int Count { get; private set; }                           │  ║
/// ║  │      public event Action? OnChange;                                   │  ║
/// ║  │                                                                        │  ║
/// ║  │      public void Increment()                                          │  ║
/// ║  │      {                                                                 │  ║
/// ║  │          Count++;                                                      │  ║
/// ║  │          OnChange?.Invoke();  // Notify subscribers                    │  ║
/// ║  │      }                                                                 │  ║
/// ║  │  }                                                                    │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_StateContainer : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_shares_state_across_components()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: State Containers Share State Across Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // A state container is a service registered with DI that holds shared state.
        // Multiple components can inject it and see the same data.
        //
        // EXERCISE: What is the initial count in CounterStateContainer?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating and registering the state container
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial count?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The cart should show the initial count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Cart Items: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_updates_are_shared()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: State Changes Are Visible to All Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When state changes in the container, any component using it sees the update.
        // The component subscribes to OnChange and calls StateHasChanged().
        //
        // EXERCISE: What is the count after calling Increment() once?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - incrementing the state container
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        Services.AddSingleton(stateContainer);

        var cut = Render<ShoppingCart>();

        stateContainer.Increment();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is count after Increment()?                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The cart should show the updated count
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            Assert.Contains($"Cart Items: {answer}", cut.Markup));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void StateContainer_uses_events_to_notify_changes()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Event-Based Change Notification
        // ═══════════════════════════════════════════════════════════════════════
        //
        // State containers expose an OnChange event (Action delegate).
        // Components subscribe and call StateHasChanged() when it fires.
        //
        // EXERCISE: How many times does OnChange fire when calling Increment() twice?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - subscribing to and counting change events
        // ──────────────────────────────────────────────────────────────────────
        var stateContainer = new CounterStateContainer();
        var eventCount = 0;

        stateContainer.OnChange += () => eventCount++;

        stateContainer.Increment();
        stateContainer.Increment();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many events after 2 Increment() calls?        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The event count should match Increment() calls
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, eventCount);
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

        var expected = false;

        Assert.Equal(expected, cut.Markup.Contains("Cart Items: 1"));
    }
}
