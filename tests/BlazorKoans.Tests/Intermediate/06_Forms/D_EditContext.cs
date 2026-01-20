using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

/// <summary>
/// EditContext is the backbone of Blazor form handling. It tracks:
/// - Which fields have been modified
/// - Validation state for each field and the entire form
/// - Events when fields change or validation state changes
///
/// Think of EditContext as a "form supervisor" that watches everything happening
/// in your form and can answer questions like "Has anything changed?" or "Is this form valid?"
/// </summary>
public class D_EditContext : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnFieldChanged_FiresWhenFieldChanges()
    {
        // ABOUT: EditContext.OnFieldChanged fires whenever any field in the form changes.
        // The event provides a FieldChangedEventArgs with a FieldIdentifier that tells
        // you exactly which field changed. This is how you can react to user input.

        // TODO: Replace "__" with the field name that changed
        // HINT: FieldIdentifier.FieldName gives the property name (e.g., "Username")

        var cut = Render<RegistrationForm>();

        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("testuser");

        var expected = "Username"; // SOLUTION: "Username"

        Assert.Contains($"Field Changed: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnFieldChanged_IdentifiesDifferentFields()
    {
        // ABOUT: Each field has its own FieldIdentifier. When you change the email field,
        // the FieldIdentifier.FieldName will be "Email", not "Username".
        // This lets you handle different fields differently in your event handler.

        // TODO: Replace "__" with the field name of the email input
        // HINT: The InputText binds to model.Email

        var cut = Render<RegistrationForm>();

        var emailInput = cut.Find("input[type='email']");
        emailInput.Change("test@example.com");

        var expected = "Email"; // SOLUTION: "Email"

        Assert.Contains($"Field Changed: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_TracksFormChanges()
    {
        // ABOUT: EditContext.IsModified() returns true if ANY field has been changed
        // from its initial value. This is useful for "unsaved changes" warnings
        // or enabling/disabling a Save button.

        // TODO: Replace false with the expected IsModified value after changing a field

        var cut = Render<RegistrationForm>();

        // Initially, form should not be modified
        Assert.Contains("Is Form Modified: False", cut.Markup);

        // Change a field
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("newuser");

        var expected = false;

        Assert.Contains($"Is Form Modified: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_TracksSpecificField()
    {
        // ABOUT: You can check if a specific field is modified using
        // EditContext.IsModified(fieldIdentifier). This lets you track individual
        // fields rather than the entire form.

        // TODO: Replace false with expected value after changing Username

        var cut = Render<RegistrationForm>();

        // Change username
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("changeduser");

        var expected = false;

        Assert.Contains($"Is Username Modified: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_OtherFieldsRemainUnmodified()
    {
        // ABOUT: When you change one field, only that field is marked as modified.
        // Other fields remain unmodified. This is per-field tracking.

        // TODO: After changing Email, is Username modified? Replace "__" with True/False

        var cut = Render<RegistrationForm>();

        // Change email only
        var emailInput = cut.Find("input[type='email']");
        emailInput.Change("test@example.com");

        var expected = "__";

        // Username should NOT be modified since we only changed email
        Assert.Contains($"Is Username Modified: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_MarkAsUnmodified_ResetsState()
    {
        // ABOUT: EditContext.MarkAsUnmodified() resets the modification tracking.
        // This is useful after saving data - you want to clear the "dirty" state
        // so the form appears unchanged again.

        // TODO: After clicking Reset, what is IsFormModified? Replace false with expected value

        var cut = Render<RegistrationForm>();

        // Make a change
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("modified");

        // Verify it's modified
        Assert.Contains("Is Form Modified: True", cut.Markup);

        // Click reset button
        var resetButton = cut.Find("button[type='button']:last-of-type");
        resetButton.Click();

        var expected = false;

        Assert.Contains($"Is Form Modified: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_Validate_TriggersValidation()
    {
        // ABOUT: EditContext.Validate() manually triggers validation for all fields.
        // It returns true if valid, false if there are any validation errors.
        // This is useful for validating before an action that's not a form submit.

        // TODO: With empty required fields, is the form valid? Replace true with expected

        var cut = Render<RegistrationForm>();

        // Click validate button (triggers editContext.Validate())
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        // Form has required fields that are empty
        var expected = true;

        Assert.Contains($"Is Form Valid: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_GetValidationMessages_ReturnsErrors()
    {
        // ABOUT: EditContext.GetValidationMessages() returns all validation errors.
        // You can also get messages for a specific field using GetValidationMessages(fieldIdentifier).
        // This gives you programmatic access to validation errors.

        // TODO: How many validation errors are there with empty required fields?
        // HINT: Count the [Required] attributes in RegistrationModel

        var cut = Render<RegistrationForm>();

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        var expected = 0;

        Assert.Contains($"Validation Message Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_GetValidationMessages_ForSpecificField()
    {
        // ABOUT: You can get validation messages for a specific field by passing
        // a FieldIdentifier to GetValidationMessages(). This is useful for
        // displaying field-specific errors.

        // TODO: What error message appears for an empty Username field?
        // HINT: Look at the [Required] attribute in RegistrationModel

        var cut = Render<RegistrationForm>();

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        var expected = "__";

        Assert.Contains($"Username Errors: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnValidationStateChanged_FiresOnValidation()
    {
        // ABOUT: EditContext.OnValidationStateChanged fires whenever validation
        // state changes. This happens after Validate() is called or when
        // field-level validation completes.

        // TODO: After clicking Validate, how many times has validation state changed?
        // Replace 0 with expected count

        var cut = Render<RegistrationForm>();

        // Initially 0
        Assert.Contains("Validation State Changed Count: 0", cut.Markup);

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        var expected = 0;

        Assert.Contains($"Validation State Changed Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_FieldIdentifier_Create()
    {
        // ABOUT: FieldIdentifier identifies a specific field in your model.
        // You can create one using editContext.Field(nameof(model.PropertyName)).
        // It combines the model instance and property name to uniquely identify a field.

        // TODO: What method on EditContext creates a FieldIdentifier?
        // Replace "__" with the method name

        var expected = "__";

        // The method is editContext.Field(propertyName)
        Assert.Equal("Field", expected);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_ValidFormSubmission()
    {
        // ABOUT: When a form is valid and submitted, OnValidSubmit is called.
        // The EditContext tracks that validation passed.

        // TODO: Fill in valid data and submit. What is the submit status?
        // HINT: Look at HandleValidSubmit in RegistrationForm

        var cut = Render<RegistrationForm>();

        // Fill in valid data
        cut.Find("input[name='model.Username']").Change("validuser");
        cut.Find("input[type='email']").Change("valid@email.com");
        cut.Find("input[type='password']").Change("validpassword123");

        // Submit the form
        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains($"Submit Status: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_InvalidFormSubmission()
    {
        // ABOUT: When a form has validation errors and is submitted, OnInvalidSubmit
        // is called instead of OnValidSubmit. This lets you handle invalid submissions
        // differently (e.g., show a message, focus the first error).

        // TODO: Submit with invalid data. What is the submit status?
        // HINT: Look at HandleInvalidSubmit in RegistrationForm

        var cut = Render<RegistrationForm>();

        // Submit without filling required fields
        cut.Find("form").Submit();

        var expected = "__";

        Assert.Contains($"Submit Status: {expected}", cut.Markup);
    }
}
