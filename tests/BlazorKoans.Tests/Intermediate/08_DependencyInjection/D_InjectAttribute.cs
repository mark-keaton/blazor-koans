using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                        THE [INJECT] ATTRIBUTE                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  [Inject] is the C# attribute equivalent of @inject directive.               ║
/// ║  Use it in code-behind files (.razor.cs) to inject services.                 ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // In .razor file:                                                  │  ║
/// ║  │  @inject IMyService MyService                                        │  ║
/// ║  │                                                                        │  ║
/// ║  │  // In code-behind (.razor.cs):                                       │  ║
/// ║  │  [Inject]                                                             │  ║
/// ║  │  public IMyService MyService { get; set; } = default!;                │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_InjectAttribute : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectAttribute_CodeBehind()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Using [Inject] in Code-Behind Files
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [Inject] is equivalent to @inject but used in .razor.cs files.
        // The service returns the same greeting as GreetingService.GetGreeting().
        //
        // EXERCISE: What greeting does the service return?
        //           (Check the GreetingService implementation)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering services and rendering code-behind component
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemoCodeBehind>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What greeting does the service return?           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The greeting from code-behind should match
        // ──────────────────────────────────────────────────────────────────────
        var actual = cut.Instance.GetGreetingFromCodeBehind();
        Assert.Equal(answer, actual);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectAttribute_SameService()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Scoped Services Are the Same Instance
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Whether you use @inject or [Inject], scoped services give you
        // the same instance within a circuit. The greeting should be identical.
        //
        // EXERCISE: Are the greetings from the same service "same" or "different"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - comparing greeting from service with expected value
        // ──────────────────────────────────────────────────────────────────────
        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        var greeting1 = cut.Instance.Greeting;
        var greeting2 = "Hello, Student!";

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are the greetings "same" or "different"?          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Compare the greetings
        // ──────────────────────────────────────────────────────────────────────
        var actual = greeting1 == greeting2 ? "same" : "different";
        Assert.Equal(answer, actual);
    }
}
