using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// Sorting allows users to reorder grid rows by clicking column headers.
/// RadzenDataGrid supports single-column sorting, multi-column sorting, and
/// custom sort logic.
///
/// Think of sorting as letting users organize data their way - by name alphabetically,
/// by salary highest-to-lowest, or by hire date newest-first.
/// </summary>
public class C_Sorting : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_EnabledByProperty_AllowsSorting()
    {
        // ABOUT: Set AllowSorting="true" on RadzenDataGrid to enable sorting.
        // This makes column headers clickable and adds sort indicators (arrows).

        // TODO: What property enables sorting on the entire DataGrid?

        var expected = "__";

        Assert.Equal("AllowSorting", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ColumnHeader_BecomesClickable()
    {
        // ABOUT: When AllowSorting is enabled, column headers become clickable.
        // Clicking once sorts ascending, clicking again sorts descending,
        // clicking a third time removes the sort.

        // TODO: How many clicks to cycle through: unsorted -> ascending -> descending -> unsorted?

        var expected = 0;

        Assert.Equal(3, expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickHeader_SortsAscending()
    {
        // ABOUT: First click on a column header sorts the data in ascending order.
        // For strings, A-Z; for numbers, lowest-to-highest; for dates, oldest-to-newest.
        // Try it in the browser: click the Name column header in SortingDemo.

        // TODO: When sorting names alphabetically (A-Z), which employee comes first?
        // HINT: Alice, Bob, Carol, David, Eve, Frank, Grace, Helen...

        var expected = "__";

        Assert.Equal("Alice", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickTwice_SortsDescending()
    {
        // ABOUT: Clicking a column header twice sorts in descending order.
        // For strings, Z-A; for numbers, highest-to-lowest; for dates, newest-to-oldest.
        // Try it in the browser: click Salary header twice in SortingDemo.

        // TODO: When sorting salaries descending (highest first), who appears first?
        // HINT: Carol has the highest salary at $105,000

        var expected = "__";

        Assert.Equal("Carol", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_MultiColumn_RequiresProperty()
    {
        // ABOUT: To enable Shift+Click multi-column sorting, you must set
        // AllowMultiColumnSorting="true" on the DataGrid (in addition to AllowSorting).
        // This lets users sort by Department first, then by Salary within each department.

        // TODO: What property enables multi-column sorting (Shift+Click)?
        // HINT: It's similar to AllowSorting but for multiple columns

        var expected = "__";

        Assert.Equal("AllowMultiColumnSorting", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_Sortable_DisablesForColumn()
    {
        // ABOUT: Set Sortable="false" on a specific column to prevent sorting.
        // This is useful for action columns or computed columns where sorting
        // doesn't make sense.

        // TODO: In SortingDemo, which column has Sortable="false"?
        // HINT: Look for the Actions or Status column

        var expected = "__";

        Assert.Equal("Actions", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_SortOrder_ControlsDefaultSort()
    {
        // ABOUT: You can set a default sort by using the SortOrder parameter.
        // Set it on one or more columns to load the grid pre-sorted.

        // TODO: What type is SortOrder (it's an enum)?
        // HINT: Ascending, Descending...

        var expected = "__";

        Assert.Contains("SortOrder", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_CustomSort_UsesProperty()
    {
        // ABOUT: By default, sorting uses the Property value directly.
        // For simple properties like strings and numbers, this works perfectly.
        // For complex scenarios, you can customize sort behavior.

        // TODO: What property does the Department column sort by?

        var cut = Render<SortingDemo>();

        var expected = "__";

        Assert.Equal("Department", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_SortIndicator_ShowsDirection()
    {
        // ABOUT: When a column is sorted, RadzenDataGrid shows a visual indicator
        // (usually an arrow icon) in the header to show sort direction.
        // Up arrow = ascending, down arrow = descending.

        // TODO: After sorting ascending, which direction does the arrow point?

        var expected = "__"; // "Up" or "Down"

        Assert.Equal("Up", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_PreservesData_OnlyReorders()
    {
        // ABOUT: Sorting doesn't modify your data - it only changes the display order.
        // The original collection remains unchanged; the grid just renders rows
        // in a different sequence.

        // TODO: How many employees are in SortingDemo (sorting doesn't add/remove rows)?

        var cut = Render<SortingDemo>();

        var rowCount = cut.FindAll("tbody tr").Count;
        var expected = 0;

        Assert.Equal(expected, rowCount);
    }
}
