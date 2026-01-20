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

        var expected = "AllowSorting";

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

        var expected = 3;

        Assert.Equal(3, expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickHeader_SortsAscending()
    {
        // ABOUT: First click on a column header sorts the data in ascending order.
        // For strings, A-Z; for numbers, lowest-to-highest; for dates, oldest-to-newest.

        // TODO: After clicking the Name column, what employee appears first?
        // HINT: Alice, Bob, Carol... alphabetically

        var cut = Render<SortingDemo>();

        // Click the Name column header
        var nameHeader = cut.FindAll("th")[0];
        nameHeader.Click();

        var firstRow = cut.FindAll("tbody tr")[0];
        var firstName = firstRow.QuerySelector("td")?.TextContent ?? "";
        var expected = "Alice";

        Assert.Contains(expected, firstName);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickTwice_SortsDescending()
    {
        // ABOUT: Clicking a column header twice sorts in descending order.
        // For strings, Z-A; for numbers, highest-to-lowest; for dates, newest-to-oldest.

        // TODO: After clicking Salary twice, who has the highest salary?
        // HINT: Look at the employee data

        var cut = Render<SortingDemo>();

        var salaryHeader = cut.FindAll("th")[2];
        salaryHeader.Click(); // First click: ascending
        salaryHeader.Click(); // Second click: descending

        var firstRow = cut.FindAll("tbody tr")[0];
        var firstEmployee = firstRow.QuerySelector("td")?.TextContent ?? "";
        var expected = "Carol";

        Assert.Contains(expected, firstEmployee);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_MultiColumn_SortsMultipleColumns()
    {
        // ABOUT: Hold Shift while clicking additional column headers to sort by
        // multiple columns. First sort is primary, second is secondary (breaks ties).

        // TODO: Does RadzenDataGrid support multi-column sorting by default?
        // HINT: Yes, when AllowSorting is enabled

        var expected = "Yes"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
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

        var expected = "Actions";

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

        var expected = "SortOrder";

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

        var expected = "Department";

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

        var expected = "Up"; // "Up" or "Down"

        Assert.Equal("Up", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_PreservesData_OnlyReorders()
    {
        // ABOUT: Sorting doesn't modify your data - it only changes the display order.
        // The original collection remains unchanged; the grid just renders rows
        // in a different sequence.

        // TODO: How many rows are visible after sorting?
        // HINT: Same as before sorting

        var cut = Render<SortingDemo>();

        var beforeCount = cut.FindAll("tbody tr").Count;

        // Sort by name
        var nameHeader = cut.FindAll("th")[0];
        nameHeader.Click();

        var afterCount = cut.FindAll("tbody tr").Count;
        var expected = 0;

        Assert.Equal(beforeCount, afterCount);
    }
}
