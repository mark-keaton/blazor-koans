using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// RadzenPanelMenu and RadzenBreadCrumb are navigation components that help users
/// understand where they are in your application and navigate between pages.
///
/// RadzenPanelMenu creates a vertical navigation menu with support for nested items.
/// RadzenBreadCrumb shows the navigation path (Home > Products > Details).
///
/// These components integrate with Blazor's NavigationManager for routing.
/// </summary>
public class E_Navigation : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_RendersMenuItems()
    {
        // ABOUT: RadzenPanelMenu contains RadzenPanelMenuItem components.
        // Each item can have Text, Icon, and Path properties.

        // TODO: Replace 0 with the number of top-level menu items
        // HINT: Count RadzenPanelMenuItem components at the root level

        var cut = Render<NavigationDemo>();

        var menuItems = cut.FindAll(".rz-panel-menu-item");
        var expected = 5;

        Assert.True(menuItems.Count >= expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ItemText_DisplaysCorrectly()
    {
        // ABOUT: The Text parameter of RadzenPanelMenuItem sets the visible label.

        // TODO: Replace "__" with the text of the first menu item
        // HINT: Check the first RadzenPanelMenuItem's Text property

        var cut = Render<NavigationDemo>();

        var expected = "Home";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ItemPath_EnablesNavigation()
    {
        // ABOUT: The Path parameter creates a link for navigation.
        // Clicking the item navigates to the specified path using NavigationManager.

        // TODO: Replace "__" with a path used in the menu
        // HINT: Paths typically start with "/" like "/home" or "/products"

        var cut = Render<NavigationDemo>();

        var expected = "/";

        Assert.Contains($"href=\"{expected}\"", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_NestedItems_CreateHierarchy()
    {
        // ABOUT: RadzenPanelMenuItem can contain child RadzenPanelMenuItem components.
        // This creates expandable/collapsible menu sections.

        // TODO: Does the demo include nested menu items? Replace false with expected
        // HINT: Look for RadzenPanelMenuItem inside another RadzenPanelMenuItem

        var cut = Render<NavigationDemo>();

        var hasNestedItems = true;

        Assert.True(hasNestedItems == true || hasNestedItems == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_ExpandCollapse_TogglesChildren()
    {
        // ABOUT: When a menu item has children, clicking it expands or collapses
        // the child items. An icon indicates the expand/collapse state.

        // TODO: Replace "__" with the CSS class for expanded items
        // HINT: Radzen uses specific classes to indicate state

        var expected = "rz-panel-menu-item-expanded";

        // Expanded items have a specific class
        Assert.Contains("rz-", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void PanelMenu_Icons_EnhanceVisualHierarchy()
    {
        // ABOUT: The Icon parameter adds an icon before the menu item text.
        // Icons help users quickly identify menu sections.

        // TODO: Does the demo include icons in menu items? Replace false with expected
        // HINT: Check for Icon parameter on RadzenPanelMenuItem

        var cut = Render<NavigationDemo>();

        var hasIcons = true;

        Assert.True(hasIcons == cut.Markup.Contains("rz-icon"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ShowsNavigationPath()
    {
        // ABOUT: RadzenBreadCrumb displays the current navigation path as
        // a series of linked items separated by a delimiter (usually ">").

        // TODO: Replace 0 with the number of breadcrumb items
        // HINT: Count RadzenBreadCrumbItem components

        var cut = Render<NavigationDemo>();

        var breadcrumbItems = cut.FindAll(".rz-breadcrumb-item");
        var expected = 3;

        Assert.True(breadcrumbItems.Count >= expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ItemText_DisplaysLabel()
    {
        // ABOUT: RadzenBreadCrumbItem uses Text parameter for the visible label.

        // TODO: Replace "__" with the text of the first breadcrumb item
        // HINT: Often "Home" is the first breadcrumb

        var cut = Render<NavigationDemo>();

        var expected = "Home";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_ItemPath_CreatesLink()
    {
        // ABOUT: The Path parameter makes breadcrumb items clickable links.
        // Users can click to navigate back up the hierarchy.

        // TODO: Replace false with true if breadcrumb items are clickable
        // HINT: Check if Path parameter is used

        var cut = Render<NavigationDemo>();

        var hasClickableItems = true;

        Assert.True(hasClickableItems == cut.Markup.Contains("href="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void BreadCrumb_LastItem_NoLink()
    {
        // ABOUT: Typically the last breadcrumb item (current page) doesn't have
        // a Path, showing it's not clickable since you're already there.

        // TODO: Replace "__" with the typical state of the last breadcrumb
        // Options: "active", "disabled", "plain"

        var expected = "active";

        // Last item is usually marked as active/current
        Assert.Equal("active", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Navigation_Integration_UsesNavigationManager()
    {
        // ABOUT: Both components use NavigationManager for actual navigation.
        // In tests, we inject a test NavigationManager to avoid real navigation.

        // TODO: Replace "__" with the Blazor service used for navigation
        // HINT: It's the core Blazor routing service

        var expected = "NavigationManager";

        Assert.Equal("NavigationManager", expected);
    }
}
