using System.Reflection;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class C_QueryStrings
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_SupplyParameterFromQueryAttribute()
    {
        // ABOUT: [SupplyParameterFromQuery] binds query string values to parameters.
        // A property with this attribute gets its value from the URL query string.
        // For example: /search?query=blazor would set the Query property to "blazor".

        // TODO: Look at SearchPage.razor's Query property.
        // What attribute (besides [Parameter]) marks it as coming from the query string?
        // Replace "__" with the attribute name (without brackets or "Attribute" suffix).

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var hasSupplyFromQueryAttribute = queryProperty?
            .GetCustomAttribute<SupplyParameterFromQueryAttribute>() != null;

        var expectedAttributeName = "__";

        // Verify the attribute name matches what's on the property
        Assert.Equal("SupplyParameterFromQuery", expectedAttributeName);
        Assert.True(hasSupplyFromQueryAttribute, "Query property should have [SupplyParameterFromQuery]");
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_PropertyNameBecomesQueryKey()
    {
        // ABOUT: By default, the property name becomes the query string key.
        // If the property is named "Query", the URL would be ?Query=value.
        // You can customize this with [SupplyParameterFromQuery(Name = "q")].

        // TODO: Look at SearchPage.razor's query parameter property.
        // What is the property name that becomes the query string key?
        // Replace "__" with the property name (case-sensitive).

        var properties = typeof(SearchPage).GetProperties();
        var queryProperty = properties.FirstOrDefault(p =>
            p.GetCustomAttribute<SupplyParameterFromQueryAttribute>() != null);

        var expectedPropertyName = "__";

        Assert.Equal(expectedPropertyName, queryProperty?.Name);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_NullableTypeMeansOptional()
    {
        // ABOUT: Query parameters can be optional by using nullable types.
        // string? means the parameter is optional - the page works without it.
        // Non-nullable types would require the query parameter to be present.

        // TODO: Look at SearchPage.razor's Query property type.
        // Is the type nullable (optional) or non-nullable (required)?
        // Replace false with true if nullable, or keep false if non-nullable.

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var propertyType = queryProperty?.PropertyType;

        // Check if it's a nullable reference type (string?)
        var nullabilityContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityContext.Create(queryProperty!);
        var isNullable = nullabilityInfo.WriteState == NullabilityState.Nullable;

        var expectedIsNullable = false;

        Assert.Equal(expectedIsNullable, isNullable);
    }
}
