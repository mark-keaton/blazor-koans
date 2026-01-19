using System.Reflection;
using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class C_QueryStrings : BunitContext
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
        // A property named "Query" matches ?Query=value in the URL (case-insensitive).
        // When no custom Name is specified, the attribute's Name property is null.

        // TODO: The Query property should use its name as the query key (no custom Name).
        // After adding [SupplyParameterFromQuery] to Query, verify it has no custom Name.

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var attribute = queryProperty?.GetCustomAttribute<SupplyParameterFromQueryAttribute>();

        // Query should have the attribute
        Assert.NotNull(attribute);
        // And it should use the default (property name as key, so Name is null)
        Assert.Null(attribute.Name);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_NullableTypeMeansOptional()
    {
        // ABOUT: Query parameters are optional when the property type is nullable.
        // A nullable string (string?) means the parameter doesn't have to be in the URL.
        // Non-nullable types would cause issues when the query parameter is missing.

        // TODO: Change the Query property type from string to string? in SearchPage.razor
        // to make it an optional query parameter.

        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var nullabilityContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityContext.Create(queryProperty!);
        var isNullable = nullabilityInfo.WriteState == NullabilityState.Nullable;

        var expectedIsNullable = true;

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

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_BindingInAction()
    {
        // ABOUT: Now let's see query string binding in action!
        // bUnit's NavigationManager lets us set the URL before rendering.
        // When we navigate to /search?Query=blazor, the Query property gets the value.

        // TODO: Replace "__" with the value that Query will receive from the URL.
        // Look at the query string in the NavigateTo call below.

        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?Query=blazor");

        var cut = Render<SearchPage>();

        var expected = "__";

        // The Query property should have received the value from the URL
        Assert.Equal(expected, cut.Instance.Query);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_AreCaseInsensitive()
    {
        // ABOUT: Query string keys are case-insensitive in Blazor.
        // ?query=value, ?Query=value, and ?QUERY=value all bind to the Query property.
        // This matches standard URL conventions.

        // TODO: Replace "__" with the value Query receives.
        // Notice the URL uses lowercase "query" but the property is "Query".

        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?query=case-test");

        var cut = Render<SearchPage>();

        var expected = "__";

        // Even with lowercase "query" in the URL, Query property gets the value
        Assert.Equal(expected, cut.Instance.Query);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_CustomKeyBindingInAction()
    {
        // ABOUT: Custom query keys work the same way.
        // With [SupplyParameterFromQuery(Name = "q")], the URL ?q=test binds to SearchTerm.

        // TODO: Replace "__" with the value that SearchTerm will receive from ?q=test.

        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?q=test");

        var cut = Render<SearchPage>();

        var expected = "__";

        // The SearchTerm property should have received the value from ?q=test
        Assert.Equal(expected, cut.Instance.SearchTerm);
    }
}
