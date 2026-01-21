using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                             DATAGRID SELECTION                               ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Selection allows users to select one or more rows in the grid.              ║
/// ║  RadzenDataGrid supports single selection, multiple selection, and the       ║
/// ║  SelectionChanged event to react to user selections.                         ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees"                                     │  ║
/// ║  │                   SelectionMode="DataGridSelectionMode.Single"         │  ║
/// ║  │                   @bind-Value="@selectedEmployee"                      │  ║
/// ║  │                   SelectionChanged="@OnSelectionChanged" /&gt;            │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Think of selection like checking items in a to-do list - you can select     ║
/// ║  one item to view details, or multiple items to perform bulk actions.        ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class F_Selection : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectionMode_EnablesSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Selection Mode
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set SelectionMode to enable row selection.
        // SelectionMode.Single allows selecting one row at a time.
        // SelectionMode.Multiple allows selecting multiple rows (with checkboxes).
        //
        // EXERCISE: What SelectionMode allows selecting only one row?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the single-row selection mode              ║
        // ║                                                                    ║
        // ║  HINT: The mode that restricts selection to one row                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the correct mode
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Single", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Single_OnlyOneRowSelected()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Single Selection Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Single mode, clicking a row selects it and deselects any
        // previously selected row. Only one row can be selected at a time.
        //
        // EXERCISE: In Single mode, can you have 2 rows selected simultaneously?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can multiple rows be selected in Single mode?   ║
        // ║                                                                    ║
        // ║  HINT: "Single" means one at a time                                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("No", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Multiple_AllowsMultipleRows()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Selection UI
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Multiple mode, the grid shows checkboxes. Users can check
        // multiple rows to select them. A header checkbox selects/deselects all.
        //
        // EXERCISE: What UI element appears in Multiple mode for selection?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What UI control enables multi-selection?        ║
        // ║                                                                    ║
        // ║  HINT: A square input that can be checked or unchecked             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the UI element
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("checkbox", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Value_BindsSelectedItem()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Binding Selected Value
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Use @bind-Value to bind the selected item(s) to a property.
        // For Single mode, bind to TItem (e.g., Employee).
        // For Multiple mode, bind to IEnumerable<TItem>.
        //
        // EXERCISE: For Single selection, what type should the bound property be?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the SelectionDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<SelectionDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What type for single selection binding?         ║
        // ║                                                                    ║
        // ║  HINT: Same as TItem                                               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the binding type
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Employee", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_ClickRow_SelectsRow()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clicking to Select
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Single mode, clicking anywhere in a row selects it.
        // The selected row gets a visual highlight (usually a different background).
        //
        // EXERCISE: After clicking a row, where is the selected item stored?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the component and click the first row
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<SelectionDemo>();
        var firstRow = cut.FindAll("tbody tr")[0];
        firstRow.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears after selection?              ║
        // ║                                                                    ║
        // ║  HINT: The property you bound with @bind-Value                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if selection is shown in markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectionChanged_EventFires()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: SelectionChanged Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The SelectionChanged event fires whenever the selection changes.
        // This lets you react to selections - load details, enable buttons, etc.
        //
        // EXERCISE: Does SelectionChanged fire when clicking a row?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the event fire on row click?               ║
        // ║                                                                    ║
        // ║  HINT: Row click changes the selection                             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_HeaderCheckbox_SelectsAll()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Header Checkbox Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Multiple mode, the header checkbox selects or deselects all
        // visible rows. If you're on page 1 of a paged grid, it selects page 1 rows.
        //
        // EXERCISE: In Multiple mode, what does the header checkbox do?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it select all rows or just the page?       ║
        // ║                                                                    ║
        // ║  HINT: Think about paged grids - it selects what's visible         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "SelectsAll" or "SelectsPage"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("SelectsPage", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Programmatic_CanSetValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Programmatic Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can programmatically select rows by setting the bound Value property.
        // The grid will update to show the selection visually.
        //
        // EXERCISE: Can you select a row in code without user interaction?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can selection be set programmatically?          ║
        // ║                                                                    ║
        // ║  HINT: Two-way binding works both ways                             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectedItem_AccessProperties()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Accessing Selected Item Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Once a row is selected, you can access all its properties through
        // the bound variable. If selectedEmployee is bound, you can use
        // selectedEmployee.Name, selectedEmployee.Salary, etc.
        //
        // EXERCISE: After selecting a row, can you access the employee's name?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the component and click the first row
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<SelectionDemo>();
        var firstRow = cut.FindAll("tbody tr")[0];
        firstRow.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can you access properties of selected item?     ║
        // ║                                                                    ║
        // ║  HINT: The bound variable has all properties of the item           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_MultipleValue_IsList()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Selection Binding Type
        // ═══════════════════════════════════════════════════════════════════════
        //
        // For Multiple selection mode, bind to IEnumerable<TItem> or List<TItem>.
        // This collection holds all selected items, and you can iterate through them.
        //
        // EXERCISE: For Multiple selection, what type should the bound property be?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What collection type for multi-selection?       ║
        // ║                                                                    ║
        // ║  HINT: A collection of TItem                                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if your answer contains the collection interface
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains("IEnumerable", answer);
    }
}
