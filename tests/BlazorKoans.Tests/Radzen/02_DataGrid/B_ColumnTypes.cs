using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                           DATAGRID COLUMN TYPES                              ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenDataGrid supports different column types for displaying data.         ║
/// ║  Use format strings for dates/numbers, or templates for custom rendering.    ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGridColumn Property="Salary" FormatString="{0:C}" /&gt;       │  ║
/// ║  │  &lt;RadzenDataGridColumn Property="HireDate" FormatString="{0:d}" /&gt;     │  ║
/// ║  │  &lt;RadzenDataGridColumn Title="Status"&gt;                                 │  ║
/// ║  │      &lt;Template Context="emp"&gt;                                          │  ║
/// ║  │          &lt;RadzenBadge Text="@(emp.IsActive ? "Active" : "Inactive")" /&gt;│  ║
/// ║  │      &lt;/Template&gt;                                                       │  ║
/// ║  │  &lt;/RadzenDataGridColumn&gt;                                               │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_ColumnTypes : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_FormatString_FormatsDecimal()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: FormatString Formats Numeric Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The FormatString parameter uses standard .NET format strings.
        // "{0:C}" formats as currency, "{0:N2}" as number with 2 decimals.
        // The {0} represents the property value.
        //
        // EXERCISE: What formatted value appears in the Salary column?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and finding salary cell
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>();
        var salaryCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[2];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the formatted salary value?             ║
        // ║                                                                    ║
        // ║  HINT: Currency format adds a $ symbol and comma separators        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "$95,000";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The salary cell contains the formatted value
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, salaryCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_FormatString_FormatsDateTime()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: FormatString Formats DateTime Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // DateTime values can be formatted using standard date format strings.
        // "{0:d}" shows short date, "{0:yyyy-MM-dd}" shows custom format.
        // The demo uses "{0:d}" which renders as a short date like "3/15/2020".
        //
        // EXERCISE: What is the formatted hire date in the first row?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and finding hire date cell
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>();
        var hireDateCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[3];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the formatted hire date?                ║
        // ║                                                                    ║
        // ║  HINT: Short date format uses / between month, day, year           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "3/15/2020";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The hire date cell contains the formatted date
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, hireDateCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_AllowsCustomRendering()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Template Parameter Enables Custom Cell Rendering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Template parameter lets you define custom rendering for a cell.
        // Instead of just showing a property value, you can render HTML, components,
        // buttons, badges - anything you want!
        //
        // EXERCISE: What does the template column display for active employees?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and finding status cell
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>();
        var statusCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[4];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text is shown for active employees?        ║
        // ║                                                                    ║
        // ║  HINT: Look for the Template section in the component              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The status cell contains the expected text
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, statusCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_AccessesContext()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Template Context Provides Row Data
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Inside a Template, the 'context' variable gives you access to
        // the current row's data item. If TItem is Employee, context is an Employee.
        // This lets you access any property: context.Name, context.Salary, etc.
        //
        // EXERCISE: What is the context variable's type in a DataGridColumn<Employee>?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What type is the context variable?              ║
        // ║                                                                    ║
        // ║  HINT: The context type matches TItem                              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The context type is Employee
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Employee", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_CanRenderComponents()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Templates Can Render Blazor Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Templates can render other Blazor components, not just HTML.
        // You can render RadzenBadge, RadzenButton, RadzenIcon, or your own components.
        // This makes the grid incredibly flexible.
        //
        // EXERCISE: Does ColumnTypesDemo use RadzenBadge in a template column?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid to inspect templates
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is RadzenBadge used in a template?              ║
        // ║                                                                    ║
        // ║  HINT: Look for <RadzenBadge> in the component source              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Yes" or "No"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: RadzenBadge is used in the component
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_ConditionalRendering()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Templates Support Conditional Logic
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Templates can use conditional logic to render different content
        // based on the row's data. For example, show green badge if active,
        // red badge if inactive.
        //
        // EXERCISE: What text is shown for inactive employees?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid with inactive employee
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>(parameters =>
            parameters.Add(p => p.ShowInactiveEmployee, true));
        var statusCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[4];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What badge variant for inactive employees?      ║
        // ║                                                                    ║
        // ║  HINT: Check the @if condition in the template                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Success", "Danger", "Warning", etc.

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The status cell shows "Inactive" text
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains("Inactive", statusCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Width_CanBeSpecified()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Width Parameter Controls Column Size
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Each column can have a Width parameter to control its size.
        // You can use pixels ("120px"), percentages ("20%"), or let it auto-size.
        //
        // EXERCISE: What unit does ColumnTypesDemo use for the Status column width?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this inspection question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What unit is used for column width?             ║
        // ║                                                                    ║
        // ║  HINT: Look at the Width parameter in the component                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "px", "%", or "auto"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The width uses pixels
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("px", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_TextAlign_ControlsAlignment()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TextAlign Controls Horizontal Alignment
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The TextAlign parameter controls horizontal alignment of cell content.
        // Common values: TextAlign.Left, TextAlign.Center, TextAlign.Right.
        // Numbers and currency typically align right.
        //
        // EXERCISE: How should a salary column be aligned for best readability?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What alignment for currency columns?            ║
        // ║                                                                    ║
        // ║  HINT: Numbers align better when decimal points line up            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Left", "Center", or "Right"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Right alignment is best for currency
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Right", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Frozen_StaysVisible_WhenScrolling()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Frozen Columns Stay Visible During Horizontal Scroll
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Setting Frozen="true" on a column keeps it visible when scrolling
        // horizontally. This is useful for key columns like Name or ID that you
        // always want visible.
        //
        // EXERCISE: Which column position is commonly frozen in data grids?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Which column position is typically frozen?      ║
        // ║                                                                    ║
        // ║  HINT: Think about which column you'd always want to see           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "First", "Last", or "Middle"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: First column is typically frozen
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("First", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_WithButton()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Templates Often Include Action Buttons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Templates commonly include buttons for row actions like Edit, Delete,
        // or View Details. You can use RadzenButton or regular HTML buttons.
        //
        // EXERCISE: What action button is shown in the Actions column?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and finding actions cell
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<ColumnTypesDemo>();
        var actionsCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[5];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What button text is in the Actions column?      ║
        // ║                                                                    ║
        // ║  HINT: Look for RadzenButton in the Actions column template        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The actions cell contains the expected button
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, actionsCell?.TextContent ?? "");
    }
}
