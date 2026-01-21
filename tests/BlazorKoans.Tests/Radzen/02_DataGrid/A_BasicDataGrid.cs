using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            RADZEN DATAGRID BASICS                            ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenDataGrid is a powerful component that displays tabular data with      ║
/// ║  columns, rows, and various interactive features.                            ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees" TItem="Employee"&gt;                    │  ║
/// ║  │      &lt;Columns&gt;                                                         │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Name" Title="Name" /&gt;         │  ║
/// ║  │          &lt;RadzenDataGridColumn Property="Department" /&gt;                │  ║
/// ║  │      &lt;/Columns&gt;                                                        │  ║
/// ║  │  &lt;/RadzenDataGrid&gt;                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_BasicDataGrid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_RendersTable_WhenDataProvided()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RadzenDataGrid Renders as an HTML Table
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDataGrid renders as an HTML table. When you provide data,
        // it automatically creates rows for each item in your collection.
        // The TItem generic parameter tells the grid what type of data it's displaying.
        //
        // EXERCISE: What HTML element does RadzenDataGrid render as?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering BasicDataGridDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What HTML element selector finds the grid?      ║
        // ║                                                                    ║
        // ║  HINT: DataGrids traditionally use this semantic HTML element      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "table";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The grid renders as the expected HTML element
        // ───────────────────────────────────────────────────────────────────────
        Assert.NotNull(cut.Find(answer));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_DisplaysRows_ForEachEmployee()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Data Parameter Creates Rows
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Data parameter accepts an IEnumerable<TItem>. For each item
        // in the collection, the grid creates a row. If you have 5 employees,
        // you get 5 data rows (plus 1 header row).
        //
        // EXERCISE: How many data rows should appear for 5 employees?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid with employee data
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many data rows for 5 employees?             ║
        // ║                                                                    ║
        // ║  HINT: The header row doesn't count as a data row                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 5;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The tbody contains the expected number of rows
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_DefinesColumns_InColumnsSection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Columns Are Defined in a Columns Section
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDataGrid columns are defined inside a <Columns> section.
        // Each RadzenDataGridColumn represents one column in the table.
        // The Property parameter specifies which property of TItem to display.
        //
        // EXERCISE: How many columns are defined in BasicDataGridDemo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid to count columns
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many columns in the grid?                   ║
        // ║                                                                    ║
        // ║  HINT: Count the RadzenDataGridColumn elements (or th elements)    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 4;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The grid has the expected number of column headers
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("th").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_ColumnTitle_SetsHeaderText()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Title Parameter Sets Column Header Text
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Title parameter on RadzenDataGridColumn sets the column header text.
        // If you don't specify Title, it uses the Property name by default.
        //
        // EXERCISE: What is the title of the first column in BasicDataGridDemo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid to check header text
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the first column's title?               ║
        // ║                                                                    ║
        // ║  HINT: Look at the first <th> element's text content               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "Employee Name";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The first column header contains the expected text
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Find("th").TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_BindsToProperty_DisplaysValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Property Parameter Binds Data to Columns
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you set Property="Name" on a column, the grid automatically
        // displays the Name property from each item in your data collection.
        // This is data binding in action.
        //
        // EXERCISE: What is the name of the first employee in the grid?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and finding first cell
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();
        var firstCell = cut.FindAll("tbody tr")[0].QuerySelector("td");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What name appears in the first row?             ║
        // ║                                                                    ║
        // ║  HINT: Look at the first row's first cell content                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "Alice Johnson";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The first cell contains the expected employee name
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, firstCell?.TextContent ?? "");
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_TItem_SpecifiesDataType()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TItem Generic Parameter Defines Data Type
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The TItem generic parameter is crucial - it tells the DataGrid
        // what type of objects it's displaying. This enables type-safe property
        // binding and IntelliSense support.
        //
        // EXERCISE: What is TItem set to in BasicDataGridDemo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this conceptual question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What type is TItem in the demo?                 ║
        // ║                                                                    ║
        // ║  HINT: Look at the RadzenDataGrid declaration in the component     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "Employee";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: TItem is set to Employee
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Employee", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_EmptyData_RendersEmptyMessage()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Empty Collections Show No Data Rows
        // ═══════════════════════════════════════════════════════════════════════
        //
        // If you provide an empty collection to the Data parameter,
        // the grid still renders with headers. RadzenDataGrid may display
        // a "No records to display" message or show zero data rows.
        //
        // EXERCISE: How many tbody rows appear when the employee list is empty?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid with empty data
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>(parameters =>
            parameters.Add(p => p.UseEmptyData, true));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows with empty data?                  ║
        // ║                                                                    ║
        // ║  HINT: With no data, there are no data rows in tbody               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: No data rows are rendered
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_ColumnProperty_MustMatchDataType()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Property Must Match TItem Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Property parameter must match a property name on TItem.
        // If TItem is Employee, valid properties are Id, Name, Department, etc.
        // Type safety ensures you can't reference non-existent properties.
        //
        // EXERCISE: Which property does the second column display?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid to check second column
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();
        var secondHeader = cut.FindAll("th")[1];

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What property is shown in the second column?    ║
        // ║                                                                    ║
        // ║  HINT: Look at the second RadzenDataGridColumn in the component    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The second column header matches the expected property
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, secondHeader.TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_Reload_UpdatesWhenDataChanges()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reload() Refreshes the Grid After Data Changes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDataGrid doesn't automatically detect changes to the Data collection.
        // To refresh the grid after modifying data, use a component reference (@ref)
        // and call the Reload() method. This is the idiomatic Radzen pattern.
        //
        // EXERCISE: After adding an employee, how many rows should appear?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering grid and adding an employee
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<BasicDataGridDemo>();
        var initialCount = cut.FindAll("tbody tr").Count;
        cut.Find("button.add-employee").Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows after adding an employee?         ║
        // ║                                                                    ║
        // ║  HINT: Original count + 1                                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The grid shows the updated row count
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void DataGrid_Width_CanBeSetWithStyle()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Style Parameter Controls Grid Appearance
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can control the grid's appearance using the Style parameter.
        // Common uses include setting width, height, and enabling scrolling.
        //
        // EXERCISE: Does BasicDataGridDemo set a width on the DataGrid?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - no rendering needed for this inspection question
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo set a width?                      ║
        // ║                                                                    ║
        // ║  HINT: Look for a Style parameter in the component                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";  // "Yes" or "No"

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The answer matches expected behavior
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }
}
