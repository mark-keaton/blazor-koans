using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

public class A_DataAnnotations : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_RequiredValidation()
    {
        // ABOUT: [Required] attribute ensures a field has a value
        // Blazor validates this automatically when using DataAnnotationsValidator

        // TODO: Replace false with true if validation should fail for empty required fields
        // HINT: Look at the Person model - is Name marked as [Required]?

        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        var expected = false;

        // Should trigger OnInvalidSubmit
        Assert.Equal(expected, cut.Instance.IsInvalid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_RangeValidation()
    {
        // ABOUT: [Range] attribute validates that a number is within specified bounds
        // For example, Age must be between 18 and 120

        // TODO: Replace false with true if Age=5 should fail validation
        // HINT: Check the [Range] attribute on Person.Age

        var cut = Render<ValidationDemo>();

        var ageInput = cut.Find("input[type='number']");
        ageInput.Change("5");

        var form = cut.Find("form");
        form.Submit();

        var expected = false;

        Assert.Equal(expected, cut.Instance.IsInvalid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_StringLengthValidation()
    {
        // ABOUT: [StringLength] validates that a string is within min/max length
        // Person.Name must be between 2 and 50 characters

        // TODO: Replace false with true if a 1-character name should fail
        // HINT: Check the [StringLength] attribute on Person.Name

        var cut = Render<ValidationDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("A");

        var form = cut.Find("form");
        form.Submit();

        var expected = false;

        Assert.Equal(expected, cut.Instance.IsInvalid);
    }
}
