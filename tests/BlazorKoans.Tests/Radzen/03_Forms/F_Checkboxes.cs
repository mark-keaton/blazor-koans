using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenCheckBox, RadzenCheckBoxList, and RadzenSwitch provide boolean input:
/// - RadzenCheckBox: Single true/false selection
/// - RadzenCheckBoxList: Select multiple items from a list
/// - RadzenSwitch: Toggle switch alternative to checkbox
/// - Tristate support for nullable bool (true/false/null)
/// - Change event for reacting to state changes
///
/// These components replace HTML checkboxes with styled, accessible alternatives
/// that integrate with Radzen forms and themes.
/// </summary>
public class F_Checkboxes : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_BindsToBoolean()
    {
        // ABOUT: RadzenCheckBox<bool> binds to a boolean property.
        // Checked = true, Unchecked = false.

        // TODO: Replace false with the initial state of AcceptTerms
        // HINT: Check the property initialization in CheckboxesDemo

        var cut = Render<CheckboxesDemo>();

        var expected = false;

        Assert.Contains($"Accept Terms: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TogglesValue()
    {
        // ABOUT: Clicking the checkbox toggles between true and false.

        // TODO: After clicking AcceptTerms, what is the new value?
        // Replace false with expected value

        var cut = Render<CheckboxesDemo>();

        var checkbox = cut.Find("input[name='AcceptTerms']");
        checkbox.Change(true);

        var expected = true;

        Assert.Contains($"Accept Terms: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TriState_SupportsNull()
    {
        // ABOUT: TriState=true allows three states: true, false, and null.
        // Useful for "Select All" scenarios or indeterminate states.

        // TODO: Is the Newsletter checkbox configured for tri-state?
        // Replace false with true or false

        var cut = Render<CheckboxesDemo>();

        var expected = true;

        Assert.Contains($"Tri-State: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TriState_CyclesThroughStates()
    {
        // ABOUT: In tri-state mode, clicking cycles: false -> true -> null -> false

        // TODO: Starting at false, after clicking twice, what is the state?
        // Replace "__" with the state (true/false/null)

        var cut = Render<CheckboxesDemo>();

        var checkbox = cut.Find("input[name='Newsletter']");
        checkbox.Change(true);  // First click
        checkbox.Change(null);  // Second click

        var expected = "null";

        Assert.Contains($"Newsletter: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_SelectsMultiple()
    {
        // ABOUT: RadzenCheckBoxList displays multiple checkboxes for selecting
        // multiple items from a list. Binds to IEnumerable<TValue>.

        // TODO: How many interests are initially selected?
        // Replace 0 with the count

        var cut = Render<CheckboxesDemo>();

        var expected = 0;

        Assert.Contains($"Selected Interests: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_TextProperty_DisplaysLabel()
    {
        // ABOUT: TextProperty specifies which property to display as the label.
        // ValueProperty specifies which property to bind.

        // TODO: What property is used for displaying interest names?
        // Replace "__" with the property name

        var cut = Render<CheckboxesDemo>();

        var expected = "Name";

        Assert.Contains($"Interests Text: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_ValueProperty_BindsId()
    {
        // ABOUT: ValueProperty determines what values go into the bound collection.
        // Often the Id property of complex objects.

        // TODO: What property is used as the value for interests?
        // Replace "__" with the property name

        var cut = Render<CheckboxesDemo>();

        var expected = "Id";

        Assert.Contains($"Interests Value: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_CheckingAddsToCollection()
    {
        // ABOUT: When you check an item, its value is added to the bound collection.
        // Unchecking removes it from the collection.

        // TODO: After checking "Reading", how many interests are selected?
        // Replace 0 with expected count

        var cut = Render<CheckboxesDemo>();

        var readingCheckbox = cut.Find("input[value='reading']");
        readingCheckbox.Change(true);

        var expected = 1;

        Assert.Contains($"Selected Interests: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Orientation_Horizontal()
    {
        // ABOUT: Orientation property controls layout: Horizontal or Vertical.
        // Horizontal displays checkboxes in a row.

        // TODO: What orientation is used for the Interests checkbox list?
        // Replace "__" with "Horizontal" or "Vertical"

        var cut = Render<CheckboxesDemo>();

        var expected = "Horizontal";

        Assert.Contains($"Orientation: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_AlternativeToCheckbox()
    {
        // ABOUT: RadzenSwitch is a toggle switch UI alternative to checkbox.
        // Same binding as RadzenCheckBox but different visual appearance.

        // TODO: What is the initial state of the Notifications switch?
        // Replace false with true or false

        var cut = Render<CheckboxesDemo>();

        var expected = false;

        Assert.Contains($"Notifications: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_TogglesOnClick()
    {
        // ABOUT: Clicking the switch toggles between on (true) and off (false).

        // TODO: After toggling Notifications, what is the new state?
        // Replace false with expected value

        var cut = Render<CheckboxesDemo>();

        var switchInput = cut.Find("input[name='Notifications']");
        switchInput.Change(true);

        var expected = true;

        Assert.Contains($"Notifications: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_Change_Event()
    {
        // ABOUT: Change event fires when the checkbox state changes.
        // Provides the new boolean value as the event argument.

        // TODO: After changing AcceptTerms, what event name fires?
        // Replace "__" with event name

        var cut = Render<CheckboxesDemo>();

        var checkbox = cut.Find("input[name='AcceptTerms']");
        checkbox.Change(true);

        var expected = "AcceptTermsChange";

        Assert.Contains($"Event Fired: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_Disabled_PreventsChange()
    {
        // ABOUT: Disabled=true prevents clicking and changing the state.

        // TODO: Is the LockedOption checkbox disabled?
        // Replace false with true or false

        var cut = Render<CheckboxesDemo>();

        var expected = true;

        var checkbox = cut.Find("input[name='LockedOption']");
        var isDisabled = checkbox.HasAttribute("disabled");
        Assert.Equal(expected, isDisabled);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Disabled_PreventsSelection()
    {
        // ABOUT: Disabled=true on RadzenCheckBoxList disables all checkboxes.

        // TODO: Are the Features checkboxes disabled?
        // Replace false with true or false

        var cut = Render<CheckboxesDemo>();

        var expected = true;

        Assert.Contains($"Features Disabled: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_Text_ShowsLabel()
    {
        // ABOUT: The Text property displays a label next to the switch.

        // TODO: What text label is shown for the DarkMode switch?
        // Replace "__" with the label text

        var cut = Render<CheckboxesDemo>();

        var expected = "Enable Dark Mode";

        Assert.Contains($"Dark Mode Label: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Change_FiresOnSelection()
    {
        // ABOUT: Change event on RadzenCheckBoxList fires when any checkbox changes.
        // Provides the updated collection as the event argument.

        // TODO: After checking/unchecking an interest, how many times does Change fire?
        // Replace 0 with expected count

        var cut = Render<CheckboxesDemo>();

        var checkbox1 = cut.Find("input[value='reading']");
        checkbox1.Change(true);

        var checkbox2 = cut.Find("input[value='music']");
        checkbox2.Change(true);

        var expected = 2;

        Assert.Contains($"Change Count: {expected}", cut.Markup);
    }
}
