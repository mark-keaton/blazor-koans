using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;

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

        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>();

        var expectedMessage = "Initialized";

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

        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>(parameters => parameters
            .Add(p => p.Value, "blazor"));

        var expectedDisplay = "Received: BLAZOR";

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

        Services.AddSingleton<DisposalTracker>();
        var cut = Render<LifecycleDemo>();

        var expectedRenderCount = "1";

        Assert.Equal($"Renders: {expectedRenderCount}", cut.Find("p.render-count").TextContent);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_ImplementsIDisposable()
    {
        // ABOUT: To enable disposal in Blazor, a component must implement IDisposable.
        // In Razor components, you do this with the @implements directive.
        // Without @implements IDisposable, Blazor won't call your Dispose() method!

        // TODO: Look at LifecycleDemo.razor - it has a Dispose() method but something is missing.
        // The component needs a directive to tell Blazor it implements IDisposable.
        // Add the missing directive to the component, then this test will pass.

        // This checks if LifecycleDemo implements the IDisposable interface
        var implementsIDisposable = typeof(LifecycleDemo).IsAssignableTo(typeof(IDisposable));

        Assert.True(implementsIDisposable, "Add @implements IDisposable to LifecycleDemo.razor");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void E_DisposeIsCalled()
    {
        // ABOUT: When a component is removed from the UI, Blazor calls Dispose().
        // This is where you clean up resources like event subscriptions or timers.
        // The DisposalTracker service helps verify that cleanup actually happens.

        // TODO: Look at LifecycleDemo's OnInitialized and Dispose methods.
        // The component registers with the tracker on init and unregisters on dispose.
        // After disposing the component, is it still registered with the tracker?
        // Replace true with false if the component properly unregisters, or keep true.

        var tracker = new DisposalTracker();
        Services.AddSingleton(tracker);

        var cut = Render<LifecycleDemo>();

        // Component should be registered after rendering
        Assert.True(tracker.IsRegistered(cut.Instance));

        // Dispose the component
        cut.Dispose();

        // After disposal, is the component still registered?
        var stillRegisteredAfterDispose = false;

        Assert.False(stillRegisteredAfterDispose, "Component should unregister from tracker in Dispose()");
    }
}
