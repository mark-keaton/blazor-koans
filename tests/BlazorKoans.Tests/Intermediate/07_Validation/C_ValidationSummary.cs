using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

public class C_ValidationSummary : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationSummary_ShowsAllErrors()
    {
        // ABOUT: ValidationSummary displays all validation errors in one place
        // It's useful for showing a comprehensive list of issues

        // TODO: Replace 0 with the number of validation errors when submitting empty form
        // HINT: Count the [Required] fields on Person (Name, Email, Age range)

        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        var expected = 3; // SOLUTION: 3 (Name required, Email required, Age range)

        Assert.Equal(expected, cut.Instance.ErrorCount);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void ValidationSummary_UpdatesOnChange()
    {
        // ABOUT: ValidationSummary updates as fields are corrected

        // TODO: Replace 0 with error count after fixing Name but leaving Email/Age invalid
        // HINT: Fixing Name removes 1 error, but Email and Age still fail

        var cut = Render<ValidationDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Alice");

        var form = cut.Find("form");
        form.Submit();

        var expected = 2; // SOLUTION: 2 (Email required, Age range)

        Assert.Equal(expected, cut.Instance.ErrorCount);
    }
}
