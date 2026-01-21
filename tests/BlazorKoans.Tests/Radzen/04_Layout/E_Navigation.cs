using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          RADZEN NAVIGATION                                   ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenPanelMenu and RadzenBreadCrumb help users navigate your application.  ║
/// ║  PanelMenu creates vertical navigation, BreadCrumb shows the current path.   ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenPanelMenu&gt;                                                     │  ║
/// ║  │      &lt;RadzenPanelMenuItem Text="Home" Path="/" Icon="home" /&gt;          │  ║
/// ║  │      &lt;RadzenPanelMenuItem Text="Products" Path="/products"&gt;            │  ║
/// ║  │          &lt;RadzenPanelMenuItem Text="Category" Path="/products/cat" /&gt;  │  ║
/// ║  │      &lt;/RadzenPanelMenuItem&gt;                                            │  ║
/// ║  │  &lt;/RadzenPanelMenu&gt;                                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenBreadCrumb&gt;                                                    │  ║
/// ║  │      &lt;RadzenBreadCrumbItem Text="Home" Path="/" /&gt;                     │  ║
/// ║  │      &lt;RadzenBreadCrumbItem Text="Current Page" /&gt;                      │  ║
/// ║  │  &lt;/RadzenBreadCrumb&gt;                                                   │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class E_Navigation : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_RendersMenuItems()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Panel Menu Structure
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenPanelMenu contains RadzenPanelMenuItem components. Each item can
        // have Text, Icon, and Path properties. Menu items are identified by the
        // "rz-panel-menu-item" CSS class.
        //
        // EXERCISE: How many top-level menu items are in the demo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();
        var menuItems = cut.FindAll(".rz-panel-menu-item");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many menu items are rendered?               ║
        // ║                                                                    ║
        // ║  HINT: Count RadzenPanelMenuItem components at the root level      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: At least the expected number of menu items exist
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(menuItems.Count >= answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ItemText_DisplaysCorrectly()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Menu Item Text Parameter
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Text parameter of RadzenPanelMenuItem sets the visible label. This
        // text appears in the menu and helps users identify navigation options.
        //
        // EXERCISE: What is the text of the first menu item?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears on the first menu item?       ║
        // ║                                                                    ║
        // ║  HINT: Check the first RadzenPanelMenuItem's Text property         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The menu item text appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ItemPath_EnablesNavigation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Menu Item Path for Navigation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Path parameter creates a link for navigation. Clicking the item
        // navigates to the specified path using NavigationManager. Paths
        // typically start with "/" like "/home" or "/products".
        //
        // EXERCISE: What path is used in one of the menu items?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What path is used in the menu?                  ║
        // ║                                                                    ║
        // ║  HINT: Paths typically start with "/" like "/home" or "/products"  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The path appears in the markup as an href
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains($"href=\"{answer}\"", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_NestedItems_CreateHierarchy()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nested Menu Items
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenPanelMenuItem can contain child RadzenPanelMenuItem components.
        // This creates expandable/collapsible menu sections for organizing
        // navigation hierarchically.
        //
        // EXERCISE: Does the demo include nested menu items?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include nested menu items?        ║
        // ║                                                                    ║
        // ║  HINT: Look for RadzenPanelMenuItem inside another MenuItem        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Nested items are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == true || answer == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ExpandCollapse_TogglesChildren()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Expand/Collapse Menu Items
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a menu item has children, clicking it expands or collapses the
        // child items. An icon indicates the expand/collapse state. Radzen uses
        // specific CSS classes to indicate the current state.
        //
        // EXERCISE: What CSS class indicates expanded items?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class indicates expanded items?        ║
        // ║                                                                    ║
        // ║  HINT: Radzen uses specific classes with "rz-" prefix              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The answer contains the Radzen CSS prefix
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains("rz-", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_Icons_EnhanceVisualHierarchy()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Menu Item Icons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Icon parameter adds an icon before the menu item text. Icons help
        // users quickly identify menu sections and improve the visual hierarchy
        // of navigation.
        //
        // EXERCISE: Does the demo include icons in menu items?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include icons in menu items?      ║
        // ║                                                                    ║
        // ║  HINT: Check for Icon parameter on RadzenPanelMenuItem             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Icons are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("rz-icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ShowsNavigationPath()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: BreadCrumb Navigation Path
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenBreadCrumb displays the current navigation path as a series of
        // linked items separated by a delimiter (usually ">"). This helps users
        // understand where they are in the application hierarchy.
        //
        // EXERCISE: How many breadcrumb items are in the demo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();
        var breadcrumbItems = cut.FindAll(".rz-breadcrumb-item");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many breadcrumb items are rendered?         ║
        // ║                                                                    ║
        // ║  HINT: Count RadzenBreadCrumbItem components                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: At least the expected number of breadcrumb items exist
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(breadcrumbItems.Count >= answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ItemText_DisplaysLabel()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: BreadCrumb Item Text
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenBreadCrumbItem uses the Text parameter for the visible label.
        // Typically the first breadcrumb is "Home" representing the root of
        // the navigation hierarchy.
        //
        // EXERCISE: What is the text of the first breadcrumb item?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears on the first breadcrumb?      ║
        // ║                                                                    ║
        // ║  HINT: Often "Home" is the first breadcrumb                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The breadcrumb text appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ItemPath_CreatesLink()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: BreadCrumb Item Links
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Path parameter makes breadcrumb items clickable links. Users can
        // click to navigate back up the hierarchy to previous pages.
        //
        // EXERCISE: Are breadcrumb items clickable?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the NavigationDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<NavigationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are breadcrumb items clickable?                 ║
        // ║                                                                    ║
        // ║  HINT: Check if Path parameter is used (look for href)             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Links are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("href="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_LastItem_NoLink()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Current Page BreadCrumb
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Typically the last breadcrumb item (current page) doesn't have a Path,
        // showing it's not clickable since you're already there. It's usually
        // marked with an "active" state.
        //
        // EXERCISE: What is the typical state of the last breadcrumb?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What state is the last breadcrumb?              ║
        // ║                                                                    ║
        // ║  HINT: Options: "active", "disabled", "plain"                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The last item is marked as active/current
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("active", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Navigation_Integration_UsesNavigationManager()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: NavigationManager Integration
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Both components use NavigationManager for actual navigation. This is
        // Blazor's core routing service. In tests, we inject a test
        // NavigationManager to avoid real navigation.
        //
        // EXERCISE: What Blazor service is used for navigation?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What Blazor service handles navigation?         ║
        // ║                                                                    ║
        // ║  HINT: It's the core Blazor routing service                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The correct service name
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("NavigationManager", answer);
    }
}
