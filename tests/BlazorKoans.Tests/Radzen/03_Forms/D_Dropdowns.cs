using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenDropDown and RadzenAutoComplete provide powerful selection capabilities:
/// - RadzenDropDown: Single/multiple selection from a list
/// - RadzenAutoComplete: Searchable dropdown with filtering
/// - Data binding to complex objects
/// - TextProperty and ValueProperty for display/value separation
/// - AllowFiltering for instant search
/// - Template support for custom item rendering
///
/// These components replace basic HTML select elements with rich,
/// searchable, and themeable alternatives.
/// </summary>
public class D_Dropdowns : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_BindsToValue()
    {
        // ABOUT: RadzenDropDown<TValue> binds to a property of type TValue.
        // Use Data property to provide the list of items.

        // TODO: Replace "__" with the initially selected country
        // HINT: Check SelectedCountryId in DropdownsDemo

        var cut = Render<DropdownsDemo>();

        var expected = "United States";

        Assert.Contains($"Selected Country: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_TextProperty_DisplaysText()
    {
        // ABOUT: TextProperty specifies which property to display in the dropdown.
        // ValueProperty specifies which property to bind to @bind-Value.

        // TODO: What property is used for display text in the Country dropdown?
        // Replace "__" with the property name

        var cut = Render<DropdownsDemo>();

        var expected = "Name";

        Assert.Contains($"Text Property: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_ValueProperty_BindsId()
    {
        // ABOUT: ValueProperty determines what value is bound when an item is selected.
        // Common pattern: display Name, bind Id.

        // TODO: What property is used as the value in the Country dropdown?
        // Replace "__" with the property name

        var cut = Render<DropdownsDemo>();

        var expected = "Id";

        Assert.Contains($"Value Property: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_AllowFiltering_EnablesSearch()
    {
        // ABOUT: AllowFiltering=true adds a search box to filter items.
        // Users can type to find items quickly in long lists.

        // TODO: Is filtering enabled for the Country dropdown?
        // Replace false with true or false

        var cut = Render<DropdownsDemo>();

        var expected = true;

        Assert.Contains($"Allow Filtering: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Placeholder_ShowsWhenEmpty()
    {
        // ABOUT: Placeholder displays when no value is selected.
        // Useful for nullable types where no selection is valid.

        // TODO: What is the placeholder for the Status dropdown?
        // Replace "__" with the placeholder text

        var cut = Render<DropdownsDemo>();

        var expected = "Select a status";

        var dropdown = cut.Find("select[name='Status']");
        Assert.Equal(expected, dropdown.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Multiple_SelectsMany()
    {
        // ABOUT: Multiple=true allows selecting multiple items.
        // The bound value changes to IEnumerable<TValue>.

        // TODO: Is the Tags dropdown configured for multiple selection?
        // Replace false with true or false

        var cut = Render<DropdownsDemo>();

        var expected = true;

        Assert.Contains($"Multiple Selection: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_MultipleSelection_BindsCollection()
    {
        // ABOUT: With Multiple=true, @bind-Value binds to IEnumerable<TValue>.
        // The component displays selected items as chips.

        // TODO: After selecting multiple tags, how many are selected?
        // Replace 0 with expected count

        var cut = Render<DropdownsDemo>();

        // Simulate selecting multiple items
        var tagsButton = cut.Find("button.select-multiple-tags");
        tagsButton.Click();

        var expected = 3;

        Assert.Contains($"Selected Tags Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_FiltersOnInput()
    {
        // ABOUT: RadzenAutoComplete shows suggestions as you type.
        // It filters the Data based on the search term.

        // TODO: After typing "Ca", how many cities match?
        // Replace 0 with the expected count

        var cut = Render<DropdownsDemo>();

        var autocomplete = cut.Find("input[name='City']");
        autocomplete.Input("Ca");

        var expected = 4;

        Assert.Contains($"Filtered Cities: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_MinimumLength_RequiresChars()
    {
        // ABOUT: FilterDelay and MinimumLength control when filtering happens.
        // MinimumLength requires typing at least N characters before showing suggestions.

        // TODO: What is the minimum character count for City autocomplete?
        // Replace 0 with the minimum length

        var cut = Render<DropdownsDemo>();

        var expected = 2;

        Assert.Contains($"Min Length: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_AllowClear_ClearsSelection()
    {
        // ABOUT: AllowClear=true shows a clear button to remove selection.
        // Useful for optional fields.

        // TODO: After selecting a city then clicking clear, what is the value?
        // Replace "__" with expected value

        var cut = Render<DropdownsDemo>();

        var autocomplete = cut.Find("input[name='City']");
        autocomplete.Input("Chicago");
        autocomplete.Change("Chicago");

        var clearButton = cut.Find("button.clear-city");
        clearButton.Click();

        var expected = "null";

        Assert.Contains($"Selected City: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Template_CustomRendering()
    {
        // ABOUT: Template property allows custom HTML for each item.
        // Access the item data via @context.

        // TODO: Does the Priority dropdown use a custom template?
        // Replace false with true or false

        var cut = Render<DropdownsDemo>();

        var expected = true;

        Assert.Contains($"Has Custom Template: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Change_Event()
    {
        // ABOUT: Change event fires when selection changes.
        // Provides the selected value(s) as the event argument.

        // TODO: After changing the country, what event fires?
        // Replace "__" with event name

        var cut = Render<DropdownsDemo>();

        var dropdown = cut.Find("select[name='Country']");
        dropdown.Change("2");

        var expected = "CountryChange";

        Assert.Contains($"Event Fired: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Disabled_PreventsSelection()
    {
        // ABOUT: Disabled=true prevents changing the selection.
        // The dropdown appears grayed out.

        // TODO: Is the LockedField dropdown disabled?
        // Replace false with true or false

        var cut = Render<DropdownsDemo>();

        var expected = true;

        var dropdown = cut.Find("select[name='LockedField']");
        var isDisabled = dropdown.HasAttribute("disabled");
        Assert.Equal(expected, isDisabled);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_LoadData_DynamicLoading()
    {
        // ABOUT: LoadData event allows fetching data based on search term.
        // Useful for large datasets or API-based suggestions.

        // TODO: Does the Product autocomplete use LoadData?
        // Replace false with true or false

        var cut = Render<DropdownsDemo>();

        var expected = true;

        Assert.Contains($"Uses LoadData: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_AllowClear_NullableTypes()
    {
        // ABOUT: With AllowClear=true and nullable TValue, the dropdown can be cleared.
        // The bound value becomes null.

        // TODO: After selecting then clearing Status, what is the value?
        // Replace "__" with expected value

        var cut = Render<DropdownsDemo>();

        var dropdown = cut.Find("select[name='Status']");
        dropdown.Change("Active");

        var clearButton = cut.Find("button.clear-status");
        clearButton.Click();

        var expected = "null";

        Assert.Contains($"Status: {expected}", cut.Markup);
    }
}
