using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BlazorKoans.Tests.Advanced.ErrorHandling;

public class D_Logging : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void ILogger_can_be_injected_into_components()
    {
        // ABOUT: ILogger<T> can be injected into Blazor components
        // for logging purposes.

        // TODO: What interface is injected for logging?
        // Replace "__" with the interface name (without generic parameter)

        var expected = "__";

        Assert.Equal("ILogger", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void LogInformation_logs_informational_messages()
    {
        // ABOUT: LogInformation() logs messages at the Information level.

        // TODO: How many log levels are there in ILogger?
        // (Trace, Debug, Information, Warning, Error, Critical)

        var cut = Render<LoggingDemo>();

        var expected = 0;

        Assert.Equal(expected, 6); // 6 standard log levels
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Logger_captures_structured_logging()
    {
        // ABOUT: ILogger supports structured logging with named parameters.

        // TODO: The LoggingDemo component logs with parameters.
        // Does it use structured logging?

        var loggerFactory = Services.GetService<ILoggerFactory>();
        Assert.NotNull(loggerFactory);

        var cut = Render<LoggingDemo>();

        cut.Find("button").Click();

        var expected = 0;

        Assert.Contains("Messages logged: 1", cut.Markup);
        Assert.Equal(expected, 1);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Logging_should_include_context_information()
    {
        // ABOUT: When logging, include relevant context like user ID,
        // operation name, or parameters.

        // TODO: Should log messages include context for debugging?

        var expected = "__";

        Assert.Equal("yes", expected);
    }
}
