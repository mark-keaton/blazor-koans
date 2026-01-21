using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner._06_Loops;

/// <summary>
/// Loops and Iteration in Blazor
///
/// Blazor provides several ways to iterate over collections and render repeated content:
/// - @foreach: Iterates over any IEnumerable, rendering markup for each item
/// - @for: Traditional C# for loop, useful when you need an index
/// - @key: Directive that helps Blazor efficiently track and update list items
///
/// Understanding loops is essential for rendering dynamic lists, tables, and any
/// repeating UI patterns in your Blazor applications.
/// </summary>
public class LoopKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_Foreach()
    {
        // ABOUT: @foreach is the most common way to render a collection in Blazor.
        // It iterates over any IEnumerable and renders markup for each item.
        // Syntax: @foreach (var item in collection) { <markup>@item</markup> }

        // TODO: Look at the LoopDemo component. It renders a list of fruit items.
        // How many <li class="item"> elements are rendered?
        // Replace 0 with the expected count.

        var cut = Render<LoopDemo>();

        var expectedItemCount = 0;

        var items = cut.FindAll("li.item");
        Assert.Equal(expectedItemCount, items.Count);

        // HINT: Count the items in the Items list defined in LoopDemo.razor
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_ForeachWithIndex()
    {
        // ABOUT: Sometimes you need the index along with each item.
        // You can achieve this by using .Select((item, index) => ...) from LINQ,
        // or by maintaining a counter variable within the loop.
        // This is useful for numbering items or applying alternating styles.

        // TODO: The LoopDemo component renders numbered items with the format "1. Apple".
        // What text is displayed in the SECOND numbered item?
        // Replace "__" with the complete text (e.g., "2. Banana").

        var cut = Render<LoopDemo>();

        var expectedSecondItem = "__";

        var numberedItems = cut.FindAll("li.numbered-item");
        Assert.True(numberedItems.Count >= 2, "Expected at least 2 numbered items");
        Assert.Equal(expectedSecondItem, numberedItems[1].TextContent);

        // HINT: Look at how the numbered list uses Select to pair items with their index
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_ForLoop()
    {
        // ABOUT: @for loops work just like regular C# for loops.
        // They're useful when you need precise control over iteration,
        // such as iterating a specific number of times or accessing items by index.
        // Syntax: @for (int i = 0; i < count; i++) { <markup>@i</markup> }

        // TODO: The LoopDemo component uses a @for loop to render number squares.
        // It displays numbers 1 through N with their squares.
        // What is displayed in the element with class "square-3"?
        // Replace "__" with the expected text (format: "3 squared = 9").

        var cut = Render<LoopDemo>();

        var expectedSquareText = "__";

        var squareElement = cut.Find(".square-3");
        Assert.Equal(expectedSquareText, squareElement.TextContent);

        // HINT: The format is "{number} squared = {number * number}"
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_EmptyCollection()
    {
        // ABOUT: When rendering collections, you should handle the empty case gracefully.
        // A common pattern is to use @if to check if the collection has items,
        // and show a message or alternative content when it's empty.
        // This improves UX by informing users there's no data to display.

        // TODO: Look at how LoopDemo handles the EmptyItems collection.
        // What message is displayed when the collection is empty?
        // Replace "__" with the exact message text.

        var cut = Render<LoopDemo>();

        var expectedEmptyMessage = "__";

        var emptyMessage = cut.Find(".empty-message");
        Assert.Equal(expectedEmptyMessage, emptyMessage.TextContent);

        // HINT: Look for the conditional rendering that checks EmptyItems.Any()
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void E_NestedLoops()
    {
        // ABOUT: You can nest @foreach loops to render hierarchical data.
        // This is common for categories with items, tree structures, or grids.
        // Each inner loop renders within the context of its parent item.

        // TODO: The LoopDemo component renders categories with nested items.
        // How many total nested items are rendered across ALL categories?
        // Replace 0 with the expected total count of .nested-item elements.

        var cut = Render<LoopDemo>();

        var expectedNestedItemCount = 0;

        var nestedItems = cut.FindAll(".nested-item");
        Assert.Equal(expectedNestedItemCount, nestedItems.Count);

        // HINT: Count all items across all categories in the Categories list
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void F_KeyAttribute()
    {
        // ABOUT: The @key directive helps Blazor efficiently track elements in a list.
        // When items are added, removed, or reordered, @key tells Blazor which DOM
        // elements correspond to which data items, avoiding unnecessary re-renders.
        // Use @key with a unique identifier for each item (like an ID or unique value).

        // TODO: Look at the keyed list in LoopDemo. Each item uses @key="item.Id".
        // The component has a button to add a new item to the beginning of the list.
        // After clicking the "Add Item" button, what is the Id of the FIRST item?
        // Replace 0 with the expected Id.

        var cut = Render<LoopDemo>();

        var addButton = cut.Find("button.add-item");
        addButton.Click();

        var expectedFirstItemId = 0;

        var firstKeyedItem = cut.Find(".keyed-item");
        var actualId = int.Parse(firstKeyedItem.GetAttribute("data-id") ?? "0");
        Assert.Equal(expectedFirstItemId, actualId);

        // HINT: New items are added to the beginning with an incrementing Id
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void G_RemoveFromList()
    {
        // ABOUT: When removing items from a list, Blazor uses @key to efficiently
        // update only the affected DOM elements. Without @key, Blazor might
        // re-render more elements than necessary.

        // TODO: The LoopDemo component has keyed items with remove buttons.
        // Initially there are 3 items. After clicking the remove button on the first item,
        // how many keyed items remain?
        // Replace 0 with the expected count.

        var cut = Render<LoopDemo>();

        // Get initial count
        var initialCount = cut.FindAll(".keyed-item").Count;
        Assert.Equal(3, initialCount); // Verify we start with 3

        // Remove the first item
        var removeButton = cut.Find(".keyed-item .remove-item");
        removeButton.Click();

        var expectedRemainingCount = 0;

        var remainingItems = cut.FindAll(".keyed-item");
        Assert.Equal(expectedRemainingCount, remainingItems.Count);

        // HINT: Removing one item from a list of 3 leaves how many?
    }
}
