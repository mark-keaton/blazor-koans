using Bunit;
using BlazorKoans.App.Components.Exercises.Radzen;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// RadzenPanel and RadzenFieldset are container components for grouping content.
/// RadzenPanel supports collapsible sections with headers, while RadzenFieldset
/// groups form fields with a legend (label).
///
/// These components help organize complex UIs into manageable sections that users
/// can expand/collapse to focus on what they need.
/// </summary>
public class B_Panels : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_RendersWithHeader()
    {
        // ABOUT: RadzenPanel uses a HeaderTemplate to define what appears in the
        // panel's header section. This typically includes a title or summary.

        // TODO: Replace "__" with the text shown in the panel header
        // HINT: Check the HeaderTemplate content in PanelsDemo

        var cut = Render<PanelsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_SupportsCollapse()
    {
        // ABOUT: When AllowCollapse is true, RadzenPanel displays a toggle button
        // in the header. Users can click to expand or collapse the panel content.

        // TODO: Replace false with the default collapsed state of the collapsible panel
        // HINT: Check the Collapsed parameter value in PanelsDemo

        var cut = Render<PanelsDemo>();

        var expectedCollapsedState = false;

        // Panel should indicate its collapse state in the markup
        if (expectedCollapsedState)
        {
            Assert.Contains("rz-panel-collapsed", cut.Markup);
        }
        else
        {
            Assert.DoesNotContain("rz-panel-collapsed", cut.Markup);
        }
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_ToggleCollapse_ChangesState()
    {
        // ABOUT: Clicking the collapse toggle changes the panel's state.
        // The content becomes visible or hidden based on the collapsed state.

        // TODO: Replace "__" with what happens to content when panel is collapsed
        // Options: "visible", "hidden", "removed"

        var cut = Render<PanelsDemo>();

        // Find the collapse toggle button
        var toggleButton = cut.Find(".rz-panel-header");
        toggleButton.Click();

        var expected = "__";

        // When collapsed, content should be hidden (not removed from DOM)
        Assert.Equal("hidden", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_ContentArea_RendersChildContent()
    {
        // ABOUT: The ChildContent parameter defines what appears in the panel body.
        // This can include text, forms, lists, or any other Blazor content.

        // TODO: Replace "__" with text that appears in the panel content area
        // HINT: Look at the ChildContent in PanelsDemo

        var cut = Render<PanelsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_RendersWithText()
    {
        // ABOUT: RadzenFieldset uses the Text parameter to set the legend (label)
        // that appears at the top border of the fieldset.

        // TODO: Replace "__" with the text shown in the fieldset legend
        // HINT: Check the Text parameter in PanelsDemo

        var cut = Render<PanelsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_GroupsFormFields()
    {
        // ABOUT: RadzenFieldset is ideal for grouping related form fields.
        // It renders as a <fieldset> element with a <legend> for accessibility.

        // TODO: Replace "__" with the HTML element RadzenFieldset renders
        // HINT: It's a standard HTML form grouping element

        var expected = "__";

        Assert.Equal("fieldset", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_ContainsFormInputs()
    {
        // ABOUT: Inside RadzenFieldset, you typically place form components
        // like RadzenTextBox, RadzenNumeric, etc.

        // TODO: Replace 0 with the number of input fields in the fieldset
        // HINT: Count input elements inside the fieldset

        var cut = Render<PanelsDemo>();

        var fieldset = cut.Find("fieldset");
        var inputs = fieldset.QuerySelectorAll("input");
        var expected = 0;

        Assert.Equal(expected, inputs.Length);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_WithMultiplePanels_RendersIndependently()
    {
        // ABOUT: Multiple RadzenPanel components can coexist on a page.
        // Each maintains its own collapsed state independently.

        // TODO: Replace 0 with the number of panels in the demo
        // HINT: Count elements with "rz-panel" class

        var cut = Render<PanelsDemo>();

        var panels = cut.FindAll(".rz-panel");
        var expected = 0;

        Assert.Equal(expected, panels.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_Styling_AcceptsCustomCSS()
    {
        // ABOUT: Both RadzenPanel and RadzenFieldset accept Style parameters
        // for custom CSS, letting you control appearance.

        // TODO: Does the demo include custom styling? Replace false with expected
        // HINT: Check if any panel or fieldset has a Style parameter

        var cut = Render<PanelsDemo>();

        var hasCustomStyle = false;

        Assert.True(hasCustomStyle == cut.Markup.Contains("style="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_CollapsedByDefault_StartsCollapsed()
    {
        // ABOUT: Setting Collapsed="true" makes the panel start in a collapsed state.
        // This is useful for keeping the UI compact until users need details.

        // TODO: Replace "__" with the status message shown for the collapsed panel
        // HINT: The demo displays whether the panel is currently collapsed

        var cut = Render<PanelsDemo>();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }
}
