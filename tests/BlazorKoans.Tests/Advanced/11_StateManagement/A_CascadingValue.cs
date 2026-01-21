using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          CASCADING VALUES                                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  CascadingValue provides data to ALL descendant components without           ║
/// ║  passing parameters through every level of the component tree.               ║
/// ║                                                                              ║
/// ║  The Problem it Solves:                                                      ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  WITHOUT cascading - "prop drilling" through every level:              │  ║
/// ║  │  App (Theme="dark") → Layout (Theme) → Page (Theme) → Button (Theme)   │  ║
/// ║  │                                                                        │  ║
/// ║  │  WITH cascading - value flows automatically:                           │  ║
/// ║  │  &lt;CascadingValue Value="@theme"&gt;                                       │  ║
/// ║  │      &lt;Layout&gt;                                                          │  ║
/// ║  │          &lt;Page&gt;                                                        │  ║
/// ║  │              &lt;Button /&gt;  ← Has access to theme!                        │  ║
/// ║  │          &lt;/Page&gt;                                                       │  ║
/// ║  │      &lt;/Layout&gt;                                                         │  ║
/// ║  │  &lt;/CascadingValue&gt;                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Descendants receive it with [CascadingParameter] instead of [Parameter].   ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_CascadingValue : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_passes_data_to_descendants()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The [CascadingParameter] Attribute
        // ═══════════════════════════════════════════════════════════════════════
        //
        // To RECEIVE a cascading value, use [CascadingParameter] on a property.
        // Blazor automatically finds and assigns matching cascading values.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // In a child/descendant component:                                │
        // │  @code {                                                            │
        // │      [CascadingParameter]           ← NOT [Parameter]!              │
        // │      public string Theme { get; set; }                              │
        // │  }                                                                  │
        // │                                                                     │
        // │  // Blazor matches by TYPE - if parent provides string, child gets  │
        // │  // that string in any [CascadingParameter] of type string          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What attribute name receives cascading values?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What attribute receives cascading values?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The attribute name should be "CascadingParameter"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("CascadingParameter", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_provides_value_to_child_components()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Providing Cascading Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Use <CascadingValue> to provide a value to all descendants:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // ThemeProvider.razor                                             │
        // │  <CascadingValue Value="@currentTheme">                             │
        // │      @ChildContent     ← All children can access the theme          │
        // │  </CascadingValue>                                                  │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private string currentTheme = "light";  // Default value       │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: ThemeProvider sets a default theme. What is it?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering provider with consumer as child
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ThemeProvider>(parameters => parameters
            .AddChildContent<ThemeConsumer>());

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the default theme value?                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: ThemeConsumer should display the cascaded theme
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Current theme: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_updates_propagate_to_descendants()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Cascading Values Are Reactive
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a cascading value changes, all descendants automatically re-render
        // with the new value. No manual notification needed!
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Parent changes: currentTheme = "dark"                              │
        // │                    ↓                                                │
        // │  CascadingValue detects change                                      │
        // │                    ↓                                                │
        // │  All descendants with [CascadingParameter] re-render                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: After changing theme to "dark", what does ThemeConsumer show?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering with initial "light" theme
        // ──────────────────────────────────────────────────────────────────────
        var themeProvider = Render<ThemeProvider>(parameters => parameters
            .AddChildContent<ThemeConsumer>());

        Assert.Contains("Current theme: light", themeProvider.Markup);

        // ACT: Change the theme
        themeProvider.Instance.SetTheme("dark");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What theme is displayed after the change?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: ThemeConsumer should show the updated theme
        // ──────────────────────────────────────────────────────────────────────
        themeProvider.WaitForAssertion(() =>
            Assert.Contains($"Current theme: {answer}", themeProvider.Markup));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_works_across_multiple_levels()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Cascading Through Multiple Levels
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The real power: values cascade through ANY number of component levels.
        // Intermediate components don't need to know about or pass the value.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <CascadingValue Value="@theme">                                    │
        // │      <Layout>                  ← Doesn't need Theme parameter       │
        // │          <Sidebar>             ← Doesn't need Theme parameter       │
        // │              <ThemeConsumer /> ← Gets theme via [CascadingParameter]│
        // │          </Sidebar>                                                 │
        // │      </Layout>                                                      │
        // │  </CascadingValue>                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Even when nested, ThemeConsumer gets the cascading value.
        //           What theme does it display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - nesting ThemeConsumer inside ThemeProvider
        // ──────────────────────────────────────────────────────────────────────
        var wrapper = Render<ThemeProvider>(parameters => parameters
            .AddChildContent(builder =>
            {
                builder.OpenComponent<ThemeConsumer>(0);
                builder.CloseComponent();
            }));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What theme does the nested consumer display?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The cascaded value should reach the nested component
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Current theme: {answer}", wrapper.Markup);
    }
}
