using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                     VALIDATION MESSAGE COMPONENT                             ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  ValidationMessage displays errors for a SPECIFIC field.                     ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;InputText @bind-Value="person.Name" /&gt;                              │  ║
/// ║  │  &lt;ValidationMessage For="() =&gt; person.Name" /&gt;                        │  ║
/// ║  │                          ↑                                            │  ║
/// ║  │         Lambda expression pointing to the field                       │  ║
/// ║  │                                                                        │  ║
/// ║  │  Output when invalid: &lt;div class="validation-message"&gt;Error&lt;/div&gt;      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_ValidationMessage : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationMessage_DisplaysFieldErrors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Displaying Field-Specific Errors
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ValidationMessage shows the error for ONE specific field.
        // The error text comes from the ErrorMessage on the validation attribute.
        //
        // EXERCISE: Check the [Required] attribute on Person.Name.
        //           What ErrorMessage will appear when Name is empty?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - submitting empty form to trigger validation
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What error message appears for Name?             ║
        // ║                                                                    ║
        // ║  HINT: Check the ErrorMessage property on [Required] for Name      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The error message should appear in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationMessage_ShowsEmailError()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Different Fields Have Different Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Each field's ValidationMessage shows that field's errors.
        // [EmailAddress] has a default message about valid email format.
        //
        // EXERCISE: What message appears when you enter "invalid-email"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - entering invalid email and submitting
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var emailInput = cut.FindAll("input")[1];
        emailInput.Change("invalid-email");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What part of the email error message appears?   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The email error message should be in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }
}
