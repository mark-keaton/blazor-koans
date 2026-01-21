using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;
using BlazorKoans.Tests.Mocks;

namespace BlazorKoans.Tests.Beginner.DataBinding;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          DATA BINDING IN BLAZOR                              ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Data binding connects your C# code to the UI, keeping them in sync.         ║
/// ║  Blazor supports multiple binding patterns for different scenarios.          ║
/// ║                                                                              ║
/// ║  Key Concepts You'll Learn:                                                  ║
/// ║  1. One-way binding: Display values with @variable                           ║
/// ║  2. Two-way binding: Sync inputs with @bind="variable"                       ║
/// ║  3. Bind modifiers: Customize binding with @bind:event, @bind:format         ║
/// ║  4. Bind callbacks: React to changes with @bind:after                        ║
/// ║                                                                              ║
/// ║  Data Flow Patterns:                                                         ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  ONE-WAY:   C# variable ──────────────────────────► HTML display       │  ║
/// ║  │             @count renders the value                                   │  ║
/// ║  │                                                                        │  ║
/// ║  │  TWO-WAY:   C# variable ◄────────────────────────► Input element       │  ║
/// ║  │             @bind="text" syncs both directions                         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class DataBindingKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_OneWayBinding()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: One-Way Data Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // One-way binding displays C# values in HTML using the @ symbol.
        // Data flows ONE direction: from your code TO the UI.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @code {                                                            │
        // │      private int count = 0;          // C# variable                 │
        // │  }                                                                  │
        // │                                                                     │
        // │  <p>Count: @count</p>                // Displays: "Count: 0"        │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // When the variable changes and the component re-renders, the UI updates
        // to show the new value. The @ symbol converts C# values to strings.
        //
        // EXERCISE: The Counter component has a count variable starting at 0.
        //           Each button click calls a method that increments count.
        //           After 3 clicks, what value is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering Counter and clicking the button 3 times
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<Counter>();

        var button = cut.Find("button");
        button.Click();
        button.Click();
        button.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the expected count        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches($@"
            <div>
                <p>Count: {answer}</p>
                <button>Increment</button>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_TwoWayBinding()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Two-Way Data Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Two-way binding creates a synchronized relationship between an input
        // and a C# property. Data flows BOTH directions:
        //   - User types → property updates
        //   - Property changes → input updates
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @code {                                                            │
        // │      private string text = "";                                      │
        // │  }                                                                  │
        // │                                                                     │
        // │  <input @bind="text" />         // ← Types update 'text'            │
        // │  <p>You typed: @text</p>        // ← Shows current value            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Behind the scenes, @bind="text" expands to:
        //   value="@text" @onchange="@(e => text = e.Value)"
        //
        // EXERCISE: The BindingDemo component binds an input to a 'text' variable.
        //           We type three values in sequence. What is the FINAL value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering BindingDemo and changing input 3 times
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<BindingDemo>();

        var input = cut.Find("input");
        input.Change("Hello");
        input.Change("World");
        input.Change("Blazor!");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears after the final input.Change? ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the paragraph content
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("p.display").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_BindModifiers()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Bind Modifiers (@bind:event, @bind:format)
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can customize @bind behavior with modifiers:
        //
        // @bind:event - Changes WHEN the binding updates
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <input @bind="text" @bind:event="oninput" />                       │
        // │                                   ↑                                 │
        // │         Default is "onchange" (fires when input loses focus)        │
        // │         "oninput" fires on every keystroke                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // @bind:format - Specifies HOW to format the value (dates, numbers)
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <input type="date" @bind="date" @bind:format="yyyy-MM-dd" />       │
        // │                                              ↑                      │
        // │         Uses .NET date format strings                               │
        // │         "yyyy-MM-dd" → "2024-06-15"                                 │
        // │         "MM/dd/yyyy" → "06/15/2024"                                 │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at BindingDemo.razor's datetime input and its format.
        //           Given June 15, 2024 at 2:30 PM, what string appears?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering BindingDemo with a specific date/time
        // ──────────────────────────────────────────────────────────────────────
        var fakeTime = new FakeTimeProvider(2024, 6, 15, 14, 30);

        var cut = Render<BindingDemo>(parameters => parameters
            .Add(p => p.Time, fakeTime));

        var dateInput = cut.Find("input[type='datetime-local']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What formatted string appears in the input?     ║
        // ║                                                                    ║
        // ║  HINT: Look at the @bind:format in BindingDemo.razor               ║
        // ║        Common formats: "yyyy-MM-dd", "yyyy-MM-ddTHH:mm"            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the input's value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, dateInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_BindAfter()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: @bind:after - Reacting to Value Changes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // @bind:after executes a callback AFTER the binding updates the value.
        // This is perfect for:
        //   - Validation after user input
        //   - Triggering side effects (API calls, logging)
        //   - Computing derived values
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <input @bind="text" @bind:after="OnTextChanged" />                 │
        // │                               ↑                                     │
        // │         Called AFTER 'text' is updated                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private string text = "";                                      │
        // │      private int charCount = 0;                                     │
        // │                                                                     │
        // │      void OnTextChanged()                                           │
        // │      {                                                              │
        // │          charCount = text.Length;  // Computed from new value       │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: BindingDemo uses @bind:after to call UpdateCharacterCount.
        //           When you type "test", what count is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering BindingDemo and typing "test"
        // ──────────────────────────────────────────────────────────────────────
        var fakeTime = new FakeTimeProvider(2024, 6, 15, 14, 30);

        var cut = Render<BindingDemo>(parameters => parameters
            .Add(p => p.Time, fakeTime));

        var input = cut.Find("input");
        input.Change("test");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many characters are in "test"?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the displayed count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Characters: {answer}", cut.Markup);
    }
}
