using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// Filtering allows users to narrow down grid data by entering search criteria.
/// RadzenDataGrid supports automatic filtering with text boxes above columns,
/// custom filter templates, and programmatic filtering.
///
/// Think of filtering as a search function for each column - users type what they
/// want to find, and the grid shows only matching rows.
/// </summary>
public class D_Filtering : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_EnabledByProperty_AllowsFiltering()
    {
        // ABOUT: Set AllowFiltering="true" on RadzenDataGrid to enable filtering.
        // This adds filter input controls above each column (unless explicitly disabled).

        // TODO: What property enables filtering on the entire DataGrid?

        var expected = "AllowFiltering";

        Assert.Equal("AllowFiltering", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterMode_ControlsUIStyle()
    {
        // ABOUT: FilterMode determines how filter inputs appear.
        // FilterMode.Simple shows text boxes above headers.
        // FilterMode.Advanced provides dropdown with operators.

        // TODO: What is the most common FilterMode for basic text filtering?
        // HINT: It's the simplest option

        var expected = "Simple";

        Assert.Equal("Simple", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_TextInput_FiltersData()
    {
        // ABOUT: When you type in a filter input, the grid automatically filters
        // rows to show only those matching the text. Filtering is case-insensitive
        // by default and uses "contains" logic.

        // TODO: After typing "Engineering" in Department filter, how many rows appear?
        // HINT: Check the test data for Engineering department employees

        var cut = Render<FilteringDemo>();

        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("Engineering");

        var expected = 2;

        Assert.Equal(expected, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_Filterable_DisablesForColumn()
    {
        // ABOUT: Set Filterable="false" on a column to hide its filter input.
        // This is useful for action columns or columns where filtering doesn't make sense.

        // TODO: In FilteringDemo, which column has Filterable="false"?

        var expected = "Actions";

        Assert.Equal("Actions", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterCaseSensitivity_DefaultBehavior()
    {
        // ABOUT: By default, filtering is case-insensitive. Typing "eng" matches
        // "Engineering", "ENGINEERING", or "engineering". This makes filters
        // more user-friendly.

        // TODO: Does "sales" (lowercase) match "Sales" (capitalized)?

        var cut = Render<FilteringDemo>();

        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("sales");

        var rowCount = cut.FindAll("tbody tr").Count;
        var expected = "Yes"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_MultipleColumns_AllMustMatch()
    {
        // ABOUT: When you filter multiple columns, rows must match ALL filters (AND logic).
        // For example, Department="Engineering" AND Name contains "Alice".

        // TODO: Filter Department="Engineering" and Name="Alice". How many rows?

        var cut = Render<FilteringDemo>();

        var deptFilter = cut.Find("input[placeholder*='Department']");
        deptFilter.Change("Engineering");

        var nameFilter = cut.Find("input[placeholder*='Name']");
        nameFilter.Change("Alice");

        var expected = 1;

        Assert.Equal(expected, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_ClearFilter_ShowsAllData()
    {
        // ABOUT: Clearing a filter input (making it empty) removes that filter
        // and shows more rows again. The grid reacts immediately to changes.

        // TODO: After filtering then clearing, how many rows should appear?
        // HINT: Same as the initial unfiltered count

        var cut = Render<FilteringDemo>();

        var initialCount = cut.FindAll("tbody tr").Count;

        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("Engineering");
        filterInput.Change(""); // Clear filter

        var expected = 5;

        Assert.Equal(initialCount, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterOperator_DefaultContains()
    {
        // ABOUT: In Simple mode, the default filter operator is "contains".
        // This means typing "oh" matches "John", "Johnson", etc.
        // Advanced mode lets users choose operators like equals, starts with, etc.

        // TODO: What is the default filter operator in Simple mode?

        var expected = "contains";

        Assert.Equal("contains", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_NumericColumns_ParsesNumbers()
    {
        // ABOUT: When filtering numeric columns, the grid parses the input as a number.
        // You can type "95000" to filter salaries. The comparison depends on the
        // filter operator.

        // TODO: Does typing "95000" in Salary filter find exact matches or ranges?
        // HINT: Default is contains/equals

        var expected = "Exact"; // "Exact" or "Range"

        Assert.Equal("Exact", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterTemplate_CustomUI()
    {
        // ABOUT: FilterTemplate lets you create custom filter UI instead of the
        // default text input. You can use dropdowns, date pickers, checkboxes, etc.

        // TODO: Can you replace the default text input with a dropdown filter?

        var expected = "Yes"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }
}
