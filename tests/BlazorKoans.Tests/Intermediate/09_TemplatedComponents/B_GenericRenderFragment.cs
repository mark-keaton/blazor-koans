using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._09_TemplatedComponents;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                     GENERIC RENDERFRAGMENT&lt;T&gt; - TEMPLATES                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RenderFragment&lt;T&gt; is the generic version that provides a "context" object. ║
/// ║  This enables templated components - components that let the parent define   ║
/// ║  how each item should render while the child handles the iteration.          ║
/// ║                                                                              ║
/// ║  Key Concepts You'll Learn:                                                  ║
/// ║  1. RenderFragment&lt;T&gt; provides a context object of type T                   ║
/// ║  2. The default context variable is named "context"                          ║
/// ║  3. Context="name" renames the variable for cleaner code                     ║
/// ║  4. @typeparam makes components generic                                      ║
/// ║                                                                              ║
/// ║  The Classic Pattern - Templated List Component:                             ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // ItemList.razor                                                     │  ║
/// ║  │  @typeparam TItem                                                      │  ║
/// ║  │  @foreach (var item in Items)                                          │  ║
/// ║  │  {                                                                     │  ║
/// ║  │      @ItemTemplate(item)          ← Calls template with each item      │  ║
/// ║  │  }                                                                     │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      [Parameter] public RenderFragment&lt;TItem&gt; ItemTemplate { get; set; }│  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_GenericRenderFragment : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void GenericRenderFragment_ProvidesContextObject()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RenderFragment<T> Parameter Declaration
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RenderFragment<T> is declared as a parameter that provides an object
        // of type T to the template. The component calls the template with each
        // item using the syntax: @ItemTemplate(item)
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [Parameter]                                                        │
        // │  public RenderFragment<TItem>? ItemTemplate { get; set; }           │
        // │                                 ↑                                   │
        // │                                 The parameter name                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: In ItemList.razor, what is the parameter name for the
        //           generic template? Look at the [Parameter] declarations.
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the parameter name        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The parameter name should match what's in ItemList.razor
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("ItemTemplate", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_DefaultNameIsContext()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The Default Context Variable
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you don't specify a Context attribute, the default name for the
        // context object is simply "context". You access properties like:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <ItemTemplate>                                                     │
        // │      <li>@context.Name - $@context.Price</li>                       │
        // │  </ItemTemplate>      ↑                                             │
        // │                       Default variable name                         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What is the default name for the context variable when no
        //           Context attribute is specified?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the demo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();
        var defaultContextSpan = cut.Find(".default-context");
        Assert.NotNull(defaultContextSpan);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the default variable name ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The default context name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("context", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_CanBeRenamed()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Renaming the Context Variable
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Context attribute on a template lets you rename the context
        // variable. This makes templates more readable and self-documenting:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <ItemTemplate Context="product">                                   │
        // │      <li>@product.Name - $@product.Price</li>                       │
        // │  </ItemTemplate>         ↑                                          │
        // │                          Now "product" instead of "context"         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: In the "Generic RenderFragment with Context" section of
        //           TemplatedComponentDemo.razor, what name is used for context?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the context name          ║
        // ║                                                                    ║
        // ║  HINT: Look for Context="..." in TemplatedComponentDemo.razor      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The renamed context variable
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("product", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_TypeComesFromTItem()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Generic Type Parameters
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The type of the context object is determined by the TItem generic
        // parameter. If you have ItemList<Product>, then the context in
        // ItemTemplate is a Product. Blazor infers this from the component usage.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @typeparam TItem              ← Declares the generic parameter     │
        // │                                                                     │
        // │  [Parameter]                                                        │
        // │  public RenderFragment<TItem>? ItemTemplate { get; set; }           │
        // │                        ↑                                            │
        // │                        Context will be of type TItem                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What generic type parameter does ItemList use to specify
        //           the item type?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the type parameter name   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The generic type parameter name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("TItem", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ItemTemplate_RendersForEachItem()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Template Invocation Per Item
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The component iterates over Items and calls the template for each one.
        // If you have 3 products, ItemTemplate renders 3 times, once for each
        // product with that product as the context.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @foreach (var item in Items)                                       │
        // │  {                                                                  │
        // │      @ItemTemplate(item)   ← Called once per item in Items          │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: How many products are in the demo's product list?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the demo and find all item elements
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();
        var items = cut.FindAll(".item-list-item");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace 0 with the number of products           ║
        // ║                                                                    ║
        // ║  HINT: Count the products in TemplatedComponentDemo's list         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The number of products (divided by 2 because there are 2 ItemLists)
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, items.Count / 2);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_AccessesItemProperties()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Accessing Context Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Inside the template, you can access any property of the context object.
        // For a Product context, you can use context.Name, context.Price,
        // context.Category, etc.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <ItemTemplate Context="product">                                   │
        // │      <span class="product-name">@product.Name</span>                │
        // │      <span class="product-price">$@product.Price</span>             │
        // │  </ItemTemplate>                                                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What is the name of the first product in the demo's list?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the demo and find the first product
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();
        var firstProduct = cut.Find(".product-name");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the first product name    ║
        // ║                                                                    ║
        // ║  HINT: Look at the products list in TemplatedComponentDemo         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The first product name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, firstProduct.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void GenericRenderFragment_TypeInCSharp()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Invoking RenderFragment<T> in Razor
        // ═══════════════════════════════════════════════════════════════════════
        //
        // In C#, a generic RenderFragment is declared as:
        //   [Parameter] public RenderFragment<TItem>? ItemTemplate { get; set; }
        //
        // The <TItem> part means it provides a TItem object to the template.
        // To invoke it in Razor markup, you pass the item as an argument:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @foreach (var item in Items)                                       │
        // │  {                                                                  │
        // │      @ItemTemplate(item)    ← Syntax: @ParameterName(contextValue)  │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: How do you invoke a RenderFragment<T> in Razor markup?
        //           Write the exact syntax used in ItemList's foreach loop.
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the invocation syntax     ║
        // ║                                                                    ║
        // ║  HINT: Format is @ParameterName(variable)                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The invocation syntax
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("@ItemTemplate(item)", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void TypeParam_DeclaresGenericComponent()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The @typeparam Directive
        // ═══════════════════════════════════════════════════════════════════════
        //
        // To create a generic component, use @typeparam at the top of your
        // .razor file. This is equivalent to <TItem> in C# class syntax.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  @typeparam TItem             ← Makes this a generic component      │
        // │                                                                     │
        // │  // Equivalent C# class would be:                                   │
        // │  public class ItemList<TItem> : ComponentBase { }                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What Razor directive declares a type parameter?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the directive             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The directive name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("@typeparam", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_CanUseShortNames()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Short Context Names
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can use any valid C# identifier as the context name. Short names
        // like "p", "item", or "x" are common for concise templates.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <ItemTemplate Context="p">                                         │
        // │      <li>@p.Name - $@p.Price</li>   ← Short and concise             │
        // │  </ItemTemplate>                                                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What short name does the "Full Template" section use in
        //           TemplatedComponentDemo?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the short context name    ║
        // ║                                                                    ║
        // ║  HINT: Look at the last ItemList in TemplatedComponentDemo         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The short context name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("p", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void MultipleRenderFragments_CanCombine()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Combining Generic and Non-Generic RenderFragments
        // ═══════════════════════════════════════════════════════════════════════
        //
        // A component can have both generic RenderFragment<T> and non-generic
        // RenderFragment parameters. ItemList has ItemTemplate (generic), plus
        // Header and Footer (non-generic).
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  // ItemList.razor                                                  │
        // │  <div class="item-list-header">@Header</div>     ← Non-generic      │
        // │  @foreach (var item in Items)                                       │
        // │  {                                                                  │
        // │      @ItemTemplate(item)                         ← Generic          │
        // │  }                                                                  │
        // │  <div class="item-list-footer">@Footer</div>     ← Non-generic      │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What CSS class contains the Header content in ItemList?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the demo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TemplatedComponentDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the CSS class name        ║
        // ║                                                                    ║
        // ║  HINT: Look at the div wrapping @Header in ItemList.razor          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Find the header by class and check its content
        // ──────────────────────────────────────────────────────────────────────
        var header = cut.Find($".{answer}");
        Assert.Contains("Product Catalog", header.TextContent);
    }
}
