using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                     LIFECYCLE ERROR HANDLING IN BLAZOR                       ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Lifecycle methods like OnInitializedAsync can throw exceptions.             ║
/// ║  You can handle these with try-catch or let them bubble to ErrorBoundary.    ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  protected override async Task OnInitializedAsync()                   │  ║
/// ║  │  {                                                                    │  ║
/// ║  │      try                                                              │  ║
/// ║  │      {                                                                │  ║
/// ║  │          await LoadDataAsync();                                       │  ║
/// ║  │      }                                                                │  ║
/// ║  │      catch (Exception ex)                                             │  ║
/// ║  │      {                                                                │  ║
/// ║  │          errorMessage = ex.Message;                                   │  ║
/// ║  │      }                                                                │  ║
/// ║  │  }                                                                    │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_LifecycleErrors : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void Try_catch_in_OnInitialized_handles_errors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Handling Errors in Lifecycle Methods
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Lifecycle methods like OnInitializedAsync can use try-catch to handle
        // errors gracefully. When errors are caught in lifecycle methods,
        // ErrorBoundary is NOT triggered.
        //
        // EXERCISE: Does catching errors in lifecycle methods prevent ErrorBoundary?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does try-catch prevent ErrorBoundary trigger?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: When you catch an exception yourself, it doesn't bubble up
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Caught errors don't reach ErrorBoundary
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("yes", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Caught_errors_can_set_error_state()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Setting Error State Instead of Throwing
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Instead of letting errors bubble up, components can catch them and
        // set an error state property. This error message can be displayed in UI.
        //
        // EXERCISE: What message does the caught exception contain?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Catch an exception and store its message
        // ──────────────────────────────────────────────────────────────────────
        string? errorMessage = null;

        try
        {
            throw new InvalidOperationException("Something failed");
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the error message from the exception?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Look at what message was passed to InvalidOperationException
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The error message was captured
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, errorMessage);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void OnInitializedAsync_errors_show_in_ErrorBoundary()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Unhandled Lifecycle Errors Bubble to ErrorBoundary
        // ═══════════════════════════════════════════════════════════════════════
        //
        // If OnInitializedAsync throws without try-catch, ErrorBoundary catches
        // the exception. Unhandled exceptions bubble up to the nearest boundary.
        //
        // EXERCISE: What happens to unhandled exceptions in OnInitializedAsync?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are unhandled lifecycle errors "caught" by      ║
        // ║     ErrorBoundary, or do they crash the app?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: ErrorBoundary is designed to catch errors from child components
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Unhandled exceptions are caught by ErrorBoundary
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("caught", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Finally_block_runs_even_with_errors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Finally Blocks for Cleanup
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The finally block executes regardless of whether an exception was
        // thrown. Use try-catch-finally to ensure cleanup code always runs.
        //
        // EXERCISE: Does the finally block run even when an exception occurs?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Try-catch-finally with an exception
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Did the finally block run? (true or false)       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Finally ALWAYS runs, even if there's an exception
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Finally block always executes
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, finallyRan);
    }
}
