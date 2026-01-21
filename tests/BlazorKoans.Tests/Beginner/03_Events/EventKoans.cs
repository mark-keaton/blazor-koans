using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.Events;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          EVENT HANDLING IN BLAZOR                            ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Events make your Blazor UI interactive. When users click, type, or          ║
/// ║  interact with elements, event handlers execute your C# code.                ║
/// ║                                                                              ║
/// ║  Key Concepts You'll Learn:                                                  ║
/// ║  1. Basic events: @onclick, @onchange, @oninput, @onsubmit, etc.            ║
/// ║  2. EventCallback: Notify parent components of child events                  ║
/// ║  3. EventCallback&lt;T&gt;: Pass data with event notifications                     ║
/// ║  4. Event modifiers: @onclick:preventDefault, @onclick:stopPropagation       ║
/// ║                                                                              ║
/// ║  Event Handler Syntax:                                                       ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;button @onclick="HandleClick"&gt;Click Me&lt;/button&gt;                       │  ║
/// ║  │                    ↑                                                   │  ║
/// ║  │          Method name (no parentheses!)                                 │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      void HandleClick() { /* do something */ }                         │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class EventKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_BasicEvents()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Basic Click Events
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The @onclick directive attaches a click handler to an element.
        // When clicked, Blazor calls your C# method.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <button @onclick="Increment">+</button>                            │
        // │  <button @onclick="Decrement">-</button>                            │
        // │  <span>@count</span>                                                │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private int count = 0;                                         │
        // │      void Increment() => count++;                                   │
        // │      void Decrement() => count--;                                   │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Other common events: @onchange, @oninput, @onsubmit, @onmouseover
        //
        // EXERCISE: EventDemo has increment and decrement buttons.
        //           5 increments, then 2 decrements = what final count?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering EventDemo and clicking buttons
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is 5 increments minus 2 decrements?        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the displayed count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("span.click-count").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_EventCallback()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: EventCallback - Child-to-Parent Communication
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EventCallback lets a child component notify its parent of events.
        // It's like a "reverse parameter" - data flows UP from child to parent.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // CHILD: ChildButton.razor                                        │
        // │  <button @onclick="OnClick">Click Me</button>                       │
        // │                                                                     │
        // │  @code {                                                            │
        // │      [Parameter]                                                    │
        // │      public EventCallback OnButtonClick { get; set; }               │
        // │                       ↑                                             │
        // │         Parent provides the handler                                 │
        // │                                                                     │
        // │      async Task OnClick() => await OnButtonClick.InvokeAsync();     │
        // │  }                              ↑                                   │
        // │                                 Calls parent's handler              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // PARENT: uses the child component                                │
        // │  <ChildButton OnButtonClick="HandleChildClick" />                   │
        // │                             ↑                                       │
        // │         Pass the handler method                                     │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void HandleChildClick() { message = "Child was clicked!"; }    │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at ParentWithEventDemo - what message does HandleChildClick set?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering parent, clicking child's button
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ParentWithEventDemo>();

        var button = cut.Find("button.event-callback-button");
        button.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What message does the PARENT display?           ║
        // ║                                                                    ║
        // ║  HINT: Look at ParentWithEventDemo's HandleChildClick method       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the parent's message
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("p.parent-message").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_EventCallbackWithValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: EventCallback<T> - Passing Data to Parent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EventCallback<T> is a TYPED callback that sends a value to the parent.
        // Use it when the parent needs data from the child, not just notification.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // CHILD: with typed EventCallback                                 │
        // │  <input @bind="inputText" />                                        │
        // │  <button @onclick="Submit">Submit</button>                          │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private string inputText = "";                                 │
        // │                                                                     │
        // │      [Parameter]                                                    │
        // │      public EventCallback<string> OnSubmit { get; set; }            │
        // │                          ↑                                          │
        // │         The type of data being sent (string, int, object, etc.)     │
        // │                                                                     │
        // │      async Task Submit() => await OnSubmit.InvokeAsync(inputText);  │
        // │  }                                                  ↑               │
        // │                                         Pass the value here         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // PARENT: receives the typed value                                │
        // │  <ChildForm OnSubmit="HandleSubmit" />                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private string receivedText = "";                              │
        // │                                                                     │
        // │      void HandleSubmit(string value)    // ← Receives the string    │
        // │      {                                                              │
        // │          receivedText = value;                                      │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Type "Blazor" and submit. What does the parent display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering parent, typing in child, clicking submit
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ParentWithFormDemo>();

        var input = cut.Find("input[type='text']");
        input.Change("Blazor");

        var submitButton = cut.Find("button.submit-button");
        submitButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What value does the PARENT receive and display? ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the parent's display
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("p.received-value").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_PreventDefault()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Event Modifiers (@onclick:preventDefault)
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Sometimes you need to prevent the browser's default behavior:
        //   - Form submit: Prevent page reload, handle in Blazor instead
        //   - Link click: Prevent navigation, do custom routing
        //   - Right-click: Prevent context menu, show custom menu
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // Without preventDefault - browser submits form traditionally     │
        // │  <form>                                                             │
        // │      <button type="submit">Submit</button>                          │
        // │  </form>                                                            │
        // │                                                                     │
        // │  // With preventDefault - Blazor handles it, no page reload         │
        // │  <form>                                                             │
        // │      <button @onclick="HandleSubmit"                                │
        // │              @onclick:preventDefault>Submit</button>                │
        // │  </form>            ↑                                               │
        // │         This modifier prevents the default action                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Rendered HTML includes a special attribute that Blazor recognizes:
        //   <button blazor:onclick:preventDefault="">Submit</button>
        //
        // Other modifiers: @onclick:stopPropagation (prevents event bubbling)
        //
        // EXERCISE: Look at the rendered HTML. What attribute name indicates
        //           that preventDefault is enabled?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering EventDemo, finding the submit button
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<EventDemo>();

        var submitButton = cut.Find("button.submit-button");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the attribute name for preventDefault?  ║
        // ║                                                                    ║
        // ║  HINT: The rendered HTML looks like:                               ║
        // ║        <button class="submit-button" ???="">Submit</button>        ║
        // ║        Format: blazor:eventname:modifier                           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks that the button has this attribute
        // ──────────────────────────────────────────────────────────────────────
        Assert.True(submitButton.HasAttribute(answer));
    }
}
