using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class C_QueryStrings : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_SupplyParameterFromQuery()
    {
        // ABOUT: [SupplyParameterFromQuery] binds query string values to parameters
        // For example, /search?query=blazor would set Query = "blazor"

        // TODO: What attribute is used to bind query string parameters?
        // Answer the question below by checking the SearchPage component

        var expected = "SupplyParameterFromQuery"; // SOLUTION: "SupplyParameterFromQuery"

        // The SearchPage component uses [SupplyParameterFromQuery] on the Query parameter
        Assert.Equal("SupplyParameterFromQuery", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_OptionalParameter()
    {
        // ABOUT: Query parameters can be optional (nullable types)

        // TODO: Replace "__" with what displays when no query is provided
        // HINT: Look at the Query parameter type in SearchPage.razor

        var cut = Render<SearchPage>();

        var expected = ""; // SOLUTION: "" (empty string displays when null)

        var markup = cut.Markup;
        Assert.Contains($"Query: {expected}", markup);
    }
}
