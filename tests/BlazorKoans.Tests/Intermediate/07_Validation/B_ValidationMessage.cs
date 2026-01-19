using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

public class B_ValidationMessage : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationMessage_DisplaysFieldErrors()
    {
        // ABOUT: ValidationMessage displays validation errors for a specific field
        // It uses the For parameter to bind to a field

        // TODO: Replace "__" with the error message text for required Name
        // HINT: Check the [Required] ErrorMessage on Person.Name

        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        var expected = "__"; // SOLUTION: "Name is required"

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationMessage_ShowsEmailError()
    {
        // ABOUT: Different fields can have different validation messages

        // TODO: Replace "__" with part of the email validation error message
        // HINT: Look at the [EmailAddress] attribute on Person.Email

        var cut = Render<ValidationDemo>();

        var emailInput = cut.FindAll("input")[1]; // Second input is email
        emailInput.Change("invalid-email");

        var form = cut.Find("form");
        form.Submit();

        var expected = "__"; // SOLUTION: "Invalid email address"

        Assert.Contains(expected, cut.Markup);
    }
}
