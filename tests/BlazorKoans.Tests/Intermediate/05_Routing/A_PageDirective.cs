using System.Reflection;
using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class A_PageDirective : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_DefinesRouteTemplate()
    {
        // ABOUT: The @page directive defines the route template for a component.
        // It creates a RouteAttribute on the component class that the router uses.
        // We can read this attribute to verify what route a component is registered at.

        // TODO: Look at RoutingDemo.razor's @page directive.
        // What route path is this component accessible at?
        // Replace "__" with the route path (including the leading slash).

        // Get the actual route from the component's RouteAttribute
        var routeAttribute = typeof(RoutingDemo).GetCustomAttribute<RouteAttribute>();
        var actualRoute = routeAttribute?.Template;

        var expectedRoute = "/routing";

        Assert.Equal(expectedRoute, actualRoute);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_RendersContent()
    {
        // ABOUT: A component with @page directive renders like any other component

        // TODO: Replace "__" with the text that appears in the RoutingDemo component
        // HINT: Look at the <p> tag content in RoutingDemo.razor

        var cut = Render<RoutingDemo>();

        var expected = "This page is accessible at the /routing route."; // SOLUTION: "This page is accessible at the /routing route."

        cut.MarkupMatches($@"
            <h3>Routing Demo</h3>
            <p>{expected}</p>
        ");
    }
}
