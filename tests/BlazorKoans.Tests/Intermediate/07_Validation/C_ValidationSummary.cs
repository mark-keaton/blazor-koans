using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    VALIDATION SUMMARY COMPONENT                              ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  ValidationSummary displays ALL validation errors in one place.              ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;EditForm Model="@person"&gt;                                           │  ║
/// ║  │      &lt;DataAnnotationsValidator /&gt;                                     │  ║
/// ║  │      &lt;ValidationSummary /&gt;          ← Shows all errors in a list      │  ║
/// ║  │      ...inputs...                                                     │  ║
/// ║  │  &lt;/EditForm&gt;                                                          │  ║
/// ║  │                                                                        │  ║
/// ║  │  Output:                                                               │  ║
/// ║  │  &lt;ul class="validation-errors"&gt;                                        │  ║
/// ║  │      &lt;li&gt;Name is required&lt;/li&gt;                                         │  ║
/// ║  │      &lt;li&gt;Email is required&lt;/li&gt;                                        │  ║
/// ║  │  &lt;/ul&gt;                                                                 │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_ValidationSummary : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationSummary_ShowsAllErrors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Counting Validation Errors
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ValidationSummary shows one error per failed validation rule.
        // Count the [Required] and other validation attributes to predict
        // how many errors will appear.
        //
        // EXERCISE: How many validation errors when submitting empty form?
        //           Count the required fields and constraints on the model.
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - submitting empty form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many errors with all empty fields?           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The error count should match failed validations
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.ErrorCount);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationSummary_UpdatesOnChange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Errors Update as Fields Are Fixed
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you fix one field, that error disappears from the summary.
        // Other invalid fields still show their errors.
        //
        // EXERCISE: After entering a valid Name but leaving Email/Age empty,
        //           how many errors remain?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - fixing Name, leaving others invalid
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Alice");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many errors after fixing Name only?          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Error count should be reduced by one
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.ErrorCount);
    }
}
