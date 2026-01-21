using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          FORM SUBMISSION                                     ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  EditForm provides three submission callbacks:                               ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  OnValidSubmit     → Called when form is valid                        │  ║
/// ║  │  OnInvalidSubmit   → Called when form has validation errors           │  ║
/// ║  │  OnSubmit          → Called always (you handle validation manually)   │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Use OnValidSubmit + OnInvalidSubmit together, OR use OnSubmit alone.        ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_FormSubmission : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void OnValidSubmit_TriggersWhenFormIsValid()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnValidSubmit Callback
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnValidSubmit is called ONLY when the form passes all validations.
        // This is where you typically save data or call an API.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <EditForm Model="@person" OnValidSubmit="HandleValidSubmit">       │
        // │      ...inputs...                                                  │
        // │  </EditForm>                                                        │
        // │                                                                     │
        // │  @code {                                                            │
        // │      bool IsSubmitted = false;                                      │
        // │                                                                     │
        // │      void HandleValidSubmit()                                       │
        // │      {                                                              │
        // │          IsSubmitted = true;   ← Only runs if form is valid        │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: After a valid submit, what is IsSubmitted?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - filling valid data and submitting
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Charlie");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is IsSubmitted after valid submit?          ║
        // ║      Change 'false' to 'true' if OnValidSubmit runs                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if IsSubmitted reflects the callback running
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Submitted: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void FormSubmit_UpdatesComponentState()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Form Submission Updates State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Submission handlers can update component state, triggering re-renders.
        // This is how you show "success" messages or update the UI after submit.
        //
        // EXERCISE: After HandleValidSubmit runs, what is cut.Instance.IsSubmitted?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - filling data and submitting
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("David");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is IsSubmitted true or false after submit?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the component property directly
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.IsSubmitted);
    }
}
