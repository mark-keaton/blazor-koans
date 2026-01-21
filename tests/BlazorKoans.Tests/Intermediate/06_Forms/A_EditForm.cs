using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          BLAZOR EDITFORM                                     ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  EditForm is Blazor's built-in form component that provides:                 ║
/// ║  • Model binding - connects form inputs to a C# object                       ║
/// ║  • Validation - integrates with DataAnnotations                              ║
/// ║  • Submit handling - OnValidSubmit, OnInvalidSubmit callbacks                ║
/// ║                                                                              ║
/// ║  Basic structure:                                                            ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;EditForm Model="@person" OnValidSubmit="HandleSubmit"&gt;               │  ║
/// ║  │      &lt;InputText @bind-Value="person.Name" /&gt;                           │  ║
/// ║  │      &lt;button type="submit"&gt;Submit&lt;/button&gt;                             │  ║
/// ║  │  &lt;/EditForm&gt;                                                           │  ║
/// ║  │                                                                        │  ║
/// ║  │  @code {                                                               │  ║
/// ║  │      private Person person = new();                                    │  ║
/// ║  │      void HandleSubmit() { /* process form */ }                        │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_EditForm : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditForm_BindsToModel()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Model Binding in EditForm
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditForm's Model parameter specifies the object to bind to.
        // Input components use @bind-Value to connect to model properties.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <EditForm Model="@person">                                         │
        // │      <InputText @bind-Value="person.Name" />                        │
        // │  </EditForm>           ↑                                            │
        // │                        Two-way binding to model property            │
        // │                                                                     │
        // │  @code {                                                            │
        // │      private Person person = new() { Name = "" };                   │
        // │  }                                     ↑                            │
        // │                          Initial value appears in input             │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // InputText renders as: <input name="person.Name" value="...">
        //
        // EXERCISE: FormDemo initializes a Person with what default Name value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the FormDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial value of person.Name?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the input's value attribute matches the model
        // ──────────────────────────────────────────────────────────────────────
        var nameInput = cut.Find("input[name='person.Name']");
        Assert.Equal(answer, nameInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditForm_UpdatesModelOnInput()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Two-Way Binding Updates the Model
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When the user types in an InputText, the model property updates.
        // This is two-way binding - UI changes flow back to the C# object.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  User types "Alice" → person.Name becomes "Alice"                   │
        // │                                                                     │
        // │  <InputText @bind-Value="person.Name" />                            │
        // │  <p>Name: @person.Name</p>   ← Also updates to show "Alice"         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: After typing "Alice" in the input, what value is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and typing in the input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Alice");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What name is displayed after typing "Alice"?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The displayed name should match your answer
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Name: {answer}", cut.Markup);
    }
}
