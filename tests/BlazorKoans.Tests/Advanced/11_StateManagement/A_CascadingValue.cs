using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

public class A_CascadingValue : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_passes_data_to_descendants()
    {
        // ABOUT: CascadingValue makes a value available to all descendant components
        // without having to pass it through parameters at each level.

        // TODO: What parameter attribute receives a CascadingValue?
        // Replace "__" with the attribute name

        var expected = "__";

        Assert.Equal("CascadingParameter", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_provides_value_to_child_components()
    {
        // ABOUT: Child components receive cascading values through properties
        // marked with [CascadingParameter].

        // TODO: ThemeProvider provides a cascading value to ThemeConsumer.
        // What is the default theme value?

        var cut = Render<ThemeProvider>(parameters => parameters
            .AddChildContent<ThemeConsumer>());

        var expected = "__";

        Assert.Contains($"Current theme: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_updates_propagate_to_descendants()
    {
        // ABOUT: When a cascading value changes, all components using it re-render.

        // TODO: Change the theme from "light" to "dark".
        // Does ThemeConsumer update automatically?

        var themeProvider = Render<ThemeProvider>(parameters => parameters
            .AddChildContent<ThemeConsumer>());

        Assert.Contains("Current theme: light", themeProvider.Markup);

        themeProvider.Instance.SetTheme("dark");

        var expected = "__";

        themeProvider.WaitForAssertion(() =>
            Assert.Contains($"Current theme: {expected}", themeProvider.Markup));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void CascadingValue_works_across_multiple_levels()
    {
        // ABOUT: CascadingValue can pass through multiple component layers
        // without each intermediate component needing parameters.

        // TODO: Nest ThemeConsumer inside another component inside ThemeProvider.
        // Does the value still cascade down?

        var wrapper = Render<ThemeProvider>(parameters => parameters
            .AddChildContent(builder =>
            {
                builder.OpenComponent<ThemeConsumer>(0);
                builder.CloseComponent();
            }));

        var expected = "__";

        Assert.Contains($"Current theme: {expected}", wrapper.Markup);
    }
}
