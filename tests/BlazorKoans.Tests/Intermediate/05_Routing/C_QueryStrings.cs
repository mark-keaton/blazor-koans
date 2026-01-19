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
        // ABOUT: [SupplyParameterFromQuery] binds query string values to parameters
        // For example, /search?query=blazor would set Query = "blazor"

        // TODO: What attribute is used to bind query string parameters?
        // Answer the question below by checking the SearchPage component

        var expected = "__"; // SOLUTION: "SupplyParameterFromQuery"

        // The SearchPage component uses [SupplyParameterFromQuery] on the Query parameter
        Assert.Equal("SupplyParameterFromQuery", expected);
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

        var expectedPropertyName = "__"; // SOLUTION: "Query"

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

        var expectedIsNullable = false; // SOLUTION: true

        Assert.Equal(expectedIsNullable, isNullable);
    }
}
