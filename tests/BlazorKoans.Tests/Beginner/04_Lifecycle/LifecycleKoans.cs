using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorKoans.Tests.Beginner.Lifecycle;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                      COMPONENT LIFECYCLE IN BLAZOR                           ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Blazor components have a lifecycle - a series of methods called at          ║
/// ║  specific points from creation to disposal. Understanding this helps         ║
/// ║  you initialize data, react to changes, and clean up resources.              ║
/// ║                                                                              ║
/// ║  The Lifecycle Flow:                                                         ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │                                                                        │  ║
/// ║  │   Component Created                                                    │  ║
/// ║  │         │                                                              │  ║
/// ║  │         ▼                                                              │  ║
/// ║  │   OnInitialized[Async]()    ← Called ONCE when component starts        │  ║
/// ║  │         │                                                              │  ║
/// ║  │         ▼                                                              │  ║
/// ║  │   OnParametersSet[Async]()  ← Called when parameters change            │  ║
/// ║  │         │                                                              │  ║
/// ║  │         ▼                                                              │  ║
/// ║  │   Render                                                               │  ║
/// ║  │         │                                                              │  ║
/// ║  │         ▼                                                              │  ║
/// ║  │   OnAfterRender[Async]()    ← Called AFTER DOM is updated              │  ║
/// ║  │         │                                                              │  ║
/// ║  │         ▼                                                              │  ║
/// ║  │   Dispose()                 ← Called when component is removed         │  ║
/// ║  │                                                                        │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class LifecycleKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_OnInitialized()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnInitialized - Component Startup
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnInitialized runs ONCE when a component is first created.
        // This is the place to:
        //   - Set initial values
        //   - Subscribe to events
        //   - Start loading data
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @code {                                                            │
        // │      private string message = "";                                   │
        // │                                                                     │
        // │      protected override void OnInitialized()                        │
        // │      {                                                              │
        // │          message = "Component initialized!";                        │
        // │      }                                                              │
        // │                                                                     │
        // │      // Or async version for loading data:                          │
        // │      protected override async Task OnInitializedAsync()             │
        // │      {                                                              │
        // │          data = await LoadDataAsync();                              │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at LifecycleDemo's OnInitialized method.
        //           What message does it set in the status property?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - adding required services and rendering
        // ──────────────────────────────────────────────────────────────────────
        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What message is set in OnInitialized?           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the status paragraph
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("p.status").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_OnParametersSet()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnParametersSet - Reacting to Parameter Changes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnParametersSet is called:
        //   1. After OnInitialized (with initial parameter values)
        //   2. Every time a parent changes the component's parameters
        //
        // Use this to compute "derived state" - values calculated from parameters.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @code {                                                            │
        // │      [Parameter]                                                    │
        // │      public string Name { get; set; } = "";                         │
        // │                                                                     │
        // │      private string formattedName = "";   // Derived state          │
        // │                                                                     │
        // │      protected override void OnParametersSet()                      │
        // │      {                                                              │
        // │          // Runs after OnInitialized AND on every param change      │
        // │          formattedName = $"Hello, {Name.ToUpper()}!";               │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: LifecycleDemo transforms the Value parameter in OnParametersSet.
        //           When Value is "blazor", what formatted string is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering with Value="blazor"
        // ──────────────────────────────────────────────────────────────────────
        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>(parameters => parameters
            .Add(p => p.Value, "blazor"));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What formatted string does OnParametersSet      ║
        // ║                    produce from "blazor"?                          ║
        // ║                                                                    ║
        // ║  HINT: Look at the transformation in OnParametersSet               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the param-value paragraph
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Find("p.param-value").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_OnAfterRender()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnAfterRender - Working with the DOM
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnAfterRender runs AFTER Blazor has updated the DOM.
        // This is the only safe place to:
        //   - Call JavaScript interop (DOM exists now)
        //   - Measure DOM elements
        //   - Initialize JS libraries (charts, maps, etc.)
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @code {                                                            │
        // │      private int renderCount = 0;                                   │
        // │                                                                     │
        // │      protected override void OnAfterRender(bool firstRender)        │
        // │      {                                            ↑                 │
        // │          renderCount++;      // true only on first render           │
        // │                                                                     │
        // │          if (firstRender)                                           │
        // │          {                                                          │
        // │              // One-time setup: focus input, init JS library        │
        // │          }                                                          │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // ⚠️  Be careful: changing state in OnAfterRender causes a re-render,
        //     which calls OnAfterRender again → potential infinite loop!
        //
        // EXERCISE: LifecycleDemo tracks renderCount. After the first render,
        //           what count is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the component
        // ──────────────────────────────────────────────────────────────────────
        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the render count after first render?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the render count display
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal($"Renders: {answer}", cut.Find("p.render-count").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_ImplementsIDisposable()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Implementing IDisposable in Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // To clean up resources when a component is removed, implement IDisposable.
        // In .razor files, you MUST use the @implements directive - just having
        // a Dispose() method isn't enough!
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @implements IDisposable       ← REQUIRED! Tells Blazor to call     │
        // │                                  Dispose() when component removed   │
        // │                                                                     │
        // │  <p>Some content</p>                                                │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private Timer? timer;                                          │
        // │                                                                     │
        // │      protected override void OnInitialized()                        │
        // │      {                                                              │
        // │          timer = new Timer(Tick, null, 0, 1000);                    │
        // │      }                                                              │
        // │                                                                     │
        // │      public void Dispose()     ← Called when component removed      │
        // │      {                                                              │
        // │          timer?.Dispose();     // Clean up resources!               │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Without @implements IDisposable:
        //   ❌ Dispose() method exists but NEVER gets called
        //   ❌ Resources leak (timers keep running, events stay subscribed)
        //
        // EXERCISE: Open LifecycleDemo.razor and add the missing @implements directive.
        //           This is a "fix the code" exercise, not a fill-in-the-blank!
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE & VERIFY: Check if the component implements IDisposable
        // ──────────────────────────────────────────────────────────────────────
        var implementsIDisposable = typeof(LifecycleDemo).IsAssignableTo(typeof(IDisposable));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ACTION - Edit LifecycleDemo.razor, add this directive:   ║
        // ║                                                                    ║
        // ║      @implements IDisposable                                       ║
        // ║                                                                    ║
        // ║  Add it near the top of the file, after any @page directives       ║
        // ╚════════════════════════════════════════════════════════════════════╝

        Assert.True(implementsIDisposable, "Add @implements IDisposable to LifecycleDemo.razor");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void E_DisposeIsCalled()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Verifying Dispose() Works Correctly
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Dispose() is where you clean up resources:
        //   - Unsubscribe from events
        //   - Stop timers
        //   - Release unmanaged resources
        //   - Unregister from services
        //
        // A common pattern is to register with a service on init and unregister
        // on dispose. The DisposalTracker service demonstrates this:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @inject DisposalTracker Tracker                                    │
        // │                                                                     │
        // │  @code {                                                            │
        // │      protected override void OnInitialized()                        │
        // │      {                                                              │
        // │          Tracker.Register(this);    // ← Register on startup        │
        // │      }                                                              │
        // │                                                                     │
        // │      public void Dispose()                                          │
        // │      {                                                              │
        // │          Tracker.Unregister(this);  // ← Unregister on cleanup      │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // If Dispose() works correctly, the component should NOT be registered
        // with the tracker after disposal.
        //
        // EXERCISE: After disposal, is the component still registered?
        //           Change the answer to reflect what SHOULD happen.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating tracker, rendering component
        // ──────────────────────────────────────────────────────────────────────
        var tracker = new DisposalTracker();
        Services.AddSingleton(tracker);

        var cut = Render<LifecycleDemo>();

        // Component should be registered after rendering
        Assert.True(tracker.IsRegistered(cut.Instance));

        // Dispose the component
        cut.Dispose();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the component still registered after dispose?║
        // ║                                                                    ║
        // ║  If Dispose() correctly unregisters, what should this be?          ║
        // ║  Change 'true' to 'false' if unregistration works correctly.       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = true;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The component should NOT be registered after proper disposal
        // ──────────────────────────────────────────────────────────────────────
        Assert.False(answer, "Component should unregister from tracker in Dispose()");
    }
}
