using System.Reflection;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          ROUTE PARAMETERS                                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Route parameters capture values from URL segments and pass them to your     ║
/// ║  component as parameter values.                                              ║
/// ║                                                                              ║
/// ║  Syntax: {ParameterName} or {ParameterName:constraint}                       ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @page "/product/{Id:int}"      ← Captures integer from URL            │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      [Parameter]                ← Property name MUST match route param │  ║
/// ║  │      public int Id { get; set; }                                       │  ║
/// ║  │  }                                                                     │  ║
/// ║  │                                                                        │  ║
/// ║  │  URL: /product/42  →  Id = 42                                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_RouteParameters
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_CaptureValueFromUrl()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Defining Route Parameters
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Route parameters use curly braces {} in the @page directive.
        // The name inside the braces becomes the parameter that captures the value.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @page "/user/{Username}"                                           │
        // │              ↑                                                      │
        // │         Parameter name - captures this URL segment                  │
        // │                                                                     │
        // │  /user/alice  →  Username = "alice"                                 │
        // │  /user/bob    →  Username = "bob"                                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at ProductPage.razor's @page directive.
        //           What parameter name is defined (inside the braces)?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - reading the route template
        // ──────────────────────────────────────────────────────────────────────
        var routeAttribute = typeof(ProductPage).GetCustomAttribute<RouteAttribute>();
        var routeTemplate = routeAttribute?.Template ?? "";

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the parameter name (without braces)?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The route template should contain {YourAnswer...}
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"{{{answer}", routeTemplate);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_TypeConstraints()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Route Constraints
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Constraints limit what values a route parameter accepts.
        // If the URL doesn't match the constraint, the route won't match at all.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Common constraints:                                                │
        // │    {Id:int}      - Only integers       /product/42 ✓  /product/abc ✗│
        // │    {Id:guid}     - Only GUIDs          /item/550e8400-... ✓         │
        // │    {Active:bool} - Only true/false     /status/true ✓               │
        // │    {Name:alpha}  - Only letters        /user/alice ✓  /user/123 ✗   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What type constraint does ProductPage.razor use for Id?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - reading the route template
        // ──────────────────────────────────────────────────────────────────────
        var routeAttribute = typeof(ProductPage).GetCustomAttribute<RouteAttribute>();
        var routeTemplate = routeAttribute?.Template ?? "";

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What constraint type? (e.g., "int", "guid")     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The route template should contain :constraint}
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($":{answer}}}", routeTemplate);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_MatchComponentProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Route Parameters Must Match Component Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The route parameter name must exactly match a [Parameter] property.
        // The property type should match the constraint for proper type conversion.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @page "/product/{Id:int}"                                          │
        // │                  ↑                                                  │
        // │             Must match ↓                                            │
        // │  @code {                                                            │
        // │      [Parameter]                                                    │
        // │      public int Id { get; set; }   ← Same name "Id", type matches   │
        // │  }                                   the :int constraint            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What is the C# type of ProductPage's Id property?
        //           Replace typeof(string) with the correct type.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - inspecting the Id property's type
        // ──────────────────────────────────────────────────────────────────────
        var idProperty = typeof(ProductPage).GetProperty("Id");
        var actualType = idProperty?.PropertyType;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Change typeof(string) to the correct type       ║
        // ║                    e.g., typeof(int), typeof(Guid)                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = typeof(string);

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The property type should match your answer
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, actualType);
    }
}
