using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner.Components;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          BLAZOR COMPONENTS 101                               ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Components are the fundamental building blocks of Blazor applications.      ║
/// ║  Every piece of UI in Blazor is a component - from a simple button to an     ║
/// ║  entire page.                                                                ║
/// ║                                                                              ║
/// ║  Key Concepts You'll Learn:                                                  ║
/// ║  1. Components are .razor files that combine HTML markup with C# code        ║
/// ║  2. Components can accept data via [Parameter] attributes                    ║
/// ║  3. Components can accept child content via RenderFragment                   ║
/// ║  4. Components can be generic using @typeparam                               ║
/// ║                                                                              ║
/// ║  A component file has two sections:                                          ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;h1&gt;Hello, @Name!&lt;/h1&gt;           ← Razor markup (HTML + C#)           │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                            ← C# code block                    │  ║
/// ║  │      [Parameter]                                                       │  ║
/// ║  │      public string Name { get; set; }                                  │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class ComponentKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_CreatingComponents()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Your First Component
        // ═══════════════════════════════════════════════════════════════════════
        // 
        // The simplest Blazor component is just a .razor file containing HTML.
        // No C# code required! The component renders whatever markup it contains.
        //
        // Example - A component named "SimpleMessage.razor":
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <p>This is a simple message!</p>                                   │
        // └─────────────────────────────────────────────────────────────────────┘
        // 
        // When rendered, it outputs: <p>This is a simple message!</p>
        //
        // EXERCISE: Open the HelloWorld.razor component in:
        //           src/BlazorKoans.App/Components/Exercises/Beginner/
        //           Find what text it displays inside the <h1> tag.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the HelloWorld component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<HelloWorld>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches($"<h1>{answer}</h1>");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_ComponentParameters()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Component Parameters
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Parameters let you pass data INTO a component, making it reusable.
        // Think of them like function arguments, but for UI components.
        //
        // To define a parameter in a component, use the [Parameter] attribute:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <p>Hello, @Name!</p>                                               │
        // │                                                                     │
        // │  @code {                                                            │
        // │      [Parameter]                        // ← This attribute marks   │
        // │      public string Name { get; set; }   //   the property as a     │
        // │  }                                      //   parameter              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // To USE a component with parameters, pass values like HTML attributes:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <Greeting Name="Alice" />              // Renders: Hello, Alice!   │
        // │  <Greeting Name="@userName" />          // Pass a variable          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // In bUnit tests, we use a fluent API to set parameters:
        //   Render<Greeting>(p => p.Add(c => c.Name, "Alice"))
        //
        // EXERCISE: We're passing "World" as the Name parameter below.
        //           What text do you expect to appear in the output?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering Greeting with Name="World"
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<Greeting>(parameters => parameters
            .Add(p => p.Name, "World"));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches($"<p>Hello, {answer}!</p>");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_ChildContent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RenderFragment and ChildContent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // What is RenderFragment?
        // -----------------------
        // RenderFragment is a DELEGATE type that represents a chunk of UI content.
        // Under the hood, it's: delegate void RenderFragment(RenderTreeBuilder builder)
        // 
        // But you don't need to understand the internals! Just think of it as:
        // "A piece of UI that can be passed around and rendered somewhere else"
        //
        // The ChildContent Convention:
        // ----------------------------
        // When you name a RenderFragment parameter "ChildContent", Blazor gives
        // you special syntax - you can put content BETWEEN the component tags:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // Card.razor                                                      │
        // │  <div class="card">                                                 │
        // │      @ChildContent          ← Renders whatever is passed in        │
        // │  </div>                                                             │
        // │                                                                     │
        // │  @code {                                                            │
        // │      [Parameter]                                                    │
        // │      public RenderFragment? ChildContent { get; set; }              │
        // │  }                           ↑                                      │
        // │                              Must be named "ChildContent" exactly   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Usage - content between tags becomes ChildContent automatically:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <Card>                                                             │
        // │      <p>This content becomes ChildContent!</p>                      │
        // │  </Card>                                                            │
        // │                                                                     │
        // │  // Output:                                                         │
        // │  <div class="card">                                                 │
        // │      <p>This content becomes ChildContent!</p>                      │
        // │  </div>                                                             │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: Look at Card.razor. What HTML element wraps the ChildContent?
        //           Write the COMPLETE expected output below.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering Card with child content
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<Card>(parameters => parameters
            .AddChildContent("<p>This is card content</p>"));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the complete HTML output  ║
        // ║                                                                    ║
        // ║  HINT: Your answer should include the wrapper element AND the      ║
        // ║        child content. Example format: <tag>child content</tag>     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "<div class\"=card\">This is card content</div>";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches(answer);
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_RenderFragments()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RenderFragment<T> - Templated Components
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RenderFragment vs RenderFragment<T>:
        // ------------------------------------
        // • RenderFragment      = UI content with NO context (like ChildContent)
        // • RenderFragment<T>   = UI content that RECEIVES data of type T
        //
        // Think of RenderFragment<T> as a "template" - you define HOW to render
        // each item, and the component applies your template to its data.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // ItemList.razor - A generic list component                       │
        // │  @typeparam TItem                    ← Makes component generic      │
        // │                                                                     │
        // │  <ul>                                                               │
        // │      @foreach (var item in Items)                                   │
        // │      {                                                              │
        // │          @ItemTemplate(item)         ← Invokes YOUR template        │
        // │      }                                  with each item              │
        // │  </ul>                                                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      [Parameter]                                                    │
        // │      public IEnumerable<TItem> Items { get; set; }                  │
        // │                                                                     │
        // │      [Parameter]                                                    │
        // │      public RenderFragment<TItem> ItemTemplate { get; set; }        │
        // │  }                           ↑                                      │
        // │                              Receives TItem, returns UI             │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // Usage - the "context" variable gives you access to each item:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <ItemList Items="@fruits">                                         │
        // │      <ItemTemplate>                                                 │
        // │          <li>@context</li>      ← "context" is each fruit string    │
        // │      </ItemTemplate>                                                │
        // │  </ItemList>                                                        │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // In bUnit tests, we pass a lambda that takes the item and returns markup:
        //   .Add(p => p.ItemTemplate, item => $"<li>{item}</li>")
        //
        // EXERCISE: Look at ItemList.razor. What HTML tag wraps ALL the items?
        //           (The container tag, not the tag in ItemTemplate)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering ItemList with 3 fruit items
        // ──────────────────────────────────────────────────────────────────────
        var items = new[] { "Apple", "Banana", "Orange" };

        var cut = Render<ItemList<string>>(parameters => parameters
            .Add(p => p.Items, items)
            .Add(p => p.ItemTemplate, item => $"<li>{item}</li>"));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the container tag name    ║
        // ║                                                                    ║
        // ║  HINT: Look at ItemList.razor - what tag wraps the @foreach?       ║
        // ║        Just the tag name (e.g., "div", "span", "ul")               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        cut.MarkupMatches($@"<{answer}>
            <li>Apple</li>
            <li>Banana</li>
            <li>Orange</li>
        </{answer}>");
    }
}
