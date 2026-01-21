using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    RECOVERING FROM ERRORS IN BLAZOR                          ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  ErrorBoundary provides a Recover() method to reset error state and          ║
/// ║  re-render the ChildContent, giving the component another chance.            ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;ErrorBoundary @ref="errorBoundary"&gt;                                 │  ║
/// ║  │      &lt;ChildContent&gt;...&lt;/ChildContent&gt;                                │  ║
/// ║  │      &lt;ErrorContent&gt;                                                  │  ║
/// ║  │          &lt;button @onclick="Recover"&gt;Try Again&lt;/button&gt;               │  ║
/// ║  │      &lt;/ErrorContent&gt;                                                 │  ║
/// ║  │  &lt;/ErrorBoundary&gt;                                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │  void Recover() =&gt; errorBoundary?.Recover();                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_RecoverFromError : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_Recover_resets_error_state()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The Recover() Method
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ErrorBoundary.Recover() method resets the error state and re-renders
        // the ChildContent. This gives the component another chance to succeed.
        //
        // EXERCISE: What method resets an ErrorBoundary after an error?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What method name resets the ErrorBoundary?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: It starts with "R" and means to get better from an illness
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The method is called "Recover"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Recover", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Recover_allows_component_to_try_again()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Retrying After an Error
        // ═══════════════════════════════════════════════════════════════════════
        //
        // After calling Recover(), the component can attempt to render again.
        // In ErrorDemo, clicking "Recover" should reset the error state.
        //
        // EXERCISE: Does calling Recover() return the component to normal state?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render component and trigger an error
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does Recover() return to normal state? (yes/no)  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Recover resets the error state and re-renders ChildContent
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Recover returns component to normal state
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("yes", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Component_state_should_be_fixed_before_Recover()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Fix the Root Cause Before Recovering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Before calling Recover(), fix the condition that caused the error.
        // Otherwise the same error will just happen again on re-render.
        //
        // EXERCISE: Should you fix the error condition before calling Recover()?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Fix root cause before Recover? (yes/no)          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: If you don't fix it, the same error will occur again
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Always fix the underlying issue first
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("yes", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void ErrorBoundary_can_be_nested()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nested ErrorBoundary Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Multiple ErrorBoundary components can be nested. The innermost
        // ErrorBoundary catches errors first, providing granular error handling.
        //
        // EXERCISE: Can you have ErrorBoundary inside another ErrorBoundary?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can ErrorBoundary be nested? (yes/no)            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Like try-catch blocks, error boundaries can be nested
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: ErrorBoundary components can be nested
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("yes", answer);
    }
}
