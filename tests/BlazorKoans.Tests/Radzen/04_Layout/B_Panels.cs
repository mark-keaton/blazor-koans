using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          RADZEN PANELS & FIELDSETS                           ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenPanel and RadzenFieldset are container components for grouping        ║
/// ║  content. Panel supports collapsible sections, Fieldset groups form fields.  ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenPanel AllowCollapse="true"&gt;                                    │  ║
/// ║  │      &lt;HeaderTemplate&gt;Panel Title&lt;/HeaderTemplate&gt;                      │  ║
/// ║  │      &lt;ChildContent&gt;Panel content here&lt;/ChildContent&gt;                   │  ║
/// ║  │  &lt;/RadzenPanel&gt;                                                        │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenFieldset Text="Form Section"&gt;                                  │  ║
/// ║  │      &lt;RadzenTextBox /&gt;                                                 │  ║
/// ║  │  &lt;/RadzenFieldset&gt;                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_Panels : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_RendersWithHeader()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Panel Headers with HeaderTemplate
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenPanel uses a HeaderTemplate to define what appears in the panel's
        // header section. This typically includes a title or summary that helps
        // users understand what the panel contains.
        //
        // EXERCISE: What text is shown in the panel header?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the panel header?          ║
        // ║                                                                    ║
        // ║  HINT: Check the HeaderTemplate content in PanelsDemo              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The header text appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_SupportsCollapse()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Collapsible Panels
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When AllowCollapse is true, RadzenPanel displays a toggle button in
        // the header. Users can click to expand or collapse the panel content.
        // The Collapsed parameter sets the initial state.
        //
        // EXERCISE: What is the default collapsed state of the collapsible panel?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the panel collapsed by default?              ║
        // ║                                                                    ║
        // ║  HINT: Check the Collapsed parameter value in PanelsDemo           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Panel collapse state matches expected
        // ───────────────────────────────────────────────────────────────────────
        if (answer)
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
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Panel Collapse Toggle Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Clicking the collapse toggle changes the panel's state. The content
        // becomes visible or hidden based on the collapsed state. When collapsed,
        // content is hidden but not removed from the DOM.
        //
        // EXERCISE: What happens to content when a panel is collapsed?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo and click the toggle
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();
        var toggleButton = cut.Find(".rz-panel-header");
        toggleButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What happens to content when collapsed?         ║
        // ║                                                                    ║
        // ║  HINT: Options: "visible", "hidden", "removed"                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Content is hidden when collapsed (not removed from DOM)
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("hidden", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_ContentArea_RendersChildContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Panel ChildContent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The ChildContent parameter defines what appears in the panel body.
        // This can include text, forms, lists, or any other Blazor content.
        //
        // EXERCISE: What text appears in the panel content area?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the panel body?            ║
        // ║                                                                    ║
        // ║  HINT: Look at the ChildContent in PanelsDemo                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The content appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_RendersWithText()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Fieldset Legend Text
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenFieldset uses the Text parameter to set the legend (label) that
        // appears at the top border of the fieldset. This provides a visual
        // label for the grouped form fields.
        //
        // EXERCISE: What text is shown in the fieldset legend?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the fieldset legend?       ║
        // ║                                                                    ║
        // ║  HINT: Check the Text parameter in PanelsDemo                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The legend text appears in the rendered markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_GroupsFormFields()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Fieldset HTML Element
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenFieldset is ideal for grouping related form fields. It renders
        // as a standard HTML element with a <legend> for accessibility, making
        // forms more accessible to screen readers.
        //
        // EXERCISE: What HTML element does RadzenFieldset render as?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What HTML element does RadzenFieldset render?   ║
        // ║                                                                    ║
        // ║  HINT: It's a standard HTML form grouping element                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: RadzenFieldset renders as a fieldset element
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("fieldset", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Fieldset_ContainsFormInputs()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Form Inputs in Fieldsets
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Inside RadzenFieldset, you typically place form components like
        // RadzenTextBox, RadzenNumeric, etc. These inputs are grouped visually
        // and semantically by the fieldset.
        //
        // EXERCISE: How many input fields are in the fieldset?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo and find the fieldset
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();
        var fieldset = cut.Find("fieldset");
        var inputs = fieldset.QuerySelectorAll("input");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many input fields are in the fieldset?      ║
        // ║                                                                    ║
        // ║  HINT: Count input elements inside the fieldset                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The expected number of inputs are present
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, inputs.Length);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_WithMultiplePanels_RendersIndependently()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Independent Panels
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Multiple RadzenPanel components can coexist on a page. Each maintains
        // its own collapsed state independently, allowing users to expand/collapse
        // different sections as needed.
        //
        // EXERCISE: How many panels are in the demo?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();
        var panels = cut.FindAll(".rz-panel");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many panels are rendered?                   ║
        // ║                                                                    ║
        // ║  HINT: Count elements with "rz-panel" class                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The expected number of panels are rendered
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, panels.Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_Styling_AcceptsCustomCSS()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Panel Styling
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Both RadzenPanel and RadzenFieldset accept Style parameters for custom
        // CSS, letting you control appearance like colors, borders, and spacing.
        //
        // EXERCISE: Does the demo include custom styling?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo include custom styling?           ║
        // ║                                                                    ║
        // ║  HINT: Check if any panel or fieldset has a Style parameter        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Custom styles are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("style="));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Panel_CollapsedByDefault_StartsCollapsed()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Panels Collapsed by Default
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Setting Collapsed="true" makes the panel start in a collapsed state.
        // This is useful for keeping the UI compact until users need details.
        // The demo displays whether the panel is currently collapsed.
        //
        // EXERCISE: What status message is shown for the collapsed panel?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PanelsDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<PanelsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What status message is shown?                   ║
        // ║                                                                    ║
        // ║  HINT: The demo displays the panel's collapsed state               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The status message appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }
}
