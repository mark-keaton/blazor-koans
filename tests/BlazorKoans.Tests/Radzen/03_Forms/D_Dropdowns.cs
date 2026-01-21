using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          RADZEN DROPDOWNS                                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenDropDown and RadzenAutoComplete provide powerful selection with       ║
/// ║  filtering, multiple selection, and complex object binding support.          ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDropDown TValue="int" @bind-Value="model.CountryId"           │  ║
/// ║  │                  Data="@countries" TextProperty="Name"                 │  ║
/// ║  │                  ValueProperty="Id" AllowFiltering="true" /&gt;           │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenAutoComplete @bind-Value="model.City" Data="@cities"          │  ║
/// ║  │                      TextProperty="Name" MinLength="2" /&gt;              │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_Dropdowns : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_BindsToValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Basic DropDown Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDropDown<TValue> binds to a property of type TValue.
        // Use Data property to provide the list of items.
        //
        // EXERCISE: What is the initially selected country?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What country is selected?                       ║
        // ║                                                                    ║
        // ║  HINT: Check SelectedCountryId in DropdownsDemo                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the selected country
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Country: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_TextProperty_DisplaysText()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TextProperty for Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // TextProperty specifies which property to display in the dropdown.
        // ValueProperty specifies which property to bind to @bind-Value.
        //
        // EXERCISE: What property is used for display text in the Country dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the TextProperty?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the text property
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Text Property: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_ValueProperty_BindsId()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ValueProperty for Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ValueProperty determines what value is bound when an item is selected.
        // Common pattern: display Name, bind Id.
        //
        // EXERCISE: What property is used as the value in the Country dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the ValueProperty?                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the value property
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Value Property: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_AllowFiltering_EnablesSearch()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Filtering with Search
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AllowFiltering=true adds a search box to filter items.
        // Users can type to find items quickly in long lists.
        //
        // EXERCISE: Is filtering enabled for the Country dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is AllowFiltering enabled?                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms filtering setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Allow Filtering: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Placeholder_ShowsWhenEmpty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Placeholder for Empty Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Placeholder displays when no value is selected.
        // Useful for nullable types where no selection is valid.
        //
        // EXERCISE: What is the placeholder for the Status dropdown?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the dropdown
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var dropdown = cut.Find("select[name='Status']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the placeholder text?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The placeholder attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, dropdown.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Multiple_SelectsMany()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Selection Mode
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Multiple=true allows selecting multiple items.
        // The bound value changes to IEnumerable<TValue>.
        //
        // EXERCISE: Is the Tags dropdown configured for multiple selection?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is Multiple enabled?                            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms multiple selection setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Multiple Selection: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_MultipleSelection_BindsCollection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Binding Multiple Selections
        // ═══════════════════════════════════════════════════════════════════════
        //
        // With Multiple=true, @bind-Value binds to IEnumerable<TValue>.
        // The component displays selected items as chips.
        //
        // EXERCISE: After selecting multiple tags, how many are selected?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and select multiple tags
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var tagsButton = cut.Find("button.select-multiple-tags");
        tagsButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many tags are selected?                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the selected count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Tags Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_FiltersOnInput()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: AutoComplete Filtering
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenAutoComplete shows suggestions as you type.
        // It filters the Data based on the search term.
        //
        // EXERCISE: After typing "Ca", how many cities match?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and type in autocomplete
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var autocomplete = cut.Find("input[name='City']");
        autocomplete.Input("Ca");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many cities match "Ca"?                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the filtered count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Filtered Cities: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_MinimumLength_RequiresChars()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Minimum Input Length
        // ═══════════════════════════════════════════════════════════════════════
        //
        // FilterDelay and MinimumLength control when filtering happens.
        // MinimumLength requires typing at least N characters before suggestions.
        //
        // EXERCISE: What is the minimum character count for City autocomplete?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the minimum length?                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the minimum length
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Min Length: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_AllowClear_ClearsSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing AutoComplete Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AllowClear=true shows a clear button to remove selection.
        // Useful for optional fields.
        //
        // EXERCISE: After selecting a city then clicking clear, what is the value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render, select, and clear
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var autocomplete = cut.Find("input[name='City']");
        autocomplete.Input("Chicago");
        autocomplete.Change("Chicago");
        var clearButton = cut.Find("button.clear-city");
        clearButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the value after clearing?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the cleared value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected City: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Template_CustomRendering()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Item Templates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Template property allows custom HTML for each item.
        // Access the item data via @context.
        //
        // EXERCISE: Does the Priority dropdown use a custom template?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it use a custom template?                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms template setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Has Custom Template: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Change_Event()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Change Event Handling
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Change event fires when selection changes.
        // Provides the selected value(s) as the event argument.
        //
        // EXERCISE: After changing the country, what event fires?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and change selection
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var dropdown = cut.Find("select[name='Country']");
        dropdown.Change("2");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What event name is fired?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the event fired
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Event Fired: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_Disabled_PreventsSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabled DropDowns
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Disabled=true prevents changing the selection.
        // The dropdown appears grayed out.
        //
        // EXERCISE: Is the LockedField dropdown disabled?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the dropdown
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var dropdown = cut.Find("select[name='LockedField']");
        var isDisabled = dropdown.HasAttribute("disabled");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is LockedField disabled?                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The disabled state matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isDisabled);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenAutoComplete_LoadData_DynamicLoading()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Dynamic Data Loading
        // ═══════════════════════════════════════════════════════════════════════
        //
        // LoadData event allows fetching data based on search term.
        // Useful for large datasets or API-based suggestions.
        //
        // EXERCISE: Does the Product autocomplete use LoadData?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it use LoadData?                           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms LoadData setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Uses LoadData: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDropDown_AllowClear_NullableTypes()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Nullable DropDowns
        // ═══════════════════════════════════════════════════════════════════════
        //
        // With AllowClear=true and nullable TValue, the dropdown can be cleared.
        // The bound value becomes null.
        //
        // EXERCISE: After selecting then clearing Status, what is the value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render, select, and clear
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DropdownsDemo>();
        var dropdown = cut.Find("select[name='Status']");
        dropdown.Change("Active");
        var clearButton = cut.Find("button.clear-status");
        clearButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the value after clearing?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the cleared value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Status: {answer}", cut.Markup);
    }
}
