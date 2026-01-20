using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// RadzenDataGrid is a powerful data grid component that displays tabular data.
/// It's the foundation for presenting collections of data in a table format with
/// columns, rows, and various interactive features.
///
/// Think of RadzenDataGrid as a spreadsheet in your web app - it shows data in rows
/// and columns, and can do so much more with sorting, filtering, and paging.
/// </summary>
public class A_BasicDataGrid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_RendersTable_WhenDataProvided()
    {
        // ABOUT: RadzenDataGrid renders as an HTML table. When you provide data,
        // it automatically creates rows for each item in your collection.
        // The TItem generic parameter tells the grid what type of data it's displaying.

        // TODO: What HTML element does RadzenDataGrid render as?
        // HINT: DataGrids traditionally use this semantic HTML element

        var cut = Render<BasicDataGridDemo>();

        var expected = "table";

        Assert.NotNull(cut.Find(expected));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_DisplaysRows_ForEachEmployee()
    {
        // ABOUT: The Data parameter accepts an IEnumerable<TItem>. For each item
        // in the collection, the grid creates a row. If you have 5 employees,
        // you get 5 data rows (plus 1 header row).

        // TODO: How many data rows should appear for 5 employees?
        // HINT: The header row doesn't count as a data row

        var cut = Render<BasicDataGridDemo>();

        var expected = 5;

        Assert.Equal(expected, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_DefinesColumns_InColumnsSection()
    {
        // ABOUT: RadzenDataGrid columns are defined inside a <Columns> section.
        // Each RadzenDataGridColumn represents one column in the table.
        // The Property parameter specifies which property of TItem to display.

        // TODO: How many columns are defined in BasicDataGridDemo?
        // HINT: Count the RadzenDataGridColumn elements

        var cut = Render<BasicDataGridDemo>();

        var expected = 4;

        Assert.Equal(expected, cut.FindAll("th").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_ColumnTitle_SetsHeaderText()
    {
        // ABOUT: The Title parameter on RadzenDataGridColumn sets the column header text.
        // If you don't specify Title, it uses the Property name by default.

        // TODO: What is the title of the first column in BasicDataGridDemo?
        // HINT: Look at the first <th> element's text content

        var cut = Render<BasicDataGridDemo>();

        var expected = "Employee Name";

        Assert.Contains(expected, cut.Find("th").TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_BindsToProperty_DisplaysValue()
    {
        // ABOUT: When you set Property="Name" on a column, the grid automatically
        // displays the Name property from each item in your data collection.
        // This is data binding in action.

        // TODO: What is the name of the first employee in the grid?
        // HINT: Look at the first row's first cell

        var cut = Render<BasicDataGridDemo>();

        var firstCell = cut.FindAll("tbody tr")[0].QuerySelector("td");
        var expected = "Alice Johnson";

        Assert.Contains(expected, firstCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_TItem_SpecifiesDataType()
    {
        // ABOUT: The TItem generic parameter is crucial - it tells the DataGrid
        // what type of objects it's displaying. This enables type-safe property
        // binding and IntelliSense support.

        // TODO: What is TItem set to in BasicDataGridDemo?
        // HINT: Look at the RadzenDataGrid declaration

        var expected = "Employee";

        Assert.Equal("Employee", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_EmptyData_RendersEmptyMessage()
    {
        // ABOUT: If you provide an empty collection to the Data parameter,
        // the grid still renders with headers. RadzenDataGrid also displays
        // a "No records to display" message in a single tbody row.
        // This provides user feedback when there's no data.

        // TODO: How many tbody rows appear when the employee list is empty?
        // HINT: RadzenDataGrid shows a message row, not an empty tbody

        var cut = Render<BasicDataGridDemo>(parameters =>
            parameters.Add(p => p.UseEmptyData, true));

        var expected = 0;

        Assert.Equal(expected, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_ColumnProperty_MustMatchDataType()
    {
        // ABOUT: The Property parameter must match a property name on TItem.
        // If TItem is Employee, valid properties are Id, Name, Department, etc.
        // Type safety ensures you can't reference non-existent properties.

        // TODO: Which property does the second column display?
        // HINT: Look at the second RadzenDataGridColumn

        var cut = Render<BasicDataGridDemo>();

        var secondHeader = cut.FindAll("th")[1];
        var expected = "__";

        Assert.Contains(expected, secondHeader.TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_AutoRefresh_UpdatesWhenDataChanges()
    {
        // ABOUT: RadzenDataGrid automatically updates when the Data collection changes.
        // If you modify the collection and call StateHasChanged(), the grid re-renders
        // to reflect the new data.

        // TODO: After adding an employee, how many rows should appear?
        // HINT: Original count + 1

        var cut = Render<BasicDataGridDemo>();

        // Initial count
        var initialCount = cut.FindAll("tbody tr").Count;

        // Add an employee
        cut.Find("button.add-employee").Click();

        var expected = 0;

        Assert.Equal(expected, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_Width_CanBeSetWithStyle()
    {
        // ABOUT: You can control the grid's appearance using the Style parameter.
        // Common uses include setting width, height, and enabling scrolling.

        // TODO: Does BasicDataGridDemo set a width on the DataGrid?
        // HINT: Look for a Style parameter

        var expected = "__"; // "Yes" or "No"

        Assert.Equal("Yes", expected);
    }
}
