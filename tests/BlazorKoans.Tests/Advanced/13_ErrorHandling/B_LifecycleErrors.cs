using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

public class B_LifecycleErrors : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void Try_catch_in_OnInitialized_handles_errors()
    {
        // ABOUT: Lifecycle methods like OnInitializedAsync can use try-catch
        // to handle errors gracefully.

        // TODO: Wrap async operations in try-catch.
        // Does this prevent ErrorBoundary from triggering?

        var expected = false;

        // When errors are caught in lifecycle methods,
        // ErrorBoundary is not triggered
        Assert.Equal(expected, true);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Caught_errors_can_set_error_state()
    {
        // ABOUT: Instead of letting errors bubble up, components can
        // catch them and set an error state property.

        // TODO: In a try-catch block, set an errorMessage field.
        // Can this be displayed in the UI?

        string? errorMessage = null;

        try
        {
            throw new InvalidOperationException("Something failed");
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }

        var expected = "__";

        Assert.Equal(expected, errorMessage);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void OnInitializedAsync_errors_show_in_ErrorBoundary()
    {
        // ABOUT: If OnInitializedAsync throws without try-catch,
        // ErrorBoundary catches it.

        // TODO: What happens to unhandled exceptions in OnInitializedAsync?

        var expected = "__";

        // Unhandled exceptions bubble up to ErrorBoundary
        Assert.Equal("caught", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Finally_block_runs_even_with_errors()
    {
        // ABOUT: The finally block executes regardless of whether
        // an exception was thrown.

        // TODO: Use try-catch-finally to ensure cleanup.
        // Does finally run if an exception occurs?

        bool finallyRan = false;

        try
        {
            throw new Exception("Error");
        }
        catch
        {
            // Handle error
        }
        finally
        {
            finallyRan = true;
        }

        var expected = false;

        Assert.Equal(expected, finallyRan);
    }
}
