using Bunit;
using BlazorKoans.App.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

public class D_CustomValidation : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void CustomValidation_MinimumAgeAttribute()
    {
        // ABOUT: Custom validation attributes extend ValidationAttribute
        // They implement custom validation logic beyond built-in attributes

        // TODO: Replace false with true if a 15-year-old should fail MinimumAge(18)
        // HINT: Look at the MinimumAgeAttribute implementation

        var model = new RegistrationModel
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123",
            BirthDate = DateTime.Today.AddYears(-15),
            AcceptTerms = true
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        var expected = false;

        Assert.Equal(expected, !isValid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void CustomValidation_PassesWhenValid()
    {
        // ABOUT: Custom validators should return success when criteria are met

        // TODO: Replace false with true if a 25-year-old should pass MinimumAge(18)
        // HINT: 25 is greater than or equal to 18

        var model = new RegistrationModel
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123",
            BirthDate = DateTime.Today.AddYears(-25),
            AcceptTerms = true
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        var expected = false;

        Assert.Equal(expected, isValid);
    }
}
