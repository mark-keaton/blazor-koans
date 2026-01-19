using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

public class C_FormSubmission : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void OnValidSubmit_TriggersWhenFormIsValid()
    {
        // ABOUT: OnValidSubmit is called when the form is submitted and all validations pass

        // TODO: Replace false with the value of IsSubmitted after a valid submit
        // HINT: Look at the HandleValidSubmit method in FormDemo.razor

        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[type='text']");
        nameInput.Change("Charlie");

        var form = cut.Find("form");
        form.Submit();

        var expected = false; // SOLUTION: true

        Assert.Contains($"Submitted: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void FormSubmit_UpdatesComponentState()
    {
        // ABOUT: Form submission can update component properties

        // TODO: Replace false with true to match the expected behavior
        // HINT: IsSubmitted becomes true after HandleValidSubmit is called

        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[type='text']");
        nameInput.Change("David");

        var form = cut.Find("form");
        form.Submit();

        var expected = false; // SOLUTION: true

        Assert.Equal(expected, cut.Instance.IsSubmitted);
    }
}
