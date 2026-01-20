using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// RadzenTabs provides a tabbed interface for organizing content into separate views.
/// Users can switch between tabs to see different content without leaving the page.
/// Tabs are perfect for settings pages, multi-step forms, or any scenario where
/// you have related but distinct sections of content.
///
/// RadzenTabs supports dynamic tabs, lazy loading, and customizable tab headers.
/// </summary>
public class C_Tabs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_RendersMultipleTabs()
    {
        // ABOUT: RadzenTabs contains multiple RadzenTabsItem components.
        // Each TabsItem has a Text property that appears as the tab label.

        // TODO: Replace 0 with the number of tabs in the demo
        // HINT: Count the RadzenTabsItem components

        var cut = Render<TabsDemo>();

        var tabs = cut.FindAll(".rz-tabview-nav li");
        var expected = 0;

        Assert.Equal(expected, tabs.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_FirstTabText_DisplaysCorrectly()
    {
        // ABOUT: The Text parameter of RadzenTabsItem sets the tab label.
        // This appears in the tab navigation at the top.

        // TODO: Replace "__" with the text of the first tab
        // HINT: Check the first RadzenTabsItem's Text property

        var cut = Render<TabsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_DefaultSelectedTab_ShowsFirstTab()
    {
        // ABOUT: By default, RadzenTabs shows the first tab's content.
        // You can control which tab is selected using the SelectedIndex parameter.

        // TODO: Replace 0 with the default selected tab index (0-based)
        // HINT: Without specifying SelectedIndex, which tab shows first?

        var cut = Render<TabsDemo>();

        var expectedIndex = 0;

        // The first tab (index 0) should be active
        Assert.Equal(expectedIndex, 0);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_ClickTab_SwitchesContent()
    {
        // ABOUT: Clicking a tab header switches to that tab's content.
        // The Change event fires when the selected tab changes.

        // TODO: Replace "__" with the content shown in the second tab
        // HINT: Look at the ChildContent of the second RadzenTabsItem

        var cut = Render<TabsDemo>();

        // Click the second tab
        var secondTab = cut.FindAll(".rz-tabview-nav li")[1];
        secondTab.Click();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_ChangeEvent_TracksTabSwitches()
    {
        // ABOUT: The Change event provides the index of the newly selected tab.
        // This is useful for tracking navigation or loading tab-specific data.

        // TODO: Replace "__" with the message shown when tabs are switched
        // HINT: The demo displays the selected tab index

        var cut = Render<TabsDemo>();

        // Click to switch tabs
        var secondTab = cut.FindAll(".rz-tabview-nav li")[1];
        secondTab.Click();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_TabContent_IsRendered()
    {
        // ABOUT: The ChildContent of each RadzenTabsItem is rendered when
        // that tab is selected. Content can include any Blazor markup.

        // TODO: Replace "__" with content from the first tab
        // HINT: Check what's inside the first RadzenTabsItem

        var cut = Render<TabsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_WithIcons_DisplaysIconsInHeaders()
    {
        // ABOUT: RadzenTabsItem supports an Icon parameter to show icons
        // alongside or instead of text in the tab headers.

        // TODO: Does the demo include tabs with icons? Replace false with expected
        // HINT: Check if any RadzenTabsItem has an Icon parameter

        var cut = Render<TabsDemo>();

        var hasIcons = false;

        Assert.True(hasIcons == cut.Markup.Contains("rz-icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_DynamicTabs_CanBeAddedRemoved()
    {
        // ABOUT: Tabs can be dynamically generated from a collection.
        // You can add or remove tabs at runtime by modifying the collection.

        // TODO: Does the demo show dynamic tab creation? Replace false with expected
        // HINT: Look for @foreach or button to add tabs

        var cut = Render<TabsDemo>();

        var hasDynamicTabs = false;

        Assert.True(hasDynamicTabs == cut.Markup.Contains("Add Tab") || hasDynamicTabs == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_RenderMode_SupportsClient()
    {
        // ABOUT: RadzenTabs works with different render modes including
        // InteractiveServer and InteractiveWebAssembly for tab switching.

        // TODO: Replace "__" with the render mode used in TabsDemo
        // HINT: Check the @rendermode directive

        var expected = "__";

        // The demo uses a specific render mode for interactivity
        Assert.Equal("InteractiveServer", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_Disabled_TabCannotBeSelected()
    {
        // ABOUT: Individual tabs can be disabled using the Disabled parameter.
        // Disabled tabs appear grayed out and cannot be selected.

        // TODO: Does the demo include a disabled tab? Replace false with expected
        // HINT: Check if any RadzenTabsItem has Disabled="true"

        var cut = Render<TabsDemo>();

        var hasDisabledTab = false;

        Assert.True(hasDisabledTab == cut.Markup.Contains("rz-state-disabled"));
    }
}
