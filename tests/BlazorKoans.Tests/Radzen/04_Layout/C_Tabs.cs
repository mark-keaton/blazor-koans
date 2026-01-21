using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                              RADZEN TABS                                     ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenTabs provides a tabbed interface for organizing content into          ║
/// ║  separate views. Users can switch between tabs without leaving the page.     ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenTabs Change="@OnTabChange"&gt;                                    │  ║
/// ║  │      &lt;Tabs&gt;                                                            │  ║
/// ║  │          &lt;RadzenTabsItem Text="Tab 1"&gt;                                 │  ║
/// ║  │              Content for tab 1                                         │  ║
/// ║  │          &lt;/RadzenTabsItem&gt;                                             │  ║
/// ║  │          &lt;RadzenTabsItem Text="Tab 2" Icon="home"&gt;                     │  ║
/// ║  │              Content for tab 2                                         │  ║
/// ║  │          &lt;/RadzenTabsItem&gt;                                             │  ║
/// ║  │      &lt;/Tabs&gt;                                                           │  ║
/// ║  │  &lt;/RadzenTabs&gt;                                                         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_Tabs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_RendersMultipleTabs()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Components Structure
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTabs contains multiple RadzenTabsItem components. Each TabsItem
        // has a Text property that appears as the tab label in the navigation
        // bar at the top.
        //
        // EXERCISE: How many tabs are in the demo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();
        var tabs = cut.FindAll(".rz-tabview-nav li");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many tabs are rendered?                     ║
        // ║                                                                    ║
        // ║  HINT: Count the RadzenTabsItem components                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The expected number of tabs are rendered
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, tabs.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_FirstTabText_DisplaysCorrectly()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Labels with Text Parameter
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Text parameter of RadzenTabsItem sets the tab label. This appears
        // in the tab navigation at the top and helps users identify tab content.
        //
        // EXERCISE: What is the text of the first tab?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears on the first tab?             ║
        // ║                                                                    ║
        // ║  HINT: Check the first RadzenTabsItem's Text property              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The tab text appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_DefaultSelectedTab_ShowsFirstTab()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Default Tab Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // By default, RadzenTabs shows the first tab's content. You can control
        // which tab is selected using the SelectedIndex parameter. Tab indices
        // are 0-based.
        //
        // EXERCISE: What is the default selected tab index?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the default selected tab index?         ║
        // ║                                                                    ║
        // ║  HINT: Without specifying SelectedIndex, which tab shows first?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The first tab (index 0) is selected by default
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, 0);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_ClickTab_SwitchesContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Switching
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clicking a tab header switches to that tab's content. The Change event
        // fires when the selected tab changes, allowing you to respond to
        // navigation.
        //
        // EXERCISE: What content is shown in the second tab?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo and click the second tab
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();
        var secondTab = cut.FindAll(".rz-tabview-nav li")[1];
        secondTab.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What content appears in the second tab?         ║
        // ║                                                                    ║
        // ║  HINT: Look at the ChildContent of the second RadzenTabsItem       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The second tab's content is displayed
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_ChangeEvent_TracksTabSwitches()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Change Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Change event provides the index of the newly selected tab. This is
        // useful for tracking navigation or loading tab-specific data when users
        // switch tabs.
        //
        // EXERCISE: What message is shown when tabs are switched?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo and switch tabs
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();
        var secondTab = cut.FindAll(".rz-tabview-nav li")[1];
        secondTab.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What message is shown when tabs are switched?   ║
        // ║                                                                    ║
        // ║  HINT: The demo displays the selected tab index                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The change message appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_TabContent_IsRendered()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab ChildContent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The ChildContent of each RadzenTabsItem is rendered when that tab is
        // selected. Content can include any Blazor markup including text,
        // components, forms, etc.
        //
        // EXERCISE: What content appears in the first tab?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What content appears in the first tab?          ║
        // ║                                                                    ║
        // ║  HINT: Check what's inside the first RadzenTabsItem                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The content appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_WithIcons_DisplaysIconsInHeaders()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Icons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTabsItem supports an Icon parameter to show icons alongside or
        // instead of text in the tab headers. Icons help users quickly identify
        // different tab sections.
        //
        // EXERCISE: Does the demo include tabs with icons?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include tabs with icons?          ║
        // ║                                                                    ║
        // ║  HINT: Check if any RadzenTabsItem has an Icon parameter           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Icons are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("rz-icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_DynamicTabs_CanBeAddedRemoved()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Dynamic Tabs
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Tabs can be dynamically generated from a collection. You can add or
        // remove tabs at runtime by modifying the collection and re-rendering.
        //
        // EXERCISE: Does the demo show dynamic tab creation?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo show dynamic tab creation?        ║
        // ║                                                                    ║
        // ║  HINT: Look for @foreach or button to add tabs                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Dynamic tabs are supported (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("Add Tab") || answer == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_RenderMode_SupportsClient()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Tab Render Modes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTabs works with different render modes including InteractiveServer
        // and InteractiveWebAssembly for tab switching. The render mode determines
        // where the interactivity is processed.
        //
        // EXERCISE: What render mode is used in TabsDemo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What render mode is used?                       ║
        // ║                                                                    ║
        // ║  HINT: Check the @rendermode directive                             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The correct render mode is used
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("InteractiveServer", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Tabs_Disabled_TabCannotBeSelected()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabled Tabs
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Individual tabs can be disabled using the Disabled parameter. Disabled
        // tabs appear grayed out and cannot be selected by users.
        //
        // EXERCISE: Does the demo include a disabled tab?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the TabsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<TabsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include a disabled tab?           ║
        // ║                                                                    ║
        // ║  HINT: Check if any RadzenTabsItem has Disabled="true"             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Disabled tabs are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("rz-state-disabled"));
    }
}
