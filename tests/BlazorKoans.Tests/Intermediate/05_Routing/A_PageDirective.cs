using System.Reflection;
using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          THE @PAGE DIRECTIVE                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  The @page directive makes a component "routable" - accessible via URL.      ║
/// ║  Without it, a component can only be used inside other components.           ║
/// ║                                                                              ║
/// ║  How it works:                                                               ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @page "/weather"              ← Makes component accessible at /weather│  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;h1&gt;Weather Page&lt;/h1&gt;          ← Regular component content             │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Under the hood, @page creates a [Route] attribute on the compiled class.    ║
/// ║  A component can have MULTIPLE @page directives for multiple routes.         ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_PageDirective : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_DefinesRouteTemplate()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Defining Routes with @page
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The @page directive at the top of a .razor file defines its URL path.
        // When a user navigates to that path, Blazor renders this component.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @page "/counter"             // Accessible at /counter             │
        // │  @page "/my-counter"          // ALSO accessible at /my-counter     │
        // │                               // (multiple routes are allowed)      │
        // │  <h1>Counter</h1>                                                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // The @page directive compiles to a [Route] attribute, which we can
        // inspect at runtime to verify the component's route.
        //
        // EXERCISE: Look at RoutingDemo.razor's @page directive.
        //           What route path is defined? (Include the leading slash)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - reading the RouteAttribute from the component type
        // ──────────────────────────────────────────────────────────────────────
        var routeAttribute = typeof(RoutingDemo).GetCustomAttribute<RouteAttribute>();
        var actualRoute = routeAttribute?.Template;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the route path in @page "..."?          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the actual route
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, actualRoute);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void PageDirective_RendersContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Routable Components Are Still Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // A component with @page is still a regular component. It can:
        //   - Have parameters
        //   - Be rendered directly in tests
        //   - Contain any normal component content
        //
        // EXERCISE: Look at the RoutingDemo.razor component.
        //           What text appears in the <p> tag?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the component directly
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RoutingDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text is in the <p> tag?                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the rendered markup
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches($@"
            <h3>Routing Demo</h3>
            <p>{answer}</p>
        ");
    }
}
