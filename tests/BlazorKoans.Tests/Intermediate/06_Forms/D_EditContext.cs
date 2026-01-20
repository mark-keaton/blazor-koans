using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

public class D_EditContext : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_TracksFieldChanges()
    {
        // ABOUT: EditContext provides fine-grained control over form state
        // OnFieldChanged event fires when any field value changes

        // TODO: Replace "__" with the field name that changed
        // HINT: Look at the HandleFieldChanged method in RegistrationForm.razor

        var cut = Render<RegistrationForm>();

        // InputText renders with name attribute matching the model binding path
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("testuser");

        var expected = "__";

        Assert.Contains($"Field Changed: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_TracksMultipleFields()
    {
        // ABOUT: EditContext tracks changes to each field independently

        // TODO: Replace "__" with the field name of the email input
        // HINT: The email input binds to model.Email

        var cut = Render<RegistrationForm>();

        var emailInput = cut.Find("input[type='email']");
        emailInput.Change("test@example.com");

        var expected = "__";

        Assert.Contains($"Field Changed: {expected}", cut.Markup);
    }
}
