using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
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

        // TODO: Replace "__" with the query value that will be displayed
        // HINT: The Query parameter is set via component parameters

        var cut = Render<SearchPage>(parameters =>
            parameters.Add(p => p.Query, "blazor"));

        var expected = "__";

        var markup = cut.Markup;
        Assert.Contains($"Query: {expected}", markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_OptionalParameter()
    {
        // ABOUT: Query parameters can be optional (nullable types)

        // TODO: Replace "__" with what displays when no query is provided
        // HINT: Look at the Query parameter type in SearchPage.razor

        var cut = Render<SearchPage>();

        var expected = "__";

        var markup = cut.Markup;
        Assert.Contains($"Query: {expected}", markup);
    }
}
