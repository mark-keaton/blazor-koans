using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                           RADZEN TEXT INPUTS                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenTextBox, RadzenTextArea, and RadzenPassword are foundational text     ║
/// ║  input components with two-way binding, placeholders, and validation.        ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenTextBox @bind-Value="model.Name"                              │  ║
/// ║  │                  Placeholder="Enter name"                              │  ║
/// ║  │                  MaxLength="100" /&gt;                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenTextArea @bind-Value="model.Description" Rows="4" /&gt;          │  ║
/// ║  │  &lt;RadzenPassword @bind-Value="model.Password" /&gt;                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_TextInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_BindsToProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Two-Way Binding with RadzenTextBox
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTextBox uses @bind-Value to create two-way binding.
        // When you type in the input, the bound property updates automatically.
        // When the property changes, the input displays the new value.
        //
        // EXERCISE: What is the initial value displayed in the textbox?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the TextInputsDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial Name value?                 ║
        // ║                                                                    ║
        // ║  HINT: Look at the Name property initialization in TextInputsDemo  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The textbox value matches the bound property
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, textBox.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_UpdatesOnChange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reactive Updates on Input Change
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you change the value in a RadzenTextBox, the bound property
        // updates immediately. This enables reactive UI updates.
        //
        // EXERCISE: After changing the input to "Jane Doe", what text appears?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and change the textbox value
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");
        textBox.Change("Jane Doe");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the display?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the updated name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Name: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Placeholder_ShowsWhenEmpty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Placeholder Text for Empty Inputs
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Placeholder property displays hint text when the input is empty.
        // It disappears when the user starts typing.
        //
        // EXERCISE: What is the placeholder text for the Name field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the textbox
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the placeholder text?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The placeholder attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, textBox.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_MaxLength_LimitsInput()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Limiting Input with MaxLength
        // ═══════════════════════════════════════════════════════════════════════
        //
        // MaxLength property restricts how many characters can be entered.
        // This is enforced at the browser level.
        //
        // EXERCISE: What is the maximum length allowed for the Name field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the textbox
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the maximum character count?            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The maxlength attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer.ToString(), textBox.GetAttribute("maxlength"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_BindsMultilineText()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Multi-line Text with RadzenTextArea
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenTextArea is for multi-line text input. It renders as a <textarea>
        // element and supports the same binding as RadzenTextBox.
        //
        // EXERCISE: What is the initial description value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the textarea
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textArea = cut.Find("textarea[name='Description']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial description?                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The textarea contains the initial value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, textArea.TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_Rows_SetsHeight()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Setting TextArea Height with Rows
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Rows property determines the visible height of the textarea
        // in number of text lines.
        //
        // EXERCISE: How many rows is the Description textarea configured for?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the textarea
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textArea = cut.Find("textarea[name='Description']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows are configured?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The rows attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer.ToString(), textArea.GetAttribute("rows"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_UpdatesOnChange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TextArea Reactive Updates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Like RadzenTextBox, RadzenTextArea updates the bound property
        // when the user changes the text.
        //
        // EXERCISE: After changing the description, what text appears?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and change the textarea value
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textArea = cut.Find("textarea[name='Description']");
        textArea.Change("This is a detailed description of the product.");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text appears in the display?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the updated description
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Description: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenPassword_MasksInput()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Secure Password Input
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenPassword renders as an <input type="password"> that
        // masks the entered characters for security.
        //
        // EXERCISE: What input type does RadzenPassword use?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the password input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var passwordInput = cut.Find("input[name='Password']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the HTML input type?                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The input type is correct
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, passwordInput.GetAttribute("type"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenPassword_BindsToProperty()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Password Binding Behavior
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenPassword works exactly like RadzenTextBox for binding,
        // but the value is visually masked in the browser.
        //
        // EXERCISE: After setting the password, what appears in the display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and enter a password
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("SecretPassword123!");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What password length is displayed?              ║
        // ║                                                                    ║
        // ║  HINT: The component shows the password length, not the password   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the password length
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Password Length: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Disabled_PreventsInput()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Disabled State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Setting Disabled=true prevents the user from interacting with
        // the input. It's typically used for read-only data or when conditions
        // aren't met (e.g., form is saving).
        //
        // EXERCISE: Is the Email field disabled by default?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the email input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var emailInput = cut.Find("input[name='Email']");
        var isDisabled = emailInput.HasAttribute("disabled");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the Email field disabled?                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The disabled state matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isDisabled);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_ReadOnly_DisplaysButNoEdit()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ReadOnly vs Disabled
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ReadOnly=true displays the value but prevents editing.
        // Unlike Disabled, ReadOnly fields are still submitted with forms
        // and can be focused.
        //
        // EXERCISE: Is the ReadOnlyField field read-only?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the read-only input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var readOnlyInput = cut.Find("input[name='ReadOnlyField']");
        var isReadOnly = readOnlyInput.HasAttribute("readonly");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the field read-only?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The read-only state matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isReadOnly);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Name_Property()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The Name Property for Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Name property is crucial for form validation. It identifies
        // the field to validators and is used in validation messages.
        //
        // EXERCISE: What is the Name property value for the Name textbox?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the textbox
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the name attribute value?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The name attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, textBox.GetAttribute("name"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_ClearButton()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Input Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Some Radzen inputs can show a clear button that removes the value.
        // This is controlled by the ShowClearButton property.
        //
        // EXERCISE: After entering text and clicking clear, what is the value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render, enter text, and click clear
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<TextInputsDemo>();
        var textBox = cut.Find("input[name='Name']");
        textBox.Change("Test Name");
        var clearButton = cut.Find("button.clear-name");
        clearButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the value after clearing?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the cleared value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Name: {answer}", cut.Markup);
    }
}
