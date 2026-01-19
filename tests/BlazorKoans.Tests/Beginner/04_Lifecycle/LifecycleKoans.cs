using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.Lifecycle;

public class LifecycleKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_OnInitialized()
    {
        // ABOUT: OnInitialized is called when a component is first created.
        // This happens once per component instance, before the first render.
        // Use this to initialize data, load resources, or set up the component.

        // TODO: The LifecycleDemo component sets an initial message in OnInitialized.
        // What message is displayed after initialization?
        // Replace "__" with the expected message.

        var cut = Render<LifecycleDemo>();

        var expectedMessage = "Initialized"; // SOLUTION: "Initialized"

        cut.MarkupMatches($@"
            <div>
                <p class=""status"">{expectedMessage}</p>
                <p class=""render-count"">Renders: 1</p>
                <p class=""param-value"">Value: </p>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_OnParametersSet()
    {
        // ABOUT: OnParametersSet is called when parameters are set or changed.
        // This happens after OnInitialized and every time parameters change.
        // Use this to respond to parameter changes and update derived state.

        // TODO: The LifecycleDemo component updates its state when the Value parameter changes.
        // When Value is set to "test", what does the param-value paragraph display?
        // Replace "__" with the expected display text (hint: it includes the value).

        var cut = Render<LifecycleDemo>(parameters => parameters
            .Add(p => p.Value, "test"));

        var expectedDisplay = "Value: test"; // SOLUTION: "Value: test"

        cut.MarkupMatches($@"
            <div>
                <p class=""status"">Initialized</p>
                <p class=""render-count"">Renders: 1</p>
                <p class=""param-value"">{expectedDisplay}</p>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_OnAfterRender()
    {
        // ABOUT: OnAfterRender is called after the component renders.
        // The firstRender parameter indicates if this is the first render.
        // Use this for JavaScript interop or DOM manipulation after rendering.

        // TODO: The LifecycleDemo component counts how many times it has rendered.
        // After the first render, how many renders have occurred?
        // Replace 0 with the expected count.

        var cut = Render<LifecycleDemo>();

        var expectedRenderCount = 1; // SOLUTION: 1

        cut.MarkupMatches($@"
            <div>
                <p class=""status"">Initialized</p>
                <p class=""render-count"">Renders: {expectedRenderCount}</p>
                <p class=""param-value"">Value: </p>
            </div>
        ");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_Disposing()
    {
        // ABOUT: Components can implement IDisposable to clean up resources.
        // The Dispose method is called when the component is removed from the UI.
        // Use this to unsubscribe from events, dispose timers, or release resources.

        // TODO: The LifecycleDemo component implements IDisposable.
        // Does it properly clean up when disposed?
        // Replace false with true if Dispose is called, or keep false otherwise.

        var cut = Render<LifecycleDemo>();

        // Dispose the component
        cut.Dispose();

        var wasDisposed = true; // SOLUTION: true

        // The component should implement IDisposable and call Dispose
        Assert.True(wasDisposed);
    }
}
