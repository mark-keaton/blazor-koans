using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// Radzen provides comprehensive validation components that integrate with
/// RadzenTemplateForm and EditContext:
/// - RadzenRequiredValidator: Ensures field has a value
/// - RadzenEmailValidator: Validates email format
/// - RadzenNumericRangeValidator: Validates numeric ranges
/// - RadzenLengthValidator: Validates string length
/// - RadzenCompareValidator: Compares two fields
/// - RadzenRegexValidator: Custom regex patterns
/// - RadzenCustomValidator: Custom validation logic
///
/// These validators work seamlessly with Radzen form components and
/// provide consistent error messaging and styling.
/// </summary>
public class G_Validation : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_ValidatesEmptyField()
    {
        // ABOUT: RadzenRequiredValidator ensures a field has a value.
        // Component property links to the input's Name property.

        // TODO: What happens when submitting with an empty required field?
        // Replace "__" with the validation error message

        var cut = Render<RadzenValidationDemo>();

        // Submit without filling required field
        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_Component_LinksToField()
    {
        // ABOUT: The Component property on a validator must match the Name
        // property of the input it validates.

        // TODO: What Component value does the Username validator use?
        // Replace "__" with the component name

        var cut = Render<RadzenValidationDemo>();

        var expected = "__";

        Assert.Contains($"Username Component: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_Text_ShowsErrorMessage()
    {
        // ABOUT: The Text property defines the error message shown when validation fails.

        // TODO: What error message appears for empty Username?
        // Replace "__" with the error text

        var cut = Render<RadzenValidationDemo>();

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenEmailValidator_ValidatesEmailFormat()
    {
        // ABOUT: RadzenEmailValidator checks if input matches email format.
        // It validates pattern like "user@domain.com".

        // TODO: Is "invalid-email" a valid email format?
        // Replace true with true or false

        var cut = Render<RadzenValidationDemo>();

        var emailInput = cut.Find("input[name='Email']");
        emailInput.Change("invalid-email");

        cut.Find("form").Submit();

        var expected = true;

        var hasError = cut.Markup.Contains("Invalid email format");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenEmailValidator_AcceptsValidEmail()
    {
        // ABOUT: When email format is correct, RadzenEmailValidator passes.

        // TODO: Is "user@example.com" valid?
        // Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var emailInput = cut.Find("input[name='Email']");
        emailInput.Change("user@example.com");

        cut.Find("form").Submit();

        var expected = false;

        var hasError = cut.Markup.Contains("Invalid email format");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_EnforcesMinimum()
    {
        // ABOUT: RadzenNumericRangeValidator validates that a number is within
        // a specified Min and Max range.

        // TODO: What is the minimum age allowed?
        // Replace 0 with the minimum value

        var cut = Render<RadzenValidationDemo>();

        var expected = 0;

        Assert.Contains($"Min Age: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_EnforcesMaximum()
    {
        // ABOUT: Values above Max trigger validation error.

        // TODO: What is the maximum age allowed?
        // Replace 0 with the maximum value

        var cut = Render<RadzenValidationDemo>();

        var expected = 0;

        Assert.Contains($"Max Age: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_ShowsErrorOutOfRange()
    {
        // ABOUT: When value is outside the range, validator shows error message.

        // TODO: What error appears when Age is 10 (below minimum)?
        // Replace "__" with the error message

        var cut = Render<RadzenValidationDemo>();

        var ageInput = cut.Find("input[name='Age']");
        ageInput.Change("10");

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenLengthValidator_EnforcesMinLength()
    {
        // ABOUT: RadzenLengthValidator ensures string length is within Min and Max.

        // TODO: What is the minimum length for Password?
        // Replace 0 with the minimum length

        var cut = Render<RadzenValidationDemo>();

        var expected = 0;

        Assert.Contains($"Min Password Length: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenLengthValidator_ShowsErrorTooShort()
    {
        // ABOUT: When string is too short, validator displays error.

        // TODO: What error appears for password "12345" (below min length)?
        // Replace "__" with error message

        var cut = Render<RadzenValidationDemo>();

        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("12345");

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCompareValidator_ComparesFields()
    {
        // ABOUT: RadzenCompareValidator ensures two fields have the same value.
        // Common for password confirmation.

        // TODO: If Password is "password123" and ConfirmPassword is "password456",
        // does validation pass? Replace true with true or false

        var cut = Render<RadzenValidationDemo>();

        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("password123");

        var confirmInput = cut.Find("input[name='ConfirmPassword']");
        confirmInput.Change("password456");

        cut.Find("form").Submit();

        var expected = true;

        var hasError = cut.Markup.Contains("Passwords do not match");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCompareValidator_PassesWhenMatching()
    {
        // ABOUT: When both fields match, RadzenCompareValidator passes.

        // TODO: If both Password and ConfirmPassword are "password123",
        // does validation pass? Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("password123");

        var confirmInput = cut.Find("input[name='ConfirmPassword']");
        confirmInput.Change("password123");

        cut.Find("form").Submit();

        var expected = false;

        var hasError = cut.Markup.Contains("Passwords do not match");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRegexValidator_ValidatesPattern()
    {
        // ABOUT: RadzenRegexValidator checks if input matches a regex pattern.
        // Useful for phone numbers, zip codes, custom formats.

        // TODO: Does "123-456-7890" match the phone number pattern?
        // Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var phoneInput = cut.Find("input[name='Phone']");
        phoneInput.Change("123-456-7890");

        cut.Find("form").Submit();

        var expected = false;

        var hasError = cut.Markup.Contains("Invalid phone format");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRegexValidator_ShowsErrorInvalidPattern()
    {
        // ABOUT: When input doesn't match pattern, error is shown.

        // TODO: Does "abcd" match the phone number pattern?
        // Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var phoneInput = cut.Find("input[name='Phone']");
        phoneInput.Change("abcd");

        cut.Find("form").Submit();

        var expected = false;

        var hasError = cut.Markup.Contains("Invalid phone format");
        Assert.Equal(expected, hasError);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_IntegratesValidators()
    {
        // ABOUT: RadzenTemplateForm automatically manages validators.
        // It tracks validation state and triggers validation on submit.

        // TODO: How many validation errors exist with all fields empty?
        // Replace 0 with the count

        var cut = Render<RadzenValidationDemo>();

        cut.Find("form").Submit();

        var expected = 0;

        Assert.Contains($"Validation Errors: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_OnValidSubmit_FiresWhenValid()
    {
        // ABOUT: OnValidSubmit fires only when all validators pass.

        // TODO: After filling all fields correctly and submitting, what status appears?
        // Replace "__" with the submit status

        var cut = Render<RadzenValidationDemo>();

        cut.Find("input[name='Username']").Change("john_doe");
        cut.Find("input[name='Email']").Change("john@example.com");
        cut.Find("input[name='Age']").Change("25");
        cut.Find("input[name='Password']").Change("password123");
        cut.Find("input[name='ConfirmPassword']").Change("password123");
        cut.Find("input[name='Phone']").Change("123-456-7890");

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains($"Submit Status: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_OnInvalidSubmit_FiresWhenInvalid()
    {
        // ABOUT: OnInvalidSubmit fires when validation fails.

        // TODO: After submitting with invalid data, what status appears?
        // Replace "__" with the submit status

        var cut = Render<RadzenValidationDemo>();

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains($"Submit Status: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenValidationSummary_DisplaysAllErrors()
    {
        // ABOUT: RadzenValidationSummary shows all validation errors in one place.
        // Useful for displaying errors at the top of the form.

        // TODO: Does the form have a validation summary component?
        // Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var expected = false;

        Assert.Contains($"Has Validation Summary: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCustomValidator_CustomLogic()
    {
        // ABOUT: RadzenCustomValidator allows custom validation logic via Validator property.
        // You provide a function that returns true if valid, false if invalid.

        // TODO: Does the Username have a custom validator checking for "admin"?
        // Replace false with true or false

        var cut = Render<RadzenValidationDemo>();

        var expected = false;

        Assert.Contains($"Has Custom Validator: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCustomValidator_ShowsCustomError()
    {
        // ABOUT: RadzenCustomValidator displays custom error messages.

        // TODO: What error appears when Username is "admin"?
        // Replace "__" with the error message

        var cut = Render<RadzenValidationDemo>();

        var usernameInput = cut.Find("input[name='Username']");
        usernameInput.Change("admin");

        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }
}
