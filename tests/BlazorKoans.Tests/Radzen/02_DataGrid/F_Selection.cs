using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// Selection allows users to select one or more rows in the grid.
/// RadzenDataGrid supports single selection, multiple selection, and
/// the SelectionChanged event to react to user selections.
///
/// Think of selection like checking items in a to-do list - you can select
/// one item to view details, or multiple items to perform bulk actions.
/// </summary>
public class F_Selection : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectionMode_EnablesSelection()
    {
        // ABOUT: Set SelectionMode to enable row selection.
        // SelectionMode.Single allows selecting one row at a time.
        // SelectionMode.Multiple allows selecting multiple rows (with checkboxes).

        // TODO: What SelectionMode allows selecting only one row?

        var expected = "__";

        Assert.Equal("Single", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Single_OnlyOneRowSelected()
    {
        // ABOUT: In Single mode, clicking a row selects it and deselects any
        // previously selected row. Only one row can be selected at a time.

        // TODO: In Single mode, can you have 2 rows selected simultaneously?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("No", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Multiple_AllowsMultipleRows()
    {
        // ABOUT: In Multiple mode, the grid shows checkboxes. Users can check
        // multiple rows to select them. A header checkbox selects/deselects all.

        // TODO: What UI element appears in Multiple mode for selection?

        var expected = "__";

        Assert.Equal("checkbox", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Value_BindsSelectedItem()
    {
        // ABOUT: Use @bind-Value to bind the selected item(s) to a property.
        // For Single mode, bind to TItem (e.g., Employee).
        // For Multiple mode, bind to IEnumerable<TItem>.

        // TODO: For Single selection, what type should the bound property be?
        // HINT: Same as TItem

        var cut = Render<SelectionDemo>();

        var expected = "__";

        Assert.Equal("Employee", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_ClickRow_SelectsRow()
    {
        // ABOUT: In Single mode, clicking anywhere in a row selects it.
        // The selected row gets a visual highlight (usually a different background color).

        // TODO: After clicking a row, what property contains the selected item?
        // HINT: The property you bound with @bind-Value

        var cut = Render<SelectionDemo>();

        // Click first row
        var firstRow = cut.FindAll("tbody tr")[0];
        firstRow.Click();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectionChanged_EventFires()
    {
        // ABOUT: The SelectionChanged event fires whenever the selection changes.
        // This lets you react to selections - load details, enable buttons, etc.

        // TODO: Does SelectionChanged fire when clicking a row?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_HeaderCheckbox_SelectsAll()
    {
        // ABOUT: In Multiple mode, the header checkbox selects or deselects all
        // visible rows. If you're on page 1 of a paged grid, it selects page 1 rows.

        // TODO: In Multiple mode, what does the header checkbox do?

        var expected = "__"; // "SelectsAll" or "SelectsPage"

        Assert.Equal("SelectsPage", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_Programmatic_CanSetValue()
    {
        // ABOUT: You can programmatically select rows by setting the bound Value property.
        // The grid will update to show the selection visually.

        // TODO: Can you select a row in code without user interaction?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_SelectedItem_AccessProperties()
    {
        // ABOUT: Once a row is selected, you can access all its properties through
        // the bound variable. If selectedEmployee is bound, you can use
        // selectedEmployee.Name, selectedEmployee.Salary, etc.

        // TODO: After selecting a row, can you access the employee's name?

        var cut = Render<SelectionDemo>();

        var firstRow = cut.FindAll("tbody tr")[0];
        firstRow.Click();

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Selection_MultipleValue_IsList()
    {
        // ABOUT: For Multiple selection mode, bind to IEnumerable<TItem> or List<TItem>.
        // This collection holds all selected items, and you can iterate through them.

        // TODO: For Multiple selection, what type should the bound property be?
        // HINT: A collection of TItem

        var expected = "__";

        Assert.Contains("IEnumerable", expected);
    }
}
