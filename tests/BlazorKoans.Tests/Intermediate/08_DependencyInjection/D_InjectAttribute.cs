using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using BlazorKoans.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._08_DependencyInjection;

public class D_InjectAttribute : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectAttribute_CodeBehind()
    {
        // ABOUT: [Inject] attribute is used in code-behind files
        // It's equivalent to @inject directive in .razor files

        // TODO: Replace "__" with the greeting from the code-behind service
        // HINT: Look at ServiceDemoCodeBehind.GetGreetingFromCodeBehind()

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemoCodeBehind>();

        var expected = "__";

        var actual = cut.Instance.GetGreetingFromCodeBehind();
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InjectAttribute_SameService()
    {
        // ABOUT: Services injected via @inject and [Inject] are the same instance (when scoped)

        // TODO: Replace "__" with "same" or "different"
        // HINT: Scoped services are the same within a component/circuit

        Services.AddScoped<IGreetingService, GreetingService>();
        Services.AddScoped<ICounterService, CounterService>();

        var cut = Render<ServiceDemo>();

        // Both injections should use the same scoped instance
        var greeting1 = cut.Instance.Greeting;
        var greeting2 = "Hello, Student!";

        var expected = "__";

        var actual = greeting1 == greeting2 ? "same" : "different";
        Assert.Equal(expected, actual);
    }
}
