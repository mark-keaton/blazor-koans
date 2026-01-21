using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._09_TemplatedComponents;

/// <summary>
/// RenderFragment&lt;T&gt; is the generic version that provides a "context" object.
/// This enables templated components - components that let the parent define
/// how each item should render while the child handles the iteration/structure.
///
/// The classic example is a list component: the component handles the loop,
/// but the parent decides how each item looks via a template.
///
/// The Context attribute lets you name the parameter for cleaner code.
/// Without it, you use the default name "context".
/// </summary>
public class B_GenericRenderFragment : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void GenericRenderFragment_ProvidesContextObject()
    {
        // ABOUT: RenderFragment<T> is declared as a parameter that provides
        // an object of type T to the template. The component calls the template
        // with each item: @ItemTemplate(item)

        // TODO: In ItemList, what is the parameter name for the generic template?
        // HINT: Look at the [Parameter] declarations in ItemList.razor

        var expected = "ItemTemplate";

        Assert.Equal("ItemTemplate", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_DefaultNameIsContext()
    {
        // ABOUT: When you don't specify a Context attribute, the default
        // name for the context object is simply "context". You access
        // properties like @context.Name, @context.Price, etc.

        // TODO: What is the default name for the context variable?

        var cut = Render<TemplatedComponentDemo>();

        // The demo has a section using default context name
        var expected = "context";

        var defaultContextSpan = cut.Find(".default-context");
        Assert.NotNull(defaultContextSpan);
        Assert.Equal("context", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_CanBeRenamed()
    {
        // ABOUT: The Context attribute on a template lets you rename the
        // context variable. Context="product" means you write @product.Name
        // instead of @context.Name. This makes templates more readable.

        // TODO: In the "Generic RenderFragment with Context" section,
        // what name is used for the context?
        // HINT: Look for Context="..." in TemplatedComponentDemo.razor

        var expected = "product";

        Assert.Equal("product", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_TypeComesFromTItem()
    {
        // ABOUT: The type of the context object is determined by the TItem
        // generic parameter. If you have ItemList<Product>, then the context
        // in ItemTemplate is a Product. Blazor infers this from the component.

        // TODO: What attribute on ItemList specifies the item type?

        var expected = "TItem";

        Assert.Equal("TItem", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ItemTemplate_RendersForEachItem()
    {
        // ABOUT: The component iterates over Items and calls the template
        // for each one. If you have 3 products, ItemTemplate renders 3 times,
        // once for each product with that product as the context.

        // TODO: How many products are in the demo's list?
        // HINT: Count the <li> elements rendered by ItemList

        var cut = Render<TemplatedComponentDemo>();

        var expected = 3;

        var items = cut.FindAll(".item-list-item");
        Assert.Equal(expected, items.Count / 2); // Divided by 2 because there are 2 ItemLists
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_AccessesItemProperties()
    {
        // ABOUT: Inside the template, you can access any property of the
        // context object. For a Product context, you can use context.Name,
        // context.Price, context.Category, etc.

        // TODO: What is the name of the first product in the list?
        // HINT: Look at the products list in TemplatedComponentDemo

        var cut = Render<TemplatedComponentDemo>();

        var expected = "Laptop";

        var firstProduct = cut.Find(".product-name");
        Assert.Contains(expected, firstProduct.TextContent);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void GenericRenderFragment_TypeInCSharp()
    {
        // ABOUT: In C#, a generic RenderFragment is declared as:
        // [Parameter] public RenderFragment<TItem>? ItemTemplate { get; set; }
        // The <TItem> part means it provides a TItem object to the template.

        // TODO: How do you invoke a RenderFragment<T> in Razor markup?
        // HINT: Look at how ItemList calls ItemTemplate in the foreach loop

        var expected = "@ItemTemplate(item)"; // Something like "@Template(item)" or "@Template"

        // The syntax is @ParameterName(contextValue)
        Assert.Equal("@ItemTemplate(item)", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void TypeParam_DeclaresGenericComponent()
    {
        // ABOUT: To create a generic component, use @typeparam at the top
        // of your .razor file. This is equivalent to <TItem> in C# class syntax.
        // ItemList uses @typeparam TItem to become generic.

        // TODO: What Razor directive declares a type parameter?

        var expected = "@typeparam";

        Assert.Equal("@typeparam", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void Context_CanUseShortNames()
    {
        // ABOUT: You can use any valid C# identifier as the context name.
        // Short names like "p", "item", or "x" are common for concise templates.
        // The "Full Template" section uses Context="p" for brevity.

        // TODO: What short name does the "Full Template" section use?
        // HINT: Look at the last ItemList in TemplatedComponentDemo

        var expected = "p";

        Assert.Equal("p", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void MultipleRenderFragments_CanCombine()
    {
        // ABOUT: A component can have both generic RenderFragment<T> and
        // non-generic RenderFragment parameters. ItemList has ItemTemplate
        // (generic), plus Header and Footer (non-generic).

        // TODO: What class contains the Header content in ItemList?
        // HINT: Look at the div wrapping @Header in ItemList.razor

        var cut = Render<TemplatedComponentDemo>();

        var expected = "item-list-header";

        var header = cut.Find($".{expected}");
        Assert.Contains("Product Catalog", header.TextContent);
    }
}
