using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class A_PageDirective : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_DefinesRouteTemplate()
    {
        // ABOUT: The @page directive defines the route template for a component
        // It makes the component routable and accessible via URL

        // TODO: Replace "__" with the correct route path defined in RoutingDemo.razor
        // HINT: Look at the @page directive in RoutingDemo.razor

        var cut = Render<RoutingDemo>();

        var expected = "__";

        // The component metadata should indicate its route
        Assert.NotNull(cut.Instance);
        Assert.Equal(expected, "/routing");
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_RendersContent()
    {
        // ABOUT: A component with @page directive renders like any other component

        // TODO: Replace "__" with the text that appears in the RoutingDemo component
        // HINT: Look at the <p> tag content in RoutingDemo.razor

        var cut = Render<RoutingDemo>();

        var expected = "__";

        cut.MarkupMatches($@"
            <h3>Routing Demo</h3>
            <p>{expected}</p>
        ");
    }
}
