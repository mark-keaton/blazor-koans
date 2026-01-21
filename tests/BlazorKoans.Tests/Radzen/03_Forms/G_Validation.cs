using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                        RADZEN FORM VALIDATION                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Radzen provides comprehensive validation components that integrate with     ║
/// ║  RadzenTemplateForm and EditContext:                                         ║
/// ║                                                                              ║
/// ║  Built-in Validators:                                                        ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  RadzenRequiredValidator      ← Ensures field has a value              │  ║
/// ║  │  RadzenEmailValidator         ← Validates email format                 │  ║
/// ║  │  RadzenNumericRangeValidator  ← Validates numeric ranges               │  ║
/// ║  │  RadzenLengthValidator        ← Validates string length                │  ║
/// ║  │  RadzenCompareValidator       ← Compares two fields                    │  ║
/// ║  │  RadzenRegexValidator         ← Custom regex patterns                  │  ║
/// ║  │  RadzenCustomValidator        ← Custom validation logic                │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  These validators work seamlessly with Radzen form components and            ║
/// ║  provide consistent error messaging and styling.                             ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class G_Validation : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_ValidatesEmptyField()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Required Field Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenRequiredValidator ensures a field has a value.
        // Component property links to the input's Name property.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTextBox Name="Username" @bind-Value="model.Username" />     │
        // │  <RadzenRequiredValidator Component="Username"                      │
        // │                           Text="Username is required" />            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What happens when submitting with an empty required field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and submitting empty form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_Component_LinksToField()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Linking Validators to Fields
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Component property on a validator must match the Name
        // property of the input it validates.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTextBox Name="Email" ... />                                 │
        // │  <RadzenRequiredValidator Component="Email" ... />                  │
        // │                           ↑ Must match ↑                            │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What Component value does the Username validator use?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Username Component: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRequiredValidator_Text_ShowsErrorMessage()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Error Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Text property defines the error message shown when validation fails.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenRequiredValidator Text="Please enter a username"            │
        // │                           Component="Username" />                   │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What error message appears for empty Username?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and submitting empty form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenEmailValidator_ValidatesEmailFormat()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Email Format Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenEmailValidator checks if input matches email format.
        // It validates pattern like "user@domain.com".
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTextBox Name="Email" @bind-Value="model.Email" />           │
        // │  <RadzenEmailValidator Component="Email"                            │
        // │                        Text="Invalid email format" />               │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is "invalid-email" a valid email format? (True/False for hasError)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering invalid email
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var emailInput = cut.Find("input[name='Email']");
        emailInput.Change("invalid-email");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Invalid email format");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenEmailValidator_AcceptsValidEmail()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Valid Email Passes Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When email format is correct, RadzenEmailValidator passes.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Valid emails:                                                      │
        // │  - user@example.com ✓                                               │
        // │  - name.last@domain.org ✓                                           │
        // │  - test+filter@mail.co.uk ✓                                         │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Is "user@example.com" valid? (True/False for hasError)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering valid email
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var emailInput = cut.Find("input[name='Email']");
        emailInput.Change("user@example.com");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Invalid email format");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_EnforcesMinimum()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Minimum Value Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenNumericRangeValidator validates that a number is within
        // a specified Min and Max range.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenNumeric Name="Age" @bind-Value="model.Age" />               │
        // │  <RadzenNumericRangeValidator Component="Age"                       │
        // │                               Min="18" Max="120" />                 │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the minimum age allowed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Min Age: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_EnforcesMaximum()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Maximum Value Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Values above Max trigger validation error.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenNumericRangeValidator Min="18" Max="120" ... />             │
        // │                                                                     │
        // │  Age = 150 → Error: "Value must be between 18 and 120"              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the maximum age allowed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Max Age: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumericRangeValidator_ShowsErrorOutOfRange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Out of Range Error Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When value is outside the range, validator shows error message.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenNumericRangeValidator Min="18" Max="120"                    │
        // │                               Text="Age must be 18-120" />          │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What error appears when Age is 10 (below minimum)?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering out-of-range value
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var ageInput = cut.Find("input[name='Age']");
        ageInput.Change("10");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenLengthValidator_EnforcesMinLength()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Minimum Length Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenLengthValidator ensures string length is within Min and Max.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenPassword Name="Password" @bind-Value="model.Password" />    │
        // │  <RadzenLengthValidator Component="Password"                        │
        // │                         Min="8" Max="50"                            │
        // │                         Text="Password must be 8-50 characters" />  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What is the minimum length for Password?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Min Password Length: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenLengthValidator_ShowsErrorTooShort()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Too Short Error Message
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When string is too short, validator displays error.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Min="8", Password="12345" (5 chars)                                │
        // │  → Error: "Password must be at least 8 characters"                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What error appears for password "12345" (below min length)?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering short password
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("12345");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCompareValidator_ComparesFields()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Field Comparison Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCompareValidator ensures two fields have the same value.
        // Common for password confirmation.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenPassword Name="Password" @bind-Value="model.Password" />    │
        // │  <RadzenPassword Name="ConfirmPassword" ... />                      │
        // │  <RadzenCompareValidator Component="ConfirmPassword"                │
        // │                          Value="@model.Password"                    │
        // │                          Text="Passwords do not match" />           │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: If passwords don't match, does validation pass? (True/False for hasError)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering mismatched passwords
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("password123");
        var confirmInput = cut.Find("input[name='ConfirmPassword']");
        confirmInput.Change("password456");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Passwords do not match");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCompareValidator_PassesWhenMatching()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Matching Fields Pass Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When both fields match, RadzenCompareValidator passes.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Password = "mySecret123"                                           │
        // │  ConfirmPassword = "mySecret123"                                    │
        // │  → Validation passes ✓                                              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: If both passwords are "password123", does error appear? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering matching passwords
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("password123");
        var confirmInput = cut.Find("input[name='ConfirmPassword']");
        confirmInput.Change("password123");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Passwords do not match");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRegexValidator_ValidatesPattern()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Regex Pattern Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenRegexValidator checks if input matches a regex pattern.
        // Useful for phone numbers, zip codes, custom formats.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTextBox Name="Phone" @bind-Value="model.Phone" />           │
        // │  <RadzenRegexValidator Component="Phone"                            │
        // │                        Pattern="^\d{3}-\d{3}-\d{4}$"                │
        // │                        Text="Invalid phone format" />               │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does "123-456-7890" match the phone pattern? (True/False for hasError)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering valid phone format
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var phoneInput = cut.Find("input[name='Phone']");
        phoneInput.Change("123-456-7890");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Invalid phone format");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenRegexValidator_ShowsErrorInvalidPattern()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Invalid Pattern Shows Error
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When input doesn't match pattern, error is shown.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  Pattern: ^\d{3}-\d{3}-\d{4}$                                        │
        // │  Input: "abcd"                                                      │
        // │  → Error: "Invalid phone format"                                    │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does "abcd" match the phone number pattern? (True/False for hasError)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering invalid phone format
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var phoneInput = cut.Find("input[name='Phone']");
        phoneInput.Change("abcd");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        var hasError = cut.Markup.Contains("Invalid phone format");
        Assert.Equal(answer, hasError.ToString());
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_IntegratesValidators()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Form Integration with Validators
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTemplateForm automatically manages validators.
        // It tracks validation state and triggers validation on submit.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTemplateForm TItem="MyModel" Data="@model">                 │
        // │      <RadzenTextBox Name="Field1" ... />                            │
        // │      <RadzenRequiredValidator Component="Field1" ... />             │
        // │      <!-- Validators are auto-triggered on submit -->               │
        // │  </RadzenTemplateForm>                                              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: How many validation errors exist with all fields empty?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and submitting empty form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Validation Errors: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_OnValidSubmit_FiresWhenValid()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnValidSubmit Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnValidSubmit fires only when all validators pass.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTemplateForm OnValidSubmit="@HandleValidSubmit" ... >       │
        // │      ...                                                            │
        // │  </RadzenTemplateForm>                                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void HandleValidSubmit() { submitStatus = "Success"; }         │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After filling all fields correctly, what status appears?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and filling all fields correctly
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        cut.Find("input[name='Username']").Change("john_doe");
        cut.Find("input[name='Email']").Change("john@example.com");
        cut.Find("input[name='Age']").Change("25");
        cut.Find("input[name='Password']").Change("password123");
        cut.Find("input[name='ConfirmPassword']").Change("password123");
        cut.Find("input[name='Phone']").Change("123-456-7890");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Submit Status: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTemplateForm_OnInvalidSubmit_FiresWhenInvalid()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: OnInvalidSubmit Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // OnInvalidSubmit fires when validation fails.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTemplateForm OnInvalidSubmit="@HandleInvalidSubmit" ... >   │
        // │      ...                                                            │
        // │  </RadzenTemplateForm>                                              │
        // │                                                                     │
        // │  @code {                                                            │
        // │      void HandleInvalidSubmit() { submitStatus = "Failed"; }        │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: After submitting with invalid data, what status appears?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and submitting empty form
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Submit Status: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenValidationSummary_DisplaysAllErrors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Validation Summary Component
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenValidationSummary shows all validation errors in one place.
        // Useful for displaying errors at the top of the form.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenTemplateForm ...>                                           │
        // │      <RadzenValidationSummary />  ← Shows all errors here           │
        // │      ...fields...                                                   │
        // │  </RadzenTemplateForm>                                              │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does the form have a validation summary component? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Has Validation Summary: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCustomValidator_CustomLogic()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Validation Logic
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCustomValidator allows custom validation logic via Validator property.
        // You provide a function that returns true if valid, false if invalid.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCustomValidator Component="Username"                        │
        // │                         Validator="@ValidateUsername"               │
        // │                         Text="Username 'admin' is not allowed" />   │
        // │                                                                     │
        // │  @code {                                                            │
        // │      bool ValidateUsername(object value) {                          │
        // │          return value?.ToString() != "admin";                       │
        // │      }                                                              │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: Does the Username have a custom validator checking for "admin"? (True/False)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering the RadzenValidationDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Has Custom Validator: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenCustomValidator_ShowsCustomError()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Validation Error Messages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenCustomValidator displays custom error messages.
        //
        // Example:
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  <RadzenCustomValidator Text="Username 'admin' is reserved"         │
        // │                         Validator="@(v => v?.ToString() != "admin")" │
        // │                         Component="Username" />                      │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // HINT: What error appears when Username is "admin"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering and entering "admin"
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<RadzenValidationDemo>();
        var usernameInput = cut.Find("input[name='Username']");
        usernameInput.Change("admin");
        cut.Find("form").Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Replace the "__" with the correct value         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The test checks your answer against the component output
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }
}
