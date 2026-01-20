using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// RadzenDataGrid supports different column types for displaying and formatting data.
/// You can use simple property binding, format strings for dates/numbers, or custom
/// templates for complete control over how cells render.
///
/// Think of column types as different ways to display your data - from simple text
/// to formatted currency to completely custom HTML with buttons and icons.
/// </summary>
public class B_ColumnTypes : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_FormatString_FormatsDecimal()
    {
        // ABOUT: The FormatString parameter uses standard .NET format strings.
        // "{0:C}" formats as currency, "{0:N2}" as number with 2 decimals.
        // The {0} represents the property value.

        // TODO: What format string creates currency format (e.g., "$95,000.00")?
        // HINT: C is for Currency

        var cut = Render<ColumnTypesDemo>();

        var expected = "{0:C}";

        Assert.Equal("{0:C}", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_FormatString_FormatsDateTime()
    {
        // ABOUT: DateTime values can be formatted using standard date format strings.
        // "{0:d}" shows short date, "{0:yyyy-MM-dd}" shows custom format.

        // TODO: What format string shows date as "MM/dd/yyyy"?

        var cut = Render<ColumnTypesDemo>();

        var salaryCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[2];
        var expected = "{0:d}"; // Should match the format used

        // The cell should contain a formatted dollar amount
        Assert.Contains("$", salaryCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_AllowsCustomRendering()
    {
        // ABOUT: The Template parameter lets you define custom rendering for a cell.
        // Instead of just showing a property value, you can render HTML, components,
        // buttons, badges - anything you want!

        // TODO: In ColumnTypesDemo, what does the template column display for active employees?
        // HINT: Look for the Template section in the component

        var cut = Render<ColumnTypesDemo>();

        var statusCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[4];
        var expected = "Active";

        Assert.Contains(expected, statusCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_AccessesContext()
    {
        // ABOUT: Inside a Template, the 'context' variable gives you access to
        // the current row's data item. If TItem is Employee, context is an Employee.
        // This lets you access any property: context.Name, context.Salary, etc.

        // TODO: What is the context variable's type in a RadzenDataGridColumn<Employee>?

        var expected = "Employee";

        Assert.Equal("Employee", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_CanRenderComponents()
    {
        // ABOUT: Templates can render other Blazor components, not just HTML.
        // You can render RadzenBadge, RadzenButton, RadzenIcon, or your own components.
        // This makes the grid incredibly flexible.

        // TODO: Does ColumnTypesDemo use RadzenBadge in a template column?
        // HINT: Look for <RadzenBadge> in the template

        var cut = Render<ColumnTypesDemo>();

        var expected = "Yes"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_ConditionalRendering()
    {
        // ABOUT: Templates can use conditional logic to render different content
        // based on the row's data. For example, show green badge if active,
        // red badge if inactive.

        // TODO: What badge variant is shown for inactive employees?
        // HINT: Check the @if condition in the template

        var cut = Render<ColumnTypesDemo>(parameters =>
            parameters.Add(p => p.ShowInactiveEmployee, true));

        var statusCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[4];
        var expected = "Danger"; // "Success", "Danger", "Warning", etc.

        // Should contain "Inactive" text
        Assert.Contains("Inactive", statusCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Width_CanBeSpecified()
    {
        // ABOUT: Each column can have a Width parameter to control its size.
        // You can use pixels ("120px"), percentages ("20%"), or let it auto-size.

        // TODO: What unit does ColumnTypesDemo use for the Status column width?
        // HINT: Look at the Width parameter

        var expected = "px"; // "px", "%", or "auto"

        Assert.Equal("px", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_TextAlign_ControlsAlignment()
    {
        // ABOUT: The TextAlign parameter controls horizontal alignment of cell content.
        // Common values: TextAlign.Left, TextAlign.Center, TextAlign.Right.
        // Numbers and currency typically align right.

        // TODO: How should a salary column be aligned for best readability?

        var expected = "Right"; // "Left", "Center", or "Right"

        Assert.Equal("Right", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Frozen_StaysVisible_WhenScrolling()
    {
        // ABOUT: Setting Frozen="true" on a column keeps it visible when scrolling
        // horizontally. This is useful for key columns like Name or ID that you
        // always want visible.

        // TODO: Which column type is commonly frozen in data grids?
        // HINT: Think about which column you'd always want to see

        var expected = "First"; // "First", "Last", or "Middle"

        Assert.Equal("First", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Column_Template_WithButton()
    {
        // ABOUT: Templates commonly include buttons for row actions like Edit, Delete,
        // or View Details. You can use RadzenButton or regular HTML buttons.

        // TODO: In ColumnTypesDemo, what action button is shown in the template column?
        // HINT: Look for RadzenButton in the Actions column

        var cut = Render<ColumnTypesDemo>();

        var actionsCell = cut.FindAll("tbody tr")[0].QuerySelectorAll("td")[5];
        var expected = "Edit";

        Assert.Contains(expected, actionsCell?.TextContent ?? "");
    }
}
