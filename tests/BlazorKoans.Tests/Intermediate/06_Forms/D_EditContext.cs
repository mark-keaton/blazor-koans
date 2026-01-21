using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                              EDIT CONTEXT                                    ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  EditContext is the backbone of Blazor form handling. It tracks:             ║
/// ║  • Which fields have been modified                                           ║
/// ║  • Validation state for each field and the entire form                       ║
/// ║  • Events when fields change or validation state changes                     ║
/// ║                                                                              ║
/// ║  Think of EditContext as a "form supervisor" that watches everything         ║
/// ║  happening in your form and can answer questions like:                       ║
/// ║  "Has anything changed?" or "Is this form valid?"                            ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  <EditForm Model="@model" OnValidSubmit="HandleSubmit">                │  ║
/// ║  │      @* EditContext is created automatically from Model *@             │  ║
/// ║  │      <InputText @bind-Value="model.Username" />                        │  ║
/// ║  │  </EditForm>                                                           │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Access EditContext for advanced scenarios:                         │  ║
/// ║  │  editContext.OnFieldChanged += HandleFieldChanged;                     │  ║
/// ║  │  editContext.IsModified();  // Has any field changed?                  │  ║
/// ║  │  editContext.Validate();    // Trigger validation manually             │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_EditContext : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnFieldChanged_FiresWhenFieldChanges()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnFieldChanged Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.OnFieldChanged fires whenever any field in the form changes.
        // The event provides FieldChangedEventArgs with a FieldIdentifier that
        // tells you exactly which field changed.
        //
        // EXERCISE: What field name appears when you change the Username input?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering form and changing the username input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("testuser");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What field name was changed?                    ║
        // ║                                                                    ║
        // ║  HINT: FieldIdentifier.FieldName gives the property name           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The field name should appear in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Field Changed: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnFieldChanged_IdentifiesDifferentFields()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: FieldIdentifier Distinguishes Fields
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Each field has its own FieldIdentifier. When you change the email field,
        // the FieldIdentifier.FieldName will be "Email", not "Username".
        // This lets you handle different fields differently in your event handler.
        //
        // EXERCISE: What is the FieldName when the email input changes?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering form and changing the email input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        var emailInput = cut.Find("input[type='email']");
        emailInput.Change("test@example.com");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What field name was changed?                    ║
        // ║                                                                    ║
        // ║  HINT: The InputText binds to model.Email                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The field name should appear in the markup
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Field Changed: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_TracksFormChanges()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: IsModified() Tracks Form Changes
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.IsModified() returns true if ANY field has been changed
        // from its initial value. This is useful for "unsaved changes" warnings
        // or enabling/disabling a Save button.
        //
        // EXERCISE: What is IsModified() after changing a field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - verify initial state then change a field
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Initially, form should not be modified
        Assert.Contains("Is Form Modified: False", cut.Markup);

        // Change a field
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("newuser");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the form modified after changing a field?    ║
        // ║                                                                    ║
        // ║  HINT: Replace false with the expected boolean value              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if form modification status is correct
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Is Form Modified: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_TracksSpecificField()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: IsModified for Specific Fields
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can check if a specific field is modified using
        // EditContext.IsModified(fieldIdentifier). This lets you track individual
        // fields rather than the entire form.
        //
        // EXERCISE: Is the Username field modified after changing it?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and change username field
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Change username
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("changeduser");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is Username modified after changing it?         ║
        // ║                                                                    ║
        // ║  HINT: Replace false with the expected boolean value              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if username field modification status is correct
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Is Username Modified: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_IsModified_OtherFieldsRemainUnmodified()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Per-Field Modification Tracking
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you change one field, only that field is marked as modified.
        // Other fields remain unmodified. This is per-field tracking.
        //
        // EXERCISE: After changing Email, is the Username field modified?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and change email field only
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Change email only
        var emailInput = cut.Find("input[type='email']");
        emailInput.Change("test@example.com");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is Username modified after changing Email?      ║
        // ║                                                                    ║
        // ║  HINT: Replace "__" with True or False                            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Username should NOT be modified since we only changed email
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Is Username Modified: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_MarkAsUnmodified_ResetsState()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: MarkAsUnmodified() Resets Tracking
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.MarkAsUnmodified() resets the modification tracking.
        // This is useful after saving data - you want to clear the "dirty" state
        // so the form appears unchanged again.
        //
        // EXERCISE: What is IsModified after clicking the Reset button?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - modify form, verify it's modified, then reset
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Make a change
        var usernameInput = cut.Find("input[name='model.Username']");
        usernameInput.Change("modified");

        // Verify it's modified
        Assert.Contains("Is Form Modified: True", cut.Markup);

        // Click reset button
        var resetButton = cut.Find("button[type='button']:last-of-type");
        resetButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is form modified after reset?                   ║
        // ║                                                                    ║
        // ║  HINT: Replace false with the expected boolean value              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check form modification status after reset
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Is Form Modified: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_Validate_TriggersValidation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Manual Validation with Validate()
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.Validate() manually triggers validation for all fields.
        // It returns true if valid, false if there are any validation errors.
        // This is useful for validating before an action that's not a form submit.
        //
        // EXERCISE: With empty required fields, is the form valid?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and trigger validation
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Click validate button (triggers editContext.Validate())
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the form valid with empty required fields?   ║
        // ║                                                                    ║
        // ║  HINT: Replace true with the expected boolean value               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = true;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check form validation status
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Is Form Valid: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_GetValidationMessages_ReturnsErrors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: GetValidationMessages() Returns Errors
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.GetValidationMessages() returns all validation errors.
        // You can also get messages for a specific field using GetValidationMessages(fieldIdentifier).
        // This gives you programmatic access to validation errors.
        //
        // EXERCISE: How many validation errors are there with empty required fields?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and trigger validation
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many validation errors?                     ║
        // ║                                                                    ║
        // ║  HINT: Count the [Required] attributes in RegistrationModel       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the validation message count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Validation Message Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_GetValidationMessages_ForSpecificField()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Field-Specific Validation Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can get validation messages for a specific field by passing
        // a FieldIdentifier to GetValidationMessages(). This is useful for
        // displaying field-specific errors.
        //
        // EXERCISE: What error message appears for an empty Username field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and trigger validation
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What error message for empty Username?          ║
        // ║                                                                    ║
        // ║  HINT: Look at the [Required] attribute in RegistrationModel      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the username error message
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Username Errors: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_OnValidationStateChanged_FiresOnValidation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnValidationStateChanged Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // EditContext.OnValidationStateChanged fires whenever validation
        // state changes. This happens after Validate() is called or when
        // field-level validation completes.
        //
        // EXERCISE: How many times has validation state changed after clicking Validate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form, verify initial state, trigger validation
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Initially 0
        Assert.Contains("Validation State Changed Count: 0", cut.Markup);

        // Trigger validation
        var validateButton = cut.FindAll("button[type='button']")[0];
        validateButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many times has validation state changed?    ║
        // ║                                                                    ║
        // ║  HINT: Replace 0 with the expected count                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the validation state changed count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Validation State Changed Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_FieldIdentifier_Create()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Creating FieldIdentifiers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // FieldIdentifier identifies a specific field in your model.
        // You can create one using editContext.Field(nameof(model.PropertyName)).
        // It combines the model instance and property name to uniquely identify a field.
        //
        // EXERCISE: What method on EditContext creates a FieldIdentifier?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What method creates a FieldIdentifier?          ║
        // ║                                                                    ║
        // ║  HINT: The method is editContext.???(propertyName)                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The method name should be "Field"
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Field", answer);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_ValidFormSubmission()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Valid Form Submission
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a form is valid and submitted, OnValidSubmit is called.
        // The EditContext tracks that validation passed.
        //
        // EXERCISE: What is the submit status after submitting valid data?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form, fill valid data, and submit
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Fill in valid data
        cut.Find("input[name='model.Username']").Change("validuser");
        cut.Find("input[type='email']").Change("valid@email.com");
        cut.Find("input[type='password']").Change("validpassword123");

        // Submit the form
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the submit status?                      ║
        // ║                                                                    ║
        // ║  HINT: Look at HandleValidSubmit in RegistrationForm              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the submit status
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Submit Status: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditContext_InvalidFormSubmission()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Invalid Form Submission
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a form has validation errors and is submitted, OnInvalidSubmit
        // is called instead of OnValidSubmit. This lets you handle invalid submissions
        // differently (e.g., show a message, focus the first error).
        //
        // EXERCISE: What is the submit status when submitting with invalid data?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render form and submit without filling required fields
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RegistrationForm>();

        // Submit without filling required fields
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the submit status?                      ║
        // ║                                                                    ║
        // ║  HINT: Look at HandleInvalidSubmit in RegistrationForm            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check the submit status
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Submit Status: {answer}", cut.Markup);
    }
}
