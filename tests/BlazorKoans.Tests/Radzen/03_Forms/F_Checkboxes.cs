using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    RADZEN CHECKBOXES AND SWITCHES                            ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenCheckBox, RadzenCheckBoxList, and RadzenSwitch provide boolean input: ║
/// ║  - RadzenCheckBox: Single true/false selection                               ║
/// ║  - RadzenCheckBoxList: Select multiple items from a list                     ║
/// ║  - RadzenSwitch: Toggle switch alternative to checkbox                       ║
/// ║  - Tristate support for nullable bool (true/false/null)                      ║
/// ║  - Change event for reacting to state changes                                ║
/// ║                                                                              ║
/// ║  These components replace HTML checkboxes with styled, accessible            ║
/// ║  alternatives that integrate with Radzen forms and themes.                   ║
/// ║                                                                              ║
/// ║  Key Components:                                                             ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  RadzenCheckBox<bool>          ← Single boolean                        │  ║
/// ║  │  RadzenCheckBox<bool?>         ← Nullable bool (tri-state)             │  ║
/// ║  │  RadzenCheckBoxList<T>         ← Multiple selection                    │  ║
/// ║  │  RadzenSwitch                  ← Toggle switch UI                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class F_Checkboxes : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_BindsToBoolean()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Boolean Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCheckBox<bool> binds to a boolean property.
        // Checked = true, Unchecked = false.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBox @bind-Value="acceptTerms" Name="AcceptTerms" />    │
        // │                                                                     │
        // │  @code {                                                            │
        // │      bool acceptTerms = false;                                      │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Check the property initialization in CheckboxesDemo
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Accept Terms: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TogglesValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Toggling Checkbox State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clicking the checkbox toggles between true and false.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Initial: false                                                     │
        // │  After click: true                                                  │
        // │  After second click: false                                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After clicking AcceptTerms, what is the new value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and clicking the checkbox
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var checkbox = cut.Find("input[name='AcceptTerms']");
        checkbox.Change(true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Accept Terms: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TriState_SupportsNull()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tri-State Checkboxes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // TriState=true allows three states: true, false, and null.
        // Useful for "Select All" scenarios or indeterminate states.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBox @bind-Value="newsletter" TriState="true" />        │
        // │                                                                     │
        // │  @code {                                                            │
        // │      bool? newsletter = null;  // nullable bool                     │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is the Newsletter checkbox configured for tri-state? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Tri-State: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_TriState_CyclesThroughStates()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tri-State Cycling
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In tri-state mode, clicking cycles: false -> true -> null -> false
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Click 1: false → true                                              │
        // │  Click 2: true → null (indeterminate)                               │
        // │  Click 3: null → false                                              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Starting at false, after clicking twice, what is the state?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and clicking twice
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var checkbox = cut.Find("input[name='Newsletter']");
        checkbox.Change(true);  // First click
        checkbox.Change(null);  // Second click

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Newsletter: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_SelectsMultiple()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Selection with CheckBoxList
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCheckBoxList displays multiple checkboxes for selecting
        // multiple items from a list. Binds to IEnumerable<TValue>.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList @bind-Value="selectedInterests"                │
        // │                      Data="@interests"                              │
        // │                      TextProperty="Name"                            │
        // │                      ValueProperty="Id" />                          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: How many interests are initially selected?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Interests: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_TextProperty_DisplaysLabel()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TextProperty for Labels
        // ═══════════════════════════════════════════════════════════════════════
        //
        // TextProperty specifies which property to display as the label.
        // ValueProperty specifies which property to bind.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList TextProperty="Name" ... />                     │
        // │  <!-- Displays: ☐ Reading  ☐ Music  ☐ Sports -->                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What property is used for displaying interest names?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Interests Text: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_ValueProperty_BindsId()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ValueProperty for Binding
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ValueProperty determines what values go into the bound collection.
        // Often the Id property of complex objects.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList ValueProperty="Id" ... />                      │
        // │  <!-- selectedInterests contains: ["reading", "music"] -->          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What property is used as the value for interests?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Interests Value: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_CheckingAddsToCollection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Adding Items to Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you check an item, its value is added to the bound collection.
        // Unchecking removes it from the collection.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Before: selectedInterests = []                                     │
        // │  Check "Reading": selectedInterests = ["reading"]                   │
        // │  Check "Music": selectedInterests = ["reading", "music"]            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After checking "Reading", how many interests are selected?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and checking an item
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var readingCheckbox = cut.Find("input[value='reading']");
        readingCheckbox.Change(true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Selected Interests: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Orientation_Horizontal()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Layout Orientation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Orientation property controls layout: Horizontal or Vertical.
        // Horizontal displays checkboxes in a row.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList Orientation="Orientation.Horizontal" ... />    │
        // │                                                                     │
        // │  Horizontal: ☐ A  ☐ B  ☐ C                                          │
        // │  Vertical:   ☐ A                                                    │
        // │              ☐ B                                                    │
        // │              ☐ C                                                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What orientation is used for the Interests checkbox list?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Orientation: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_AlternativeToCheckbox()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Switch Component
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenSwitch is a toggle switch UI alternative to checkbox.
        // Same binding as RadzenCheckBox but different visual appearance.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenSwitch @bind-Value="notifications" Name="Notifications" />  │
        // │                                                                     │
        // │  Visual: [○────] OFF   [────●] ON                                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the initial state of the Notifications switch? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Notifications: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_TogglesOnClick()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Toggling the Switch
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clicking the switch toggles between on (true) and off (false).
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Initial: [○────] OFF                                               │
        // │  After click: [────●] ON                                            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After toggling Notifications, what is the new state?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and toggling the switch
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var switchInput = cut.Find("input[name='Notifications']");
        switchInput.Change(true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Notifications: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_Change_Event()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Change Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Change event fires when the checkbox state changes.
        // Provides the new boolean value as the event argument.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBox @bind-Value="value"                                │
        // │                  Change="@OnChange" />                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void OnChange(bool? newValue) { /* handle change */ }          │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After changing AcceptTerms, what event name fires?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and changing the checkbox
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var checkbox = cut.Find("input[name='AcceptTerms']");
        checkbox.Change(true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Event Fired: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBox_Disabled_PreventsChange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabling Checkboxes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Disabled=true prevents clicking and changing the state.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBox @bind-Value="locked" Disabled="true" />            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is the LockedOption checkbox disabled? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var checkbox = cut.Find("input[name='LockedOption']");
        var isDisabled = checkbox.HasAttribute("disabled");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isDisabled.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Disabled_PreventsSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabling CheckBoxList
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Disabled=true on RadzenCheckBoxList disables all checkboxes.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList Disabled="true" ... />                         │
        // │  <!-- All checkboxes in the list are disabled -->                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Are the Features checkboxes disabled? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Features Disabled: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenSwitch_Text_ShowsLabel()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Switch Labels
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Text property displays a label next to the switch.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenSwitch Text="Enable Dark Mode" @bind-Value="darkMode" />    │
        // │                                                                     │
        // │  Displays: [────●] Enable Dark Mode                                 │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What text label is shown for the DarkMode switch?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the CheckboxesDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Dark Mode Label: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCheckBoxList_Change_FiresOnSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: CheckBoxList Change Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Change event on RadzenCheckBoxList fires when any checkbox changes.
        // Provides the updated collection as the event argument.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCheckBoxList Change="@OnInterestsChanged" ... />            │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void OnInterestsChanged(object value) {                        │
        // │          changeCount++;                                             │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After checking/unchecking two interests, how many times does Change fire?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and checking two items
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<CheckboxesDemo>();
        var checkbox1 = cut.Find("input[value='reading']");
        checkbox1.Change(true);
        var checkbox2 = cut.Find("input[value='music']");
        checkbox2.Change(true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Change Count: {answer}", cut.Markup);
    }
}
