using System.Reflection;
using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          QUERY STRING PARAMETERS                             ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Query strings pass data in URLs after the ? mark: /search?query=blazor      ║
/// ║  Blazor can automatically bind these to component parameters.                ║
/// ║                                                                              ║
/// ║  The [SupplyParameterFromQuery] attribute:                                   ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @page "/search"                                                       │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      [Parameter]                                                       │  ║
/// ║  │      [SupplyParameterFromQuery]        ← Binds from URL query string   │  ║
/// ║  │      public string? Query { get; set; }                                │  ║
/// ║  │  }                                                                     │  ║
/// ║  │                                                                        │  ║
/// ║  │  URL: /search?Query=blazor  →  Query = "blazor"                        │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_QueryStrings : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_SupplyParameterFromQuery()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The [SupplyParameterFromQuery] Attribute
        // ═══════════════════════════════════════════════════════════════════════
        //
        // To receive values from query strings, mark a parameter with
        // [SupplyParameterFromQuery]. Without it, the parameter won't get values.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [Parameter]                                                        │
        // │  [SupplyParameterFromQuery]    ← REQUIRED for query binding         │
        // │  public string? Query { get; set; }                                 │
        // │                                                                     │
        // │  URL: /search?Query=test  →  Query property gets "test"             │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Add [SupplyParameterFromQuery] to the Query property
        //           in SearchPage.razor (this is a code modification exercise)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE & VERIFY: Check if the attribute exists on the property
        // ──────────────────────────────────────────────────────────────────────
        var queryProperty = typeof(SearchPage).GetProperty("Query");
        var hasAttribute = queryProperty?
            .GetCustomAttribute<SupplyParameterFromQueryAttribute>() != null;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ACTION - Add this attribute to Query in SearchPage.razor:║
        // ║                                                                    ║
        // ║      [Parameter]                                                   ║
        // ║      [SupplyParameterFromQuery]                                    ║
        // ║      public string? Query { get; set; }                            ║
        // ╚════════════════════════════════════════════════════════════════════╝

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
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Query String Binding in Action
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When the URL contains query parameters, Blazor extracts them and
        // assigns them to matching [SupplyParameterFromQuery] properties.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  URL: /search?Query=blazor                                          │
        // │                      ↓                                              │
        // │  [SupplyParameterFromQuery]                                         │
        // │  public string? Query { get; set; }  ← Gets "blazor"                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at the URL below. What value will Query receive?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - navigating to URL with query string
        // ──────────────────────────────────────────────────────────────────────
        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?Query=blazor");

        var cut = Render<SearchPage>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What value does Query receive from the URL?     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Query property should have the URL value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.Query);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_AreCaseInsensitive()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Query Keys Are Case-Insensitive
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Query string matching is case-insensitive in Blazor.
        // All of these bind to a property named "Query":
        //   ?query=value  ?Query=value  ?QUERY=value
        //
        // EXERCISE: The URL uses lowercase "query", but the property is "Query".
        //           What value does Query receive?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - navigating with lowercase query key
        // ──────────────────────────────────────────────────────────────────────
        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?query=case-test");

        var cut = Render<SearchPage>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What value does Query receive?                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Case-insensitive matching should work
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.Query);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void QueryStrings_CustomKeyBindingInAction()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Query Key Names
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Use Name parameter to bind to a different query key than the property:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [SupplyParameterFromQuery(Name = "q")]                             │
        // │  public string? SearchTerm { get; set; }                            │
        // │                                                                     │
        // │  URL: /search?q=test  →  SearchTerm = "test"                        │
        // │                  ↑                                                  │
        // │         Matches "q" not "SearchTerm"                                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What value does SearchTerm receive from ?q=test?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - navigating with custom query key
        // ──────────────────────────────────────────────────────────────────────
        var navMan = Services.GetRequiredService<NavigationManager>();
        navMan.NavigateTo("/search?q=test");

        var cut = Render<SearchPage>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What value does SearchTerm receive from ?q=...? ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: SearchTerm should have the value from ?q=
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.SearchTerm);
    }
}
