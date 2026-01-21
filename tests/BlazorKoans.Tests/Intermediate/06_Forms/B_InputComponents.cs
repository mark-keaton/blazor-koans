using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                       BLAZOR INPUT COMPONENTS                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Blazor provides specialized input components for different data types.      ║
/// ║  They integrate with EditForm for validation and model binding.              ║
/// ║                                                                              ║
/// ║  Built-in Input Components:                                                  ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  InputText       → string      → &lt;input&gt;                               │  ║
/// ║  │  InputNumber&lt;T&gt;  → int/decimal → &lt;input type="number"&gt;                 │  ║
/// ║  │  InputDate&lt;T&gt;    → DateTime    → &lt;input type="date"&gt;                   │  ║
/// ║  │  InputCheckbox   → bool        → &lt;input type="checkbox"&gt;               │  ║
/// ║  │  InputSelect&lt;T&gt;  → enum/value  → &lt;select&gt;                              │  ║
/// ║  │  InputTextArea   → string      → &lt;textarea&gt;                            │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  All use @bind-Value for two-way binding to model properties.                ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_InputComponents : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputText_BindsStringProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: InputText for String Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // InputText is for string properties and renders as a standard text input.
        // Use @bind-Value to connect it to your model:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <InputText @bind-Value="person.Name" />                            │
        // │              ↑                                                      │
        // │         Two-way binding - typing updates person.Name                │
        // │                                                                     │
        // │  Renders as: <input name="person.Name" value="...">                 │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: After typing "Bob" in the InputText, what name is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and typing in the input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Bob");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What name appears after typing "Bob"?           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The displayed name should match your answer
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Name: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputNumber_BindsNumericProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: InputNumber for Numeric Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // InputNumber<T> binds to numeric types: int, decimal, double, etc.
        // It renders with type="number" for browser number input features.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <InputNumber @bind-Value="person.Age" />                           │
        // │                                                                     │
        // │  Renders as: <input type="number" ...>                              │
        // │              ↑                                                      │
        // │         Browser shows spinner controls, validates numeric input     │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What HTML type attribute does InputNumber render?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the type attribute value?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Find the input and check its type attribute
        // ──────────────────────────────────────────────────────────────────────
        var ageInput = cut.Find("input[type='number']");
        Assert.Equal(answer, ageInput.GetAttribute("type"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputDate_BindsDateTimeProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: InputDate for DateTime Properties
        // ═══════════════════════════════════════════════════════════════════════
        //
        // InputDate<T> binds to DateTime, DateTimeOffset, or DateOnly.
        // It renders with type="date" for browser date picker features.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <InputDate @bind-Value="person.BirthDate" />                       │
        // │                                                                     │
        // │  Renders as: <input type="date" ...>                                │
        // │              ↑                                                      │
        // │         Browser shows calendar picker                               │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: What HTML type attribute does InputDate render?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the registration form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the type attribute value?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Find the input and check its type attribute
        // ──────────────────────────────────────────────────────────────────────
        var dateInput = cut.Find("input[type='date']");
        Assert.Equal(answer, dateInput.GetAttribute("type"));
    }
}
