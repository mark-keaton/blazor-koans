using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            DATAGRID SORTING                                  ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Sorting allows users to reorder grid rows by clicking column headers.       ║
/// ║  RadzenDataGrid supports single and multi-column sorting.                    ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees" AllowSorting="true"&gt;                │  ║
/// ║  │      &lt;Columns&gt;                                                         │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Name" Sortable="true" /&gt;      │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Salary" /&gt;                    │  ║
/// ║  │          &lt;RadzenDataGridColumn Title="Actions" Sortable="false" /&gt;     │  ║
/// ║  │      &lt;/Columns&gt;                                                        │  ║
/// ║  │  &lt;/RadzenDataGrid&gt;                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_Sorting : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_EnabledByProperty_AllowsSorting()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: AllowSorting Enables Grid-Wide Sorting
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set AllowSorting="true" on RadzenDataGrid to enable sorting.
        // This makes column headers clickable and adds sort indicators (arrows).
        //
        // EXERCISE: What property enables sorting on the entire DataGrid?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What property enables sorting?                  ║
        // ║                                                                    ║
        // ║  HINT: The property name describes what it allows                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: AllowSorting is the correct property
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("AllowSorting", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ColumnHeader_BecomesClickable()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Headers Cycle Through Sort States
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When AllowSorting is enabled, column headers become clickable.
        // Clicking once sorts ascending, clicking again sorts descending,
        // clicking a third time removes the sort.
        //
        // EXERCISE: How many clicks to cycle through all sort states?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many clicks for full cycle?                 ║
        // ║                                                                    ║
        // ║  HINT: unsorted -> ascending -> descending -> unsorted             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Three clicks complete the cycle
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(3, answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickHeader_SortsAscending()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: First Click Sorts Ascending
        // ═══════════════════════════════════════════════════════════════════════
        //
        // First click on a column header sorts the data in ascending order.
        // For strings, A-Z; for numbers, lowest-to-highest; for dates, oldest-to-newest.
        //
        // EXERCISE: After clicking the Name column, what employee appears first?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and clicking name header
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<SortingDemo>();
        var nameHeader = cut.FindAll("th")[0];
        nameHeader.Click();

        var firstRow = cut.FindAll("tbody tr")[0];
        var firstName = firstRow.QuerySelector("td")?.TextContent ?? "";

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Who appears first when sorted A-Z?              ║
        // ║                                                                    ║
        // ║  HINT: Alice, Bob, Carol... alphabetically                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The first row contains the expected name
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, firstName);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_ClickTwice_SortsDescending()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Second Click Sorts Descending
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clicking a column header twice sorts in descending order.
        // For strings, Z-A; for numbers, highest-to-lowest; for dates, newest-to-oldest.
        //
        // EXERCISE: After clicking Salary twice, who has the highest salary?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and clicking salary header twice
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<SortingDemo>();
        var salaryHeader = cut.FindAll("th")[2];
        salaryHeader.Click();  // First click: ascending
        salaryHeader.Click();  // Second click: descending

        var firstRow = cut.FindAll("tbody tr")[0];
        var firstEmployee = firstRow.QuerySelector("td")?.TextContent ?? "";

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Who has the highest salary?                     ║
        // ║                                                                    ║
        // ║  HINT: Look at the employee data in the component                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The highest paid employee appears first
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, firstEmployee);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_MultiColumn_SortsMultipleColumns()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multi-Column Sorting with Shift+Click
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Hold Shift while clicking additional column headers to sort by
        // multiple columns. First sort is primary, second is secondary (breaks ties).
        //
        // EXERCISE: Does RadzenDataGrid support multi-column sorting by default?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is multi-column sorting supported?              ║
        // ║                                                                    ║
        // ║  HINT: Yes, when AllowSorting is enabled                           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Yes" or "No"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Multi-column sorting is supported
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_Sortable_DisablesForColumn()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Sortable Parameter Disables Per-Column Sorting
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set Sortable="false" on a specific column to prevent sorting.
        // This is useful for action columns or computed columns where sorting
        // doesn't make sense.
        //
        // EXERCISE: In SortingDemo, which column has Sortable="false"?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this inspection question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Which column disables sorting?                  ║
        // ║                                                                    ║
        // ║  HINT: Look for the Actions or Status column in the component      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Actions column has sorting disabled
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Actions", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_SortOrder_ControlsDefaultSort()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: SortOrder Sets Default Sort Direction
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can set a default sort by using the SortOrder parameter.
        // Set it on one or more columns to load the grid pre-sorted.
        //
        // EXERCISE: What type is SortOrder (it's an enum)?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the enum type name?                     ║
        // ║                                                                    ║
        // ║  HINT: The enum has Ascending and Descending values                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: SortOrder is the enum type
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains("SortOrder", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_CustomSort_UsesProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Sorting Uses the Property Value by Default
        // ═══════════════════════════════════════════════════════════════════════
        //
        // By default, sorting uses the Property value directly.
        // For simple properties like strings and numbers, this works perfectly.
        // For complex scenarios, you can customize sort behavior.
        //
        // EXERCISE: What property does the Department column sort by?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid for inspection
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<SortingDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What property does Department column sort by?   ║
        // ║                                                                    ║
        // ║  HINT: It sorts by the Property parameter value                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Department column sorts by Department property
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Department", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_SortIndicator_ShowsDirection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Sort Indicators Show Current Sort Direction
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a column is sorted, RadzenDataGrid shows a visual indicator
        // (usually an arrow icon) in the header to show sort direction.
        // Up arrow = ascending, down arrow = descending.
        //
        // EXERCISE: After sorting ascending, which direction does the arrow point?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Which direction for ascending sort?             ║
        // ║                                                                    ║
        // ║  HINT: Think of numbers going up (ascending) = arrow pointing up   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Up" or "Down"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Ascending sort shows up arrow
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Up", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Sorting_PreservesData_OnlyReorders()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Sorting Only Reorders Display, Not Data
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Sorting doesn't modify your data - it only changes the display order.
        // The original collection remains unchanged; the grid just renders rows
        // in a different sequence.
        //
        // EXERCISE: How many rows are visible after sorting?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid, counting rows, then sorting
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<SortingDemo>();
        var beforeCount = cut.FindAll("tbody tr").Count;

        var nameHeader = cut.FindAll("th")[0];
        nameHeader.Click();

        var afterCount = cut.FindAll("tbody tr").Count;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows after sorting?                    ║
        // ║                                                                    ║
        // ║  HINT: Same as before sorting - data count doesn't change          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Row count is preserved after sorting
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(beforeCount, afterCount);
    }
}
