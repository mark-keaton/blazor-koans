using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._09_TemplatedComponents;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                              RENDER FRAGMENT                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RenderFragment is Blazor's way of passing UI content as a parameter.        ║
/// ║  It enables component composition - building complex UIs from smaller        ║
/// ║  pieces. Think of RenderFragment as a "slot" where content can be inserted.  ║
/// ║                                                                              ║
/// ║  There are two types:                                                        ║
/// ║  • RenderFragment: Non-generic, renders whatever markup you give it          ║
/// ║  • RenderFragment&lt;T&gt;: Generic, provides a context object of type T            ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Parent provides the content:                                       │  ║
/// ║  │  &lt;SimpleCard&gt;                                                          │  ║
/// ║  │      &lt;Header&gt;My Title&lt;/Header&gt;                                         │  ║
/// ║  │      &lt;p&gt;This is the body content&lt;/p&gt;                                   │  ║
/// ║  │  &lt;/SimpleCard&gt;                                                         │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Child decides where to render it:                                  │  ║
/// ║  │  [Parameter] public RenderFragment? Header { get; set; }               │  ║
/// ║  │  [Parameter] public RenderFragment? ChildContent { get; set; }         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_RenderFragment : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ChildContent_IsSpecialRenderFragment()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The Special ChildContent Parameter
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you put content inside a component's tags, it becomes the
        // ChildContent parameter. This is a convention - if a component has a
        // RenderFragment parameter named "ChildContent", Blazor automatically
        // assigns content between tags to it.
        //
        // EXERCISE: What is the parameter name for content placed between
        // component tags?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the special conventional name?          ║
        // ║                                                                    ║
        // ║  HINT: It's a name that Blazor automatically recognizes            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The conventional parameter name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("ChildContent", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ChildContent_RendersInsideComponent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Where ChildContent Gets Rendered
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Content passed as ChildContent is rendered wherever the component
        // places @ChildContent in its markup. SimpleCard renders ChildContent
        // inside a div with a specific CSS class.
        //
        // EXERCISE: What class wraps the ChildContent in SimpleCard?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the TemplatedComponentDemo
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class wraps the body content?          ║
        // ║                                                                    ║
        // ║  HINT: Look at where @ChildContent is rendered in SimpleCard.razor ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The ChildContent wrapper class exists
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(cut.Find($".{answer}"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void NamedRenderFragments_ProvideMultipleSlots()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multiple Named Slots
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Components can have multiple RenderFragment parameters with different
        // names. SimpleCard has Header, ChildContent, and Footer. Each becomes
        // a "slot" where content can be inserted.
        //
        // EXERCISE: How many RenderFragment parameters does SimpleCard have?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Count the RenderFragment parameters             ║
        // ║                                                                    ║
        // ║  HINT: Count Header, ChildContent, and Footer                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The number of RenderFragment slots
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(3, answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Header_RendersInHeaderSection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Named RenderFragments as Child Elements
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Named RenderFragments are specified by using the parameter name as a
        // child element: <Header>...</Header>. The component then renders this
        // content in the appropriate location.
        //
        // EXERCISE: What class wraps the Header content in SimpleCard?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the TemplatedComponentDemo
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class wraps the header section?        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The header contains the expected text
        // ──────────────────────────────────────────────────────────────────────
        var header = cut.Find($".{answer}");
        Assert.Contains("Card Header", header.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Footer_RendersInFooterSection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Footer RenderFragment
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Just like Header, Footer is rendered in its designated location within
        // the component's template.
        //
        // EXERCISE: What class wraps the Footer content in SimpleCard?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the TemplatedComponentDemo
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class wraps the footer section?        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The footer contains the expected text
        // ──────────────────────────────────────────────────────────────────────
        var footer = cut.Find($".{answer}");
        Assert.Contains("Card Footer", footer.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RenderFragment_CanBeNull()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nullable RenderFragments
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RenderFragment parameters are typically nullable. Components should
        // check if they're null before rendering. SimpleCard only renders
        // Header/Footer divs if those fragments exist.
        //
        // EXERCISE: What C# operator checks if a RenderFragment is not null?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What operator is used for null comparison?      ║
        // ║                                                                    ║
        // ║  HINT: Look at the @if conditions in SimpleCard.razor              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The null check operator
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("!=", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RenderFragment_TypeInCSharp()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Declaring RenderFragment in C#
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In C# code, you declare a RenderFragment parameter like:
        // [Parameter] public RenderFragment? Header { get; set; }
        // The type name is "RenderFragment" from Microsoft.AspNetCore.Components.
        //
        // EXERCISE: What is the full type name for a non-generic render fragment?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the type name?                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The RenderFragment type name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("RenderFragment", answer);
    }
}
