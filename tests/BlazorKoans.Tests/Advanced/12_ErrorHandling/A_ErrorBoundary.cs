using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                   ERROR BOUNDARY COMPONENT IN BLAZOR                         ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  ErrorBoundary catches unhandled exceptions from child components and        ║
/// ║  displays error UI instead of crashing the entire app.                       ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;ErrorBoundary&gt;                                                     │  ║
/// ║  │      &lt;ChildContent&gt;                                                  │  ║
/// ║  │          &lt;ComponentThatMightFail /&gt;                                   │  ║
/// ║  │      &lt;/ChildContent&gt;                                                 │  ║
/// ║  │      &lt;ErrorContent Context="ex"&gt;                                      │  ║
/// ║  │          &lt;p&gt;Oops! @ex.Message&lt;/p&gt;                                     │  ║
/// ║  │      &lt;/ErrorContent&gt;                                                 │  ║
/// ║  │  &lt;/ErrorBoundary&gt;                                                    │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_ErrorBoundary : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_catches_child_component_errors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Catching Rendering Errors
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Blazor provides a built-in component for catching and handling errors.
        // It wraps child content and displays alternate UI when exceptions occur.
        //
        // EXERCISE: What is the name of this component?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What component catches rendering errors?          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The component is "ErrorBoundary"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("ErrorBoundary", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_displays_ErrorContent_on_exception()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ErrorContent Shows When Errors Occur
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ErrorBoundary has two slots: ChildContent (normal) and ErrorContent (error).
        // When an exception occurs, ErrorContent replaces ChildContent.
        //
        // EXERCISE: Look at ErrorDemo - what text appears when an error occurs?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and triggering an error
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ErrorDemo>();

        // Initially no error
        Assert.Contains("No error", cut.Markup);

        // Cause an error
        var causeErrorButton = cut.Find("button");

        // The button click will cause the component to throw
        Assert.Throws<InvalidOperationException>(() => causeErrorButton.Click());

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the error UI?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: After error, ErrorContent should be displayed
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            Assert.Contains(answer, cut.Markup), timeout: TimeSpan.FromSeconds(2));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_provides_exception_context()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ErrorContent Receives the Exception as Context
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The ErrorContent template receives the exception object.
        // You can access ex.Message, ex.StackTrace, etc. in the template.
        //
        // EXERCISE: What is the type of the Context parameter in ErrorContent?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What type is the context parameter?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The context type is "Exception"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Exception", answer);
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

        var expected = "__";

        // Component still exists, just shows error UI
        Assert.NotNull(cut);
        Assert.Equal("yes", expected);
    }
}
