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
        // What message is displayed in the status paragraph after initialization?
        // Replace "__" with the expected message.

        var cut = Render<LifecycleDemo>();

        var expectedMessage = "__";

        Assert.Equal(expectedMessage, cut.Find("p.status").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_OnParametersSet()
    {
        // ABOUT: OnParametersSet is called when parameters are set or changed.
        // This happens after OnInitialized and every time parameters change.
        // Use this to compute derived state from parameters.

        // TODO: Look at LifecycleDemo's OnParametersSet method.
        // It transforms the Value parameter into a formatted string.
        // When Value is set to "blazor", what does the param-value paragraph display?
        // Replace "__" with the expected formatted text.

        var cut = Render<LifecycleDemo>(parameters => parameters
            .Add(p => p.Value, "blazor"));

        var expectedDisplay = "__";

        Assert.Equal(expectedDisplay, cut.Find("p.param-value").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_OnAfterRender()
    {
        // ABOUT: OnAfterRender is called after the component renders.
        // The firstRender parameter indicates if this is the first render.
        // Use this for JavaScript interop or DOM manipulation after rendering.

        // TODO: The LifecycleDemo component counts how many times it has rendered.
        // Look at OnAfterRenderAsync - what render count is displayed after the first render?
        // Replace "__" with the expected count as a string.

        var cut = Render<LifecycleDemo>();

        var expectedRenderCount = "__";

        Assert.Equal($"Renders: {expectedRenderCount}", cut.Find("p.render-count").TextContent);
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

        var wasDisposed = false;

        // The component should implement IDisposable and call Dispose
        Assert.True(wasDisposed);
    }
}
