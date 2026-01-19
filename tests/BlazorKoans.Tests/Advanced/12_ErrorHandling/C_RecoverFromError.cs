using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

public class C_RecoverFromError : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_Recover_resets_error_state()
    {
        // ABOUT: ErrorBoundary.Recover() method resets the error state
        // and re-renders the ChildContent.

        // TODO: What method resets an ErrorBoundary after an error?
        // Replace "__" with the method name

        var expected = "Recover"; // SOLUTION: "Recover"

        Assert.Equal("Recover", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Recover_allows_component_to_try_again()
    {
        // ABOUT: After calling Recover(), the component can attempt
        // to render again.

        // TODO: In ErrorDemo, clicking "Recover" should reset the error.
        // Does the component return to normal state?

        var cut = Render<ErrorDemo>();

        // Cause error
        try
        {
            cut.Find("button").Click();
        }
        catch (InvalidOperationException)
        {
            // Expected
        }

        // Error should be displayed
        cut.WaitForAssertion(() =>
            Assert.Contains("Error:", cut.Markup), timeout: TimeSpan.FromSeconds(2));

        var expected = "yes"; // SOLUTION: "yes"

        // Recover would reset it (implementation-dependent)
        Assert.Equal("yes", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Component_state_should_be_fixed_before_Recover()
    {
        // ABOUT: Before calling Recover(), fix the condition that caused
        // the error, otherwise it will just fail again.

        // TODO: Should you fix the error condition before calling Recover()?

        var expected = "yes"; // SOLUTION: "yes"

        Assert.Equal("yes", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_can_be_nested()
    {
        // ABOUT: Multiple ErrorBoundary components can be nested,
        // with inner ones catching errors first.

        // TODO: Can you have ErrorBoundary inside ErrorBoundary?

        var expected = "yes"; // SOLUTION: "yes"

        Assert.Equal("yes", expected);
    }
}
