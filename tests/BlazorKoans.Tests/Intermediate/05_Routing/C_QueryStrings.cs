using System.Reflection;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class C_QueryStrings
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_SupplyParameterFromQuery()
    {
        // ABOUT: [SupplyParameterFromQuery] binds query string values to parameters.
        // For example, /search?query=blazor would set Query = "blazor".
        // Without this attribute, the property won't receive values from the URL.

        // TODO: Add the [SupplyParameterFromQuery] attribute to the Query property
        // in SearchPage.razor to bind it to the URL query string.

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var hasAttribute = queryProperty?
            .GetCustomAttribute<SupplyParameterFromQueryAttribute>() != null;

        Assert.True(hasAttribute,
            "The Query property needs the [SupplyParameterFromQuery] attribute");
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_PropertyNameBecomesQueryKey()
    {
        // ABOUT: By default, the property name becomes the query string key.
        // A property named "Query" matches ?query=value in the URL.

        // TODO: What is the name of the property that has [SupplyParameterFromQuery]?
        // Replace "__" with the property name from SearchPage.razor

        var properties = typeof(SearchPage).GetProperties();
        var queryProperty = Array.Find(properties, p =>
            p.GetCustomAttribute<SupplyParameterFromQueryAttribute>() != null);

        var expectedPropertyName = "__";

        Assert.Equal(expectedPropertyName, queryProperty?.Name);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_NullableTypeMeansOptional()
    {
        // ABOUT: Query parameters are optional when the property type is nullable.
        // A nullable string (string?) means the parameter doesn't have to be in the URL.

        // TODO: Is the Query property nullable (optional)?
        // Replace false with true if the property is nullable

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var nullabilityContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityContext.Create(queryProperty!);
        var isNullable = nullabilityInfo.WriteState == NullabilityState.Nullable;

        var expectedIsNullable = false;

        Assert.Equal(expectedIsNullable, isNullable);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_CustomQueryKey()
    {
        // ABOUT: You can customize the query string key using the Name parameter.
        // [SupplyParameterFromQuery(Name = "q")] binds to ?q=value instead of ?SearchTerm=value.
        // This is useful for shorter URLs or matching existing API conventions.

        // TODO: Add Name = "q" to the [SupplyParameterFromQuery] attribute on SearchTerm
        // in SearchPage.razor so it binds to ?q=value in the URL.

        var searchTermProperty = typeof(SearchPage).GetProperty("SearchTerm");
        var attribute = searchTermProperty?
            .GetCustomAttribute<SupplyParameterFromQueryAttribute>();

        Assert.Equal("q", attribute?.Name);
    }
}
