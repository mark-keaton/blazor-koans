using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          LOGGING IN BLAZOR                                   ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  ILogger can be injected into Blazor components for logging purposes.        ║
/// ║  Structured logging captures context for debugging and monitoring.           ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @inject ILogger&lt;MyComponent&gt; Logger                                  │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      void HandleClick()                                                │  ║
/// ║  │      {                                                                 │  ║
/// ║  │          Logger.LogInformation("Button clicked by {User}", userId);   │  ║
/// ║  │      }                                                                 │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Log Levels: Trace, Debug, Information, Warning, Error, Critical             ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_Logging : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ILogger_can_be_injected_into_components()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Injecting Loggers into Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ILogger<T> can be injected into Blazor components for logging purposes.
        // Use @inject ILogger<ComponentName> Logger in your component.
        //
        // EXERCISE: What interface is injected for logging?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What interface name? (without generic parameter) ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: It's an interface for logging (starts with "I")
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The interface is ILogger
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("ILogger", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void LogInformation_logs_informational_messages()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Log Levels in ILogger
        // ═══════════════════════════════════════════════════════════════════════
        //
        // LogInformation() logs messages at the Information level.
        // ILogger has 6 log levels: Trace, Debug, Information, Warning, Error, Critical.
        //
        // EXERCISE: How many standard log levels are there in ILogger?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the LoggingDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<LoggingDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many log levels? (enter a number)            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Count them: Trace, Debug, Information, Warning, Error, Critical
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: There are 6 standard log levels
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, 6);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Logger_captures_structured_logging()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Structured Logging with Named Parameters
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ILogger supports structured logging with named parameters like:
        //   Logger.LogInformation("User {UserId} clicked {ButtonName}", id, name);
        // This captures context that can be searched and filtered.
        //
        // EXERCISE: After clicking the button, how many messages were logged?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup logger and render component
        // ──────────────────────────────────────────────────────────────────────
        var loggerFactory = Services.GetService<ILoggerFactory>();
        Assert.NotNull(loggerFactory);

        var cut = Render<LoggingDemo>();
        cut.Find("button").Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many messages logged after click?            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Look at what the markup says: "Messages logged: X"
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: One message was logged
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains("Messages logged: 1", cut.Markup);
        Assert.Equal(answer, 1);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Logging_should_include_context_information()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Including Context in Log Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When logging, include relevant context like user ID, operation name,
        // or parameters. This makes debugging much easier in production.
        //
        // EXERCISE: Should log messages include context for debugging?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Include context in logs? (yes/no)                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        // HINT: Context helps identify issues when reviewing logs later
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Always include relevant context in log messages
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("yes", answer);
    }
}
