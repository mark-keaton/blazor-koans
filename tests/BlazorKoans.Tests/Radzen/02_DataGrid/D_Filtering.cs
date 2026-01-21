using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            DATAGRID FILTERING                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Filtering allows users to narrow down grid data by entering search criteria.║
/// ║  RadzenDataGrid supports automatic filtering with text boxes above columns.  ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees" AllowFiltering="true"              │  ║
/// ║  │                  FilterMode="FilterMode.Simple"&gt;                       │  ║
/// ║  │      &lt;Columns&gt;                                                         │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Name" Filterable="true" /&gt;   │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Department" /&gt;               │  ║
/// ║  │          &lt;RadzenDataGridColumn Title="Actions" Filterable="false" /&gt;  │  ║
/// ║  │      &lt;/Columns&gt;                                                        │  ║
/// ║  │  &lt;/RadzenDataGrid&gt;                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_Filtering : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_EnabledByProperty_AllowsFiltering()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: AllowFiltering Enables Grid-Wide Filtering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set AllowFiltering="true" on RadzenDataGrid to enable filtering.
        // This adds filter input controls above each column (unless explicitly disabled).
        //
        // EXERCISE: What property enables filtering on the entire DataGrid?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What property enables filtering?                ║
        // ║                                                                    ║
        // ║  HINT: The property name describes what it allows                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: AllowFiltering is the correct property
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("AllowFiltering", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterMode_ControlsUIStyle()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: FilterMode Controls Filter UI Appearance
        // ═══════════════════════════════════════════════════════════════════════
        //
        // FilterMode determines how filter inputs appear.
        // FilterMode.Simple shows text boxes above headers.
        // FilterMode.Advanced provides dropdown with operators.
        //
        // EXERCISE: What is the most common FilterMode for basic text filtering?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What FilterMode is most common?                 ║
        // ║                                                                    ║
        // ║  HINT: It's the simplest option                                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Simple is the most common filter mode
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Simple", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_TextInput_FiltersData()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Filter Inputs Automatically Filter Rows
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you type in a filter input, the grid automatically filters
        // rows to show only those matching the text. Filtering is case-insensitive
        // by default and uses "contains" logic.
        //
        // EXERCISE: After typing "Engineering" in Department filter, how many rows?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and applying filter
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<FilteringDemo>();
        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("Engineering");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many Engineering employees?                 ║
        // ║                                                                    ║
        // ║  HINT: Check the test data for Engineering department employees    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The filtered row count matches
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_Filterable_DisablesForColumn()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Filterable Parameter Disables Per-Column Filtering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set Filterable="false" on a column to hide its filter input.
        // This is useful for action columns or columns where filtering doesn't make sense.
        //
        // EXERCISE: In FilteringDemo, which column has Filterable="false"?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this inspection question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Which column disables filtering?                ║
        // ║                                                                    ║
        // ║  HINT: Action columns typically don't need filters                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Actions column has filtering disabled
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Actions", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterCaseSensitivity_DefaultBehavior()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Filtering is Case-Insensitive by Default
        // ═══════════════════════════════════════════════════════════════════════
        //
        // By default, filtering is case-insensitive. Typing "eng" matches
        // "Engineering", "ENGINEERING", or "engineering". This makes filters
        // more user-friendly.
        //
        // EXERCISE: Does "sales" (lowercase) match "Sales" (capitalized)?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and applying lowercase filter
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<FilteringDemo>();
        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("sales");
        var rowCount = cut.FindAll("tbody tr").Count;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does lowercase match capitalized?               ║
        // ║                                                                    ║
        // ║  HINT: Case-insensitive means case doesn't matter                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Yes" or "No"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Case-insensitive matching works
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_MultipleColumns_AllMustMatch()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Filters Use AND Logic
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you filter multiple columns, rows must match ALL filters (AND logic).
        // For example, Department="Engineering" AND Name contains "Alice".
        //
        // EXERCISE: Filter Department="Engineering" and Name="Alice". How many rows?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and applying multiple filters
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<FilteringDemo>();

        var deptFilter = cut.Find("input[placeholder*='Department']");
        deptFilter.Change("Engineering");

        var nameFilter = cut.Find("input[placeholder*='Name']");
        nameFilter.Change("Alice");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows match both filters?               ║
        // ║                                                                    ║
        // ║  HINT: Only rows matching BOTH criteria appear                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The filtered row count matches
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_ClearFilter_ShowsAllData()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Filters Restores All Data
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clearing a filter input (making it empty) removes that filter
        // and shows more rows again. The grid reacts immediately to changes.
        //
        // EXERCISE: After filtering then clearing, how many rows should appear?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid, filtering, then clearing
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<FilteringDemo>();
        var initialCount = cut.FindAll("tbody tr").Count;

        var filterInput = cut.Find("input[placeholder*='Department']");
        filterInput.Change("Engineering");
        filterInput.Change("");  // Clear filter

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows after clearing filter?            ║
        // ║                                                                    ║
        // ║  HINT: Same as the initial unfiltered count                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Row count returns to initial value
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(initialCount, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterOperator_DefaultContains()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Default Filter Operator is "Contains"
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Simple mode, the default filter operator is "contains".
        // This means typing "oh" matches "John", "Johnson", etc.
        // Advanced mode lets users choose operators like equals, starts with, etc.
        //
        // EXERCISE: What is the default filter operator in Simple mode?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the default filter operator?            ║
        // ║                                                                    ║
        // ║  HINT: It checks if the text is contained within the value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Contains is the default operator
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("contains", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_NumericColumns_ParsesNumbers()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Numeric Columns Parse Filter Input as Numbers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When filtering numeric columns, the grid parses the input as a number.
        // You can type "95000" to filter salaries. The comparison depends on the
        // filter operator.
        //
        // EXERCISE: Does typing "95000" in Salary filter find exact matches or ranges?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Exact match or range?                           ║
        // ║                                                                    ║
        // ║  HINT: Default is contains/equals for numeric values               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Exact" or "Range"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Exact matching is the default
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Exact", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Filtering_FilterTemplate_CustomUI()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: FilterTemplate Allows Custom Filter UI
        // ═══════════════════════════════════════════════════════════════════════
        //
        // FilterTemplate lets you create custom filter UI instead of the
        // default text input. You can use dropdowns, date pickers, checkboxes, etc.
        //
        // EXERCISE: Can you replace the default text input with a dropdown filter?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can you use custom filter UI?                   ║
        // ║                                                                    ║
        // ║  HINT: FilterTemplate gives you complete control                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Yes" or "No"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Custom filter UI is supported
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }
}
