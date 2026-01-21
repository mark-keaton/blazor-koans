using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          DATAGRID INLINE EDITING                             ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Inline editing allows users to modify grid data directly within the grid.   ║
/// ║  RadzenDataGrid supports row-level editing with automatic form generation,   ║
/// ║  validation, and save/cancel operations.                                     ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees"                                     │  ║
/// ║  │                   EditMode="DataGridEditMode.Single"                   │  ║
/// ║  │                   RowEdit="@OnRowEdit"                                 │  ║
/// ║  │                   RowUpdate="@OnRowUpdate"                             │  ║
/// ║  │                   RowCancel="@OnRowCancel" /&gt;                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Think of inline editing as turning a grid row into an editable form -       ║
/// ║  click Edit, the row becomes text boxes, make changes, then Save or Cancel.  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class G_InlineEditing : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_EditMode_EnablesEditing()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Edit Mode
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set EditMode to enable inline editing.
        // EditMode.Single allows editing one row at a time.
        // EditMode.Multiple allows editing multiple rows simultaneously.
        //
        // EXERCISE: What EditMode allows editing only one row at a time?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the single-row edit mode                   ║
        // ║                                                                    ║
        // ║  HINT: The mode that restricts editing to one row                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the correct mode
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Single", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowEdit_EventFires()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RowEdit Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The RowEdit event fires when clicking an Edit button or entering edit mode.
        // You can use this to load additional data or prepare for editing.
        //
        // EXERCISE: What event fires when a row enters edit mode?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the event for entering edit mode           ║
        // ║                                                                    ║
        // ║  HINT: It's named after what action triggers it                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the event name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("RowEdit", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowUpdate_SavesChanges()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RowUpdate Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The RowUpdate event fires when the user clicks Save/Update.
        // This is where you save changes to your database or data store.
        // The event provides the modified item.
        //
        // EXERCISE: What event fires when saving changes?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the event for saving changes               ║
        // ║                                                                    ║
        // ║  HINT: It indicates the row is being updated                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the event name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("RowUpdate", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowCancel_DiscardsChanges()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RowCancel Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The RowCancel event fires when the user clicks Cancel.
        // The grid automatically reverts the row to its original values.
        // Changes are not saved.
        //
        // EXERCISE: Are changes saved when clicking Cancel?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are changes saved when canceling?               ║
        // ║                                                                    ║
        // ║  HINT: Cancel means to discard changes                             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("No", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_EditTemplate_CustomEditor()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: EditTemplate
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Use EditTemplate to customize how a column is edited.
        // Instead of the default text box, you can use dropdowns, date pickers,
        // numeric inputs, or any Radzen input component.
        //
        // EXERCISE: Can you use RadzenDropDown in an EditTemplate?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can custom controls be used in EditTemplate?    ║
        // ║                                                                    ║
        // ║  HINT: EditTemplate accepts any Razor content                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_Validation_RequiredFields()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Validation with Data Annotations
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDataGrid integrates with data annotations for validation.
        // If your model has [Required] attributes, the grid enforces them during editing.
        // Invalid rows can't be saved.
        //
        // EXERCISE: Can you save a row with empty required fields?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can invalid rows be saved?                      ║
        // ║                                                                    ║
        // ║  HINT: Validation blocks saving until fields are valid             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("No", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_CommandColumn_AddsEditButtons()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Command Column for Edit Buttons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDataGridColumn with a Template can include Edit/Update/Cancel buttons.
        // Use RadzenButton with icon="edit" for Edit, "check" for Save, "close" for Cancel.
        // The grid handles the state transitions automatically.
        //
        // EXERCISE: What icon is commonly used for the Edit button?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What icon name for the Edit button?             ║
        // ║                                                                    ║
        // ║  HINT: The icon name matches the action                            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the icon name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("edit", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_RowCreate_AddsNewRow()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RowCreate Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The RowCreate event fires when adding a new row.
        // You can use this to insert the new item into your data collection
        // and save it to the database.
        //
        // EXERCISE: What event fires when creating a new row?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the event for creating new rows            ║
        // ║                                                                    ║
        // ║  HINT: It indicates a row is being created                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the event name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("RowCreate", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_InsertRow_StartsInEditMode()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: InsertRow Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you add a new row (InsertRow), it immediately appears in edit mode
        // at the top or bottom of the grid. Users fill in values and click Save.
        //
        // EXERCISE: Is a new row immediately in edit mode?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does InsertRow start in edit mode?              ║
        // ║                                                                    ║
        // ║  HINT: New rows need values entered immediately                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Editing_SingleMode_OneRowEditable()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Single Edit Mode Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In Single edit mode, only one row can be in edit mode at a time.
        // Starting to edit another row automatically saves or cancels the current edit.
        //
        // EXERCISE: In Single mode, can two rows be in edit mode simultaneously?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can multiple rows be edited in Single mode?     ║
        // ║                                                                    ║
        // ║  HINT: "Single" means one at a time                                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("No", answer);
    }
}
