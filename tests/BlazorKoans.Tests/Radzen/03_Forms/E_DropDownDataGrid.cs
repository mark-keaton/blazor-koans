using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                      RADZEN DROPDOWN DATAGRID                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenDropDownDataGrid combines dropdown selection with DataGrid power:     ║
/// ║  - Display multiple columns for each selectable item                         ║
/// ║  - Filter and sort across all columns                                        ║
/// ║  - Select based on one property while displaying others                      ║
/// ║  - Template support for complex item rendering                               ║
/// ║  - Ideal for selecting complex objects (users, products, orders)             ║
/// ║                                                                              ║
/// ║  This component is perfect when a simple dropdown doesn't show enough        ║
/// ║  information for users to make an informed selection.                        ║
/// ║                                                                              ║
/// ║  Key Properties:                                                             ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  Data="@employees"              ← Data source for the grid             │  ║
/// ║  │  TextProperty="Name"            ← Property shown when closed           │  ║
/// ║  │  AllowFiltering="true"          ← Enable column filtering              │  ║
/// ║  │  AllowSorting="true"            ← Enable column sorting                │  ║
/// ║  │  Multiple="true"                ← Allow multi-select                   │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class E_DropDownDataGrid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_DisplaysMultipleColumns()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Column Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDropDownDataGrid shows a grid in the dropdown with multiple columns.
        // Each column displays different properties of the selectable items.
        //
        // Example - Defining columns:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid Data="@employees">                         │
        // │      <Columns>                                                      │
        // │          <RadzenDropDownDataGridColumn Property="FirstName" />      │
        // │          <RadzenDropDownDataGridColumn Property="LastName" />       │
        // │          <RadzenDropDownDataGridColumn Property="Department" />     │
        // │      </Columns>                                                     │
        // │  </RadzenDropDownDataGrid>                                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: How many columns does the Employee dropdown grid display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Column Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_BindsToComplexObject()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Complex Object Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Unlike RadzenDropDown which binds to a simple value,
        // RadzenDropDownDataGrid can bind to entire complex objects.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid @bind-Value="selectedEmployee"             │
        // │                          Data="@employees" />                       │
        // │                                                                     │
        // │  @code {                                                            │
        // │      Employee selectedEmployee;  // Binds to full object            │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What type is the SelectedEmployee bound to?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Employee Type: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_FilterableColumns()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Filtering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Each column can be filterable, allowing users to narrow down
        // options by multiple criteria simultaneously.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid AllowFiltering="true">                     │
        // │      <Columns>                                                      │
        // │          <RadzenDropDownDataGridColumn Property="Department"        │
        // │                                        Filterable="true" />         │
        // │      </Columns>                                                     │
        // │  </RadzenDropDownDataGrid>                                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After filtering by department "Engineering", how many employees match?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and filtering
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var filterInput = cut.Find("input[name='DepartmentFilter']");
        filterInput.Change("Engineering");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Filtered Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_TextProperty_SelectsColumn()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TextProperty Configuration
        // ═══════════════════════════════════════════════════════════════════════
        //
        // TextProperty determines which column's value is displayed
        // in the dropdown when closed. Often set to the primary identifier.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid TextProperty="FullName"                    │
        // │                          Data="@employees" />                       │
        // │                                                                     │
        // │  <!-- When closed, shows "John Smith" instead of object -->         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Which property is shown in the closed dropdown for Employee?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Text Property: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowFiltering_EnablesSearch()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Enabling Filtering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AllowFiltering=true on the component enables the filter row
        // across all columns in the grid.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid AllowFiltering="true" ... />               │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is filtering enabled for the Employee dropdown grid? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Allow Filtering: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowSorting_EnablesColumnSort()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Sorting
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AllowSorting=true allows clicking column headers to sort.
        // Users can sort by any column to find items easily.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid AllowSorting="true" ... />                 │
        // │  <!-- Click column header to sort ascending/descending -->          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After sorting by LastName, who appears first?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and sorting
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var lastNameHeader = cut.Find("th.lastname-header");
        lastNameHeader.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"First Employee: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Template_CustomCells()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Column Templates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Template on columns allows custom rendering.
        // Display badges, icons, formatted dates, etc.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGridColumn Property="Status">                   │
        // │      <Template>                                                     │
        // │          <RadzenBadge Text="@context.Status" />                     │
        // │      </Template>                                                    │
        // │  </RadzenDropDownDataGridColumn>                                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does the Status column use a custom template with badges? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Status Template: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_PageSize_LimitsVisibleRows()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Pagination in Dropdown
        // ═══════════════════════════════════════════════════════════════════════
        //
        // PageSize determines how many rows are visible in the dropdown.
        // Pagination appears if there are more items.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid PageSize="5" ... />                        │
        // │  <!-- Shows 5 rows at a time with pagination controls -->           │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the PageSize for the Employee dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Page Size: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Placeholder_ShowsWhenEmpty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Placeholder Text
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Placeholder text appears when no employee is selected.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid Placeholder="Select an employee..." />     │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the placeholder for the Employee dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var dropdown = cut.Find("input[name='Employee']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, dropdown.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_SelectionChanges_UpdatesValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Selection Handling
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a row is clicked, that object becomes the selected value.
        // The dropdown closes and displays the TextProperty value.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid @bind-Value="selected"                     │
        // │                          TextProperty="FullName" ... />             │
        // │  <!-- After selection: displays "John Smith" -->                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After selecting employee with ID 3, what name is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and selecting
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var row = cut.Find("tr[data-employee-id='3']");
        row.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Multiple_SelectsMany()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Multiple=true allows selecting multiple rows.
        // The bound value becomes IEnumerable<TItem>.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid Multiple="true"                            │
        // │                          @bind-Value="selectedEmployees" />         │
        // │                                                                     │
        // │  @code {                                                            │
        // │      IEnumerable<Employee> selectedEmployees;                       │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is the Project dropdown configured for multiple selection? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Multiple Projects: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_MultipleSelection_ShowsChips()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multi-Select Chips Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // With Multiple=true, selected items appear as chips/badges.
        // Each chip has a remove button to deselect.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [Project A ✕] [Project B ✕] [Project C ✕]                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After selecting 3 projects, how many chips are shown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and selecting projects
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var selectButton = cut.Find("button.select-projects");
        selectButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Chips: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_LoadData_DynamicLoading()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Server-Side Data Loading
        // ═══════════════════════════════════════════════════════════════════════
        //
        // LoadData event enables server-side filtering, sorting, and paging.
        // Essential for large datasets.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid LoadData="@LoadCustomers" ... />           │
        // │                                                                     │
        // │  @code {                                                            │
        // │      async Task LoadCustomers(LoadDataArgs args) {                  │
        // │          // Fetch data from server with args.Filter, args.Top       │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does the Customer dropdown use LoadData for server-side operations? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Uses LoadData: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowClear_ClearsSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AllowClear=true shows a clear button to remove selection.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid AllowClear="true" ... />                   │
        // │  <!-- Shows ✕ button when value is selected -->                     │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After selecting then clearing Employee, what is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering, selecting, then clearing
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var dropdown = cut.Find("input[name='Employee']");
        var row = cut.Find("tr[data-employee-id='1']");
        row.Click();
        var clearButton = cut.Find("button.clear-employee");
        clearButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Employee: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Disabled_PreventsSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabling the Dropdown
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Disabled=true prevents opening the dropdown and selecting items.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenDropDownDataGrid Disabled="true" ... />                     │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is the LockedEmployee dropdown disabled? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the DropDownDataGridDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropDownDataGridDemo>();
        var dropdown = cut.Find("input[name='LockedEmployee']");
        var isDisabled = dropdown.HasAttribute("disabled");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isDisabled.ToString());
    }
}
