using System.Linq;
using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// Inline editing allows users to modify grid data directly within the grid.
/// RadzenDataGrid supports row-level editing with automatic form generation,
/// validation, and save/cancel operations.
///
/// Think of inline editing as turning a grid row into an editable form - click Edit,
/// the row becomes text boxes, make changes, then Save or Cancel.
/// </summary>
public class G_InlineEditing : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_EditMode_EnablesEditing()
    {
        // ABOUT: Set EditMode to enable inline editing.
        // EditMode.Single allows editing one row at a time.
        // EditMode.Multiple allows editing multiple rows simultaneously.

        var cut = Render<InlineEditingDemo>();

        // TODO: How many Edit buttons are visible (one per row)?
        var editButtons = cut.FindAll("button").Where(b => b.TextContent.Contains("Edit"));

        var expected = 0;

        Assert.Equal(expected, editButtons.Count());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowEdit_EventFires()
    {
        // ABOUT: The RowEdit event fires when clicking an Edit button or entering edit mode.
        // You can use this to load additional data or prepare for editing.

        // TODO: What event fires when a row enters edit mode?

        var expected = "__";

        Assert.Equal("RowEdit", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowUpdate_SavesChanges()
    {
        // ABOUT: The RowUpdate event fires when the user clicks Save/Update.
        // This is where you save changes to your database or data store.
        // The event provides the modified item.

        // TODO: What event fires when saving changes?

        var expected = "__";

        Assert.Equal("RowUpdate", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowCancel_DiscardsChanges()
    {
        // ABOUT: The RowCancel event fires when the user clicks Cancel.
        // The grid automatically reverts the row to its original values.
        // Changes are not saved.

        // TODO: Are changes saved when clicking Cancel?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("No", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_EditTemplate_CustomEditor()
    {
        // ABOUT: Use EditTemplate to customize how a column is edited.
        // Instead of the default text box, you can use dropdowns, date pickers,
        // numeric inputs, or any Radzen input component.

        // TODO: Can you use RadzenDropDown in an EditTemplate?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_Validation_RequiredFields()
    {
        // ABOUT: RadzenDataGrid integrates with data annotations for validation.
        // If your model has [Required] attributes, the grid enforces them during editing.
        // Invalid rows can't be saved.

        // TODO: Can you save a row with empty required fields?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("No", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_CommandColumn_AddsEditButtons()
    {
        // ABOUT: Add an Actions column with Edit/Save/Cancel buttons.
        // Use Template for view mode (Edit button) and EditTemplate for edit mode
        // (Save and Cancel buttons).

        var cut = Render<InlineEditingDemo>();

        // TODO: What is the title of the column containing the Edit button?
        // HINT: Look at InlineEditingDemo's last column

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowCreate_AddsNewRow()
    {
        // ABOUT: To add new rows, provide a button that calls grid.InsertRow().
        // The RowCreate event fires when the user saves the new row.

        var cut = Render<InlineEditingDemo>();

        // TODO: What text is on the button that adds a new employee?
        // HINT: Look at the button below the grid in InlineEditingDemo

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_InsertRow_StartsInEditMode()
    {
        // ABOUT: When you add a new row (InsertRow), it immediately appears in edit mode
        // at the top or bottom of the grid. Users fill in values and click Save.

        // TODO: Is a new row immediately in edit mode?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_SingleMode_OneRowEditable()
    {
        // ABOUT: In Single edit mode, only one row can be in edit mode at a time.
        // Starting to edit another row automatically saves or cancels the current edit.

        // TODO: In Single mode, can two rows be in edit mode simultaneously?

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("No", expected);
    }
}
