using System.Reflection;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class B_RouteParameters
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_CaptureValueFromUrl()
    {
        // ABOUT: Route parameters use {ParameterName} syntax in the @page directive.
        // For example: @page "/product/{Id}" captures the URL segment into the Id parameter.
        // The parameter name in the route must match a [Parameter] property on the component.

        // TODO: Look at ProductPage.razor's @page directive.
        // What is the name of the route parameter (the part inside the curly braces)?
        // Replace "__" with the parameter name (without braces or constraints).

        var routeAttribute = typeof(ProductPage).GetCustomAttribute<RouteAttribute>();
        var routeTemplate = routeAttribute?.Template ?? "";

        var expectedParameterName = "Id";

        // The route template should contain {ParameterName} or {ParameterName:constraint}
        Assert.Contains($"{{{expectedParameterName}", routeTemplate);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_TypeConstraints()
    {
        // ABOUT: Route parameters can have type constraints like :int, :guid, :bool, etc.
        // For example: {Id:int} only matches integer values in the URL.
        // If the URL doesn't match the constraint, the route won't match.

        // TODO: Look at ProductPage.razor's @page directive.
        // What type constraint is applied to the Id parameter?
        // Replace "__" with the constraint type (just the type name, e.g., "int", "guid").

        var routeAttribute = typeof(ProductPage).GetCustomAttribute<RouteAttribute>();
        var routeTemplate = routeAttribute?.Template ?? "";

        var expectedConstraint = "int";

        // The route template should contain :constraint}
        Assert.Contains($":{expectedConstraint}}}", routeTemplate);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_MatchComponentProperty()
    {
        // ABOUT: The route parameter name must match a [Parameter] property on the component.
        // Blazor uses this to automatically populate the property from the URL.
        // The property type should match the route constraint (e.g., :int means int property).

        // TODO: Look at ProductPage.razor's @code section.
        // The Id property has the [Parameter] attribute. What is its C# type?
        // Replace "typeof(string)" with the correct type (e.g., typeof(int), typeof(Guid)).

        var idProperty = typeof(ProductPage).GetProperty("Id");
        var actualType = idProperty?.PropertyType;

        var expectedType = typeof(int);

        Assert.Equal(expectedType, actualType);
    }
}
