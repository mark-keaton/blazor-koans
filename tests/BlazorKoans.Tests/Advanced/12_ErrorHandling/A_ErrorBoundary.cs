using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

public class A_ErrorBoundary : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_catches_child_component_errors()
    {
        // ABOUT: ErrorBoundary is a component that catches unhandled exceptions
        // from its child components and displays error UI.

        // TODO: What component is used to catch rendering errors in Blazor?
        // Replace "__" with the component name

        var expected = "__"; // SOLUTION: "ErrorBoundary"

        Assert.Equal("ErrorBoundary", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_displays_ErrorContent_on_exception()
    {
        // ABOUT: When an error occurs, ErrorBoundary shows the ErrorContent
        // instead of the ChildContent.

        // TODO: The ErrorDemo component uses ErrorBoundary.
        // What is displayed when an error occurs?

        var cut = Render<ErrorDemo>();

        // Initially no error
        Assert.Contains("No error", cut.Markup);

        // Cause an error
        var causeErrorButton = cut.Find("button");

        // The button click will cause the component to throw
        Assert.Throws<InvalidOperationException>(() => causeErrorButton.Click());

        var expected = "__"; // SOLUTION: "Error:"

        // After error, ErrorContent should be displayed
        cut.WaitForAssertion(() =>
            Assert.Contains(expected, cut.Markup), timeout: TimeSpan.FromSeconds(2));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_provides_exception_context()
    {
        // ABOUT: The ErrorContent template receives the exception as context.

        // TODO: In ErrorDemo, the exception message is displayed.
        // What type is the context parameter?

        var expected = "__"; // SOLUTION: "Exception"

        Assert.Equal("Exception", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_prevents_app_crash()
    {
        // ABOUT: Without ErrorBoundary, unhandled exceptions crash the entire app.
        // ErrorBoundary isolates errors to the failing component.

        // TODO: Does ErrorBoundary prevent the whole app from crashing?

        var cut = Render<ErrorDemo>();

        var causeErrorButton = cut.Find("button");

        try
        {
            causeErrorButton.Click();
        }
        catch (InvalidOperationException)
        {
            // Expected - the error is thrown during render
        }

        var expected = "__"; // SOLUTION: "yes"

        // Component still exists, just shows error UI
        Assert.NotNull(cut);
        Assert.Equal("yes", expected);
    }
}
