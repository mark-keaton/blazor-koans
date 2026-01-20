using Bunit;
using BlazorKoans.App.Components.Exercises.Radzen;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenDropDownDataGrid combines dropdown selection with DataGrid power:
/// - Display multiple columns for each selectable item
/// - Filter and sort across all columns
/// - Select based on one property while displaying others
/// - Template support for complex item rendering
/// - Ideal for selecting complex objects (users, products, orders)
///
/// This component is perfect when a simple dropdown doesn't show enough
/// information for users to make an informed selection.
/// </summary>
public class E_DropDownDataGrid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_DisplaysMultipleColumns()
    {
        // ABOUT: RadzenDropDownDataGrid shows a grid in the dropdown with multiple columns.
        // Each column displays different properties of the selectable items.

        // TODO: How many columns does the Employee dropdown grid display?
        // Replace 0 with the number of columns

        var cut = Render<DropDownDataGridDemo>();

        var expected = 0;

        Assert.Contains($"Column Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_BindsToComplexObject()
    {
        // ABOUT: Unlike RadzenDropDown which binds to a simple value,
        // RadzenDropDownDataGrid can bind to entire complex objects.

        // TODO: What type is the SelectedEmployee bound to?
        // Replace "__" with the type name

        var cut = Render<DropDownDataGridDemo>();

        var expected = "__";

        Assert.Contains($"Employee Type: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_FilterableColumns()
    {
        // ABOUT: Each column can be filterable, allowing users to narrow down
        // options by multiple criteria simultaneously.

        // TODO: After filtering by department "Engineering", how many employees match?
        // Replace 0 with expected count

        var cut = Render<DropDownDataGridDemo>();

        var filterInput = cut.Find("input[name='DepartmentFilter']");
        filterInput.Change("Engineering");

        var expected = 0;

        Assert.Contains($"Filtered Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_TextProperty_SelectsColumn()
    {
        // ABOUT: TextProperty determines which column's value is displayed
        // in the dropdown when closed. Often set to the primary identifier.

        // TODO: Which property is shown in the closed dropdown for Employee?
        // Replace "__" with the property name

        var cut = Render<DropDownDataGridDemo>();

        var expected = "__";

        Assert.Contains($"Text Property: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowFiltering_EnablesSearch()
    {
        // ABOUT: AllowFiltering=true on the component enables the filter row
        // across all columns in the grid.

        // TODO: Is filtering enabled for the Employee dropdown grid?
        // Replace false with true or false

        var cut = Render<DropDownDataGridDemo>();

        var expected = false;

        Assert.Contains($"Allow Filtering: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowSorting_EnablesColumnSort()
    {
        // ABOUT: AllowSorting=true allows clicking column headers to sort.
        // Users can sort by any column to find items easily.

        // TODO: After sorting by LastName, who appears first?
        // Replace "__" with the last name

        var cut = Render<DropDownDataGridDemo>();

        var lastNameHeader = cut.Find("th.lastname-header");
        lastNameHeader.Click();

        var expected = "__";

        Assert.Contains($"First Employee: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Template_CustomCells()
    {
        // ABOUT: Template on columns allows custom rendering.
        // Display badges, icons, formatted dates, etc.

        // TODO: Does the Status column use a custom template with badges?
        // Replace false with true or false

        var cut = Render<DropDownDataGridDemo>();

        var expected = false;

        Assert.Contains($"Status Template: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_PageSize_LimitsVisibleRows()
    {
        // ABOUT: PageSize determines how many rows are visible in the dropdown.
        // Pagination appears if there are more items.

        // TODO: What is the PageSize for the Employee dropdown?
        // Replace 0 with the page size

        var cut = Render<DropDownDataGridDemo>();

        var expected = 0;

        Assert.Contains($"Page Size: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Placeholder_ShowsWhenEmpty()
    {
        // ABOUT: Placeholder text appears when no employee is selected.

        // TODO: What is the placeholder for the Employee dropdown?
        // Replace "__" with the placeholder text

        var cut = Render<DropDownDataGridDemo>();

        var expected = "__";

        var dropdown = cut.Find("input[name='Employee']");
        Assert.Equal(expected, dropdown.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_SelectionChanges_UpdatesValue()
    {
        // ABOUT: When a row is clicked, that object becomes the selected value.
        // The dropdown closes and displays the TextProperty value.

        // TODO: After selecting employee with ID 3, what name is displayed?
        // Replace "__" with the full name

        var cut = Render<DropDownDataGridDemo>();

        var row = cut.Find("tr[data-employee-id='3']");
        row.Click();

        var expected = "__";

        Assert.Contains($"Selected: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Multiple_SelectsMany()
    {
        // ABOUT: Multiple=true allows selecting multiple rows.
        // The bound value becomes IEnumerable<TItem>.

        // TODO: Is the Project dropdown configured for multiple selection?
        // Replace false with true or false

        var cut = Render<DropDownDataGridDemo>();

        var expected = false;

        Assert.Contains($"Multiple Projects: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_MultipleSelection_ShowsChips()
    {
        // ABOUT: With Multiple=true, selected items appear as chips/badges.
        // Each chip has a remove button to deselect.

        // TODO: After selecting 3 projects, how many chips are shown?
        // Replace 0 with expected count

        var cut = Render<DropDownDataGridDemo>();

        var selectButton = cut.Find("button.select-projects");
        selectButton.Click();

        var expected = 0;

        Assert.Contains($"Selected Chips: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_LoadData_DynamicLoading()
    {
        // ABOUT: LoadData event enables server-side filtering, sorting, and paging.
        // Essential for large datasets.

        // TODO: Does the Customer dropdown use LoadData for server-side operations?
        // Replace false with true or false

        var cut = Render<DropDownDataGridDemo>();

        var expected = false;

        Assert.Contains($"Uses LoadData: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_AllowClear_ClearsSelection()
    {
        // ABOUT: AllowClear=true shows a clear button to remove selection.

        // TODO: After selecting then clearing Employee, what is displayed?
        // Replace "__" with expected value

        var cut = Render<DropDownDataGridDemo>();

        var dropdown = cut.Find("input[name='Employee']");
        var row = cut.Find("tr[data-employee-id='1']");
        row.Click();

        var clearButton = cut.Find("button.clear-employee");
        clearButton.Click();

        var expected = "__";

        Assert.Contains($"Selected Employee: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDownDataGrid_Disabled_PreventsSelection()
    {
        // ABOUT: Disabled=true prevents opening the dropdown and selecting items.

        // TODO: Is the LockedEmployee dropdown disabled?
        // Replace false with true or false

        var cut = Render<DropDownDataGridDemo>();

        var expected = false;

        var dropdown = cut.Find("input[name='LockedEmployee']");
        var isDisabled = dropdown.HasAttribute("disabled");
        Assert.Equal(expected, isDisabled);
    }
}
