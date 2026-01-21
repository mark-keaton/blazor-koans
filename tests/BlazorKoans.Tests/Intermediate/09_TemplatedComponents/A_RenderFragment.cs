using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._09_TemplatedComponents;

/// <summary>
/// RenderFragment is Blazor's way of passing UI content as a parameter.
/// It enables component composition - building complex UIs from smaller pieces.
///
/// Think of RenderFragment as a "slot" where content can be inserted.
/// The parent component provides the content, and the child component
/// decides where and how to render it.
///
/// There are two types:
/// - RenderFragment: Non-generic, just renders whatever markup you give it
/// - RenderFragment&lt;T&gt;: Generic, provides a context object of type T
/// </summary>
public class A_RenderFragment : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ChildContent_IsSpecialRenderFragment()
    {
        // ABOUT: When you put content inside a component's tags, it becomes
        // the ChildContent parameter. This is a convention - if a component
        // has a RenderFragment parameter named "ChildContent", Blazor
        // automatically assigns content between tags to it.

        // TODO: What is the parameter name for content placed between component tags?
        // HINT: It's a special conventional name that Blazor recognizes

        var expected = "ChildContent";

        Assert.Equal("ChildContent", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ChildContent_RendersInsideComponent()
    {
        // ABOUT: Content passed as ChildContent is rendered wherever the
        // component places @ChildContent in its markup. SimpleCard renders
        // ChildContent inside a div with class "simple-card-body".

        // TODO: What class wraps the ChildContent in SimpleCard?
        // HINT: Look at where @ChildContent is rendered in SimpleCard.razor

        var cut = Render<TemplatedComponentDemo>();

        var expected = "simple-card-body";

        Assert.NotNull(cut.Find($".{expected}"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NamedRenderFragments_ProvideMultipleSlots()
    {
        // ABOUT: Components can have multiple RenderFragment parameters
        // with different names. SimpleCard has Header, ChildContent, and Footer.
        // Each becomes a "slot" where content can be inserted.

        // TODO: How many RenderFragment parameters does SimpleCard have?
        // HINT: Count Header, ChildContent, and Footer

        var expected = 3;

        Assert.Equal(3, expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Header_RendersInHeaderSection()
    {
        // ABOUT: Named RenderFragments are specified by using the parameter
        // name as a child element: <Header>...</Header>. The component
        // then renders this content in the appropriate location.

        // TODO: What class wraps the Header content in SimpleCard?

        var cut = Render<TemplatedComponentDemo>();

        var expected = "simple-card-header";

        var header = cut.Find($".{expected}");
        Assert.Contains("Card Header", header.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Footer_RendersInFooterSection()
    {
        // ABOUT: Just like Header, Footer is rendered in its designated
        // location within the component's template.

        // TODO: What class wraps the Footer content in SimpleCard?

        var cut = Render<TemplatedComponentDemo>();

        var expected = "simple-card-footer";

        var footer = cut.Find($".{expected}");
        Assert.Contains("Card Footer", footer.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RenderFragment_CanBeNull()
    {
        // ABOUT: RenderFragment parameters are typically nullable.
        // Components should check if they're null before rendering.
        // SimpleCard only renders Header/Footer divs if those fragments exist.

        // TODO: What C# operator checks if a RenderFragment is not null?
        // HINT: Look at the @if conditions in SimpleCard.razor

        var expected = "!="; // "!=" or "!!"

        Assert.Equal("!=", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RenderFragment_TypeInCSharp()
    {
        // ABOUT: In C# code, you declare a RenderFragment parameter like:
        // [Parameter] public RenderFragment? Header { get; set; }
        // The type name is "RenderFragment" from Microsoft.AspNetCore.Components.

        // TODO: What is the full type name for a non-generic render fragment?

        var expected = "RenderFragment";

        Assert.Equal("RenderFragment", expected);
    }
}
