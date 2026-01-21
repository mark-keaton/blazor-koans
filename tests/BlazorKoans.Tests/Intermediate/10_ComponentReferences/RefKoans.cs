using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;

namespace BlazorKoans.Tests.Intermediate._10_ComponentReferences;

/// <summary>
/// Component References in Blazor (@ref directive)
///
/// The @ref directive allows you to capture a reference to a component or HTML element.
/// With a component reference, you can:
/// - Call methods on the component directly
/// - Access public properties and fields
/// - Trigger component updates programmatically
///
/// This is essential for scenarios like:
/// - Calling Reload() on a data grid after data changes
/// - Focusing an input element programmatically
/// - Coordinating between parent and child components
/// </summary>
public class RefKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void A_RefCapturesComponent()
    {
        // ABOUT: The @ref directive captures a reference to a component instance.
        // In the parent, you declare a field to hold the reference:
        //   private ChildComponent? childRef;
        // Then bind it in the markup: <ChildComponent @ref="childRef" />
        // After rendering, childRef holds the actual component instance.

        // TODO: Look at RefDemo.razor. It has a reference to RefChildComponent.
        // The child component has a public property called "DisplayName".
        // What is the initial value of DisplayName on the child component?
        // Replace "__" with the expected value.

        var cut = Render<RefDemo>();

        var expectedDisplayName = "__";

        // The RefDemo exposes what the child's DisplayName is
        var displayedName = cut.Find(".child-name").TextContent;
        Assert.Equal(expectedDisplayName, displayedName);

        // HINT: Look at RefChildComponent.razor for the default DisplayName value
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void B_CallMethodOnRef()
    {
        // ABOUT: Once you have a component reference, you can call its public methods.
        // This allows parent components to control child behavior directly.
        // Example: childRef?.SomeMethod() calls SomeMethod on the child.

        // TODO: The RefDemo has a button that calls UpdateName() on the child.
        // After clicking the "Update Child Name" button, what is the new DisplayName?
        // Replace "__" with the expected value.

        var cut = Render<RefDemo>();

        // Click the button that calls child's method
        cut.Find("button.update-name").Click();

        var expectedNewName = "__";

        var displayedName = cut.Find(".child-name").TextContent;
        Assert.Equal(expectedNewName, displayedName);

        // HINT: Look at what UpdateName() does in RefChildComponent
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void C_RefIsNullBeforeRender()
    {
        // ABOUT: Component references are null until after the first render.
        // You cannot access @ref during OnInitialized or OnParametersSet.
        // The reference is populated after OnAfterRender(firstRender: true).
        // Always null-check before using: componentRef?.Method()

        // TODO: The RefDemo tracks whether the ref was null in OnInitialized.
        // Was the child reference null during OnInitialized?
        // Replace false with true if it was null, or keep false.

        var cut = Render<RefDemo>();

        var wasNullInInit = false;

        var wasNullText = cut.Find(".ref-null-in-init").TextContent;
        Assert.Equal(wasNullInInit.ToString(), wasNullText);

        // HINT: @ref is populated AFTER render, not during initialization
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void D_RefWithCounter()
    {
        // ABOUT: A common pattern is calling methods to update state in the child.
        // The parent triggers actions, and the child manages its own state.
        // This keeps components encapsulated while allowing coordination.

        // TODO: The RefChildComponent has an IncrementCounter() method.
        // The RefDemo has a button that calls this method.
        // After clicking "Increment Counter" twice, what is the counter value?
        // Replace 0 with the expected value.

        var cut = Render<RefDemo>();

        // Click increment button twice
        cut.Find("button.increment-counter").Click();
        cut.Find("button.increment-counter").Click();

        var expectedCounter = 0;

        var counterText = cut.Find(".child-counter").TextContent;
        Assert.Equal(expectedCounter.ToString(), counterText);

        // HINT: Each click calls IncrementCounter() which adds 1 to the counter
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void E_RefWithReset()
    {
        // ABOUT: Methods on child components can perform any action.
        // A common pattern is having Reset() methods to restore initial state.
        // This is useful for forms, counters, or any stateful component.

        // TODO: Click increment 3 times, then click reset.
        // What is the counter value after reset?
        // Replace 0 with the expected value.

        var cut = Render<RefDemo>();

        // Increment 3 times
        cut.Find("button.increment-counter").Click();
        cut.Find("button.increment-counter").Click();
        cut.Find("button.increment-counter").Click();

        // Now reset
        cut.Find("button.reset-child").Click();

        var expectedCounterAfterReset = 0;

        var counterText = cut.Find(".child-counter").TextContent;
        Assert.Equal(expectedCounterAfterReset.ToString(), counterText);

        // HINT: Reset() should restore the counter to its initial value
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void F_ElementReference()
    {
        // ABOUT: @ref can also capture HTML element references (ElementReference).
        // This is useful for JavaScript interop, like focusing an input.
        // Syntax: <input @ref="inputElement" /> where inputElement is ElementReference
        // ElementReference is a struct, not null - use .Id to check if it's set.

        // TODO: The RefDemo has an input with @ref="inputRef".
        // The component tracks whether the ElementReference has an Id.
        // After render, does the element reference have an Id?
        // Replace false with true if it has an Id.

        var cut = Render<RefDemo>();

        var hasElementRefId = false;

        var hasIdText = cut.Find(".has-element-ref").TextContent;
        Assert.Equal(hasElementRefId.ToString(), hasIdText);

        // HINT: ElementReference gets an Id after the element is rendered
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void G_MultipleRefs()
    {
        // ABOUT: You can have multiple @ref fields for different components.
        // Each reference is independent and captures its specific component.
        // This allows coordinating multiple child components from a parent.

        // TODO: The RefDemo has two RefChildComponent instances with different refs.
        // Each has a different initial name. How many child components are shown?
        // Replace 0 with the expected count.

        var cut = Render<RefDemo>();

        var expectedChildCount = 0;

        var children = cut.FindAll(".ref-child-component");
        Assert.Equal(expectedChildCount, children.Count);

        // HINT: Count the <RefChildComponent> instances in RefDemo.razor
    }
}
