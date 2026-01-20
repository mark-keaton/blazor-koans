using Bunit;
using BlazorKoans.App.Components.Exercises.Radzen;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenTextBox, RadzenTextArea, and RadzenPassword are the foundational text input
/// components in Radzen. They provide:
/// - Two-way data binding with @bind-Value
/// - Placeholder text for empty fields
/// - MaxLength property for limiting input
/// - Disabled and ReadOnly states
/// - Built-in styling and theming
///
/// These replace standard HTML input elements with Radzen-styled alternatives
/// that integrate seamlessly with RadzenTemplateForm and validation.
/// </summary>
public class A_TextInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_BindsToProperty()
    {
        // ABOUT: RadzenTextBox uses @bind-Value to create two-way binding.
        // When you type in the input, the bound property updates automatically.
        // When the property changes, the input displays the new value.

        // TODO: Replace "__" with the initial value displayed in the textbox
        // HINT: Look at the Name property initialization in TextInputsDemo

        var cut = Render<TextInputsDemo>();

        var expected = "__";

        var textBox = cut.Find("input[name='Name']");
        Assert.Equal(expected, textBox.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_UpdatesOnChange()
    {
        // ABOUT: When you change the value in a RadzenTextBox, the bound property
        // updates immediately. This enables reactive UI updates.

        // TODO: After changing the input to "Jane Doe", what text appears in the display?
        // Replace "__" with the expected output

        var cut = Render<TextInputsDemo>();

        var textBox = cut.Find("input[name='Name']");
        textBox.Change("Jane Doe");

        var expected = "__";

        Assert.Contains($"Name: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Placeholder_ShowsWhenEmpty()
    {
        // ABOUT: The Placeholder property displays hint text when the input is empty.
        // It disappears when the user starts typing.

        // TODO: What is the placeholder text for the Name field?
        // Replace "__" with the exact placeholder text

        var cut = Render<TextInputsDemo>();

        var expected = "__";

        var textBox = cut.Find("input[name='Name']");
        Assert.Equal(expected, textBox.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_MaxLength_LimitsInput()
    {
        // ABOUT: MaxLength property restricts how many characters can be entered.
        // This is enforced at the browser level.

        // TODO: What is the maximum length allowed for the Name field?
        // Replace 0 with the correct number

        var cut = Render<TextInputsDemo>();

        var expected = 0;

        var textBox = cut.Find("input[name='Name']");
        Assert.Equal(expected.ToString(), textBox.GetAttribute("maxlength"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_BindsMultilineText()
    {
        // ABOUT: RadzenTextArea is for multi-line text input. It renders as a <textarea>
        // element and supports the same binding as RadzenTextBox.

        // TODO: Replace "__" with the initial description value

        var cut = Render<TextInputsDemo>();

        var expected = "__";

        var textArea = cut.Find("textarea[name='Description']");
        Assert.Contains(expected, textArea.TextContent);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_Rows_SetsHeight()
    {
        // ABOUT: The Rows property determines the visible height of the textarea
        // in number of text lines.

        // TODO: How many rows is the Description textarea configured for?
        // Replace 0 with the correct number

        var cut = Render<TextInputsDemo>();

        var expected = 0;

        var textArea = cut.Find("textarea[name='Description']");
        Assert.Equal(expected.ToString(), textArea.GetAttribute("rows"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextArea_UpdatesOnChange()
    {
        // ABOUT: Like RadzenTextBox, RadzenTextArea updates the bound property
        // when the user changes the text.

        // TODO: After changing the description, what text appears in the display?
        // Replace "__" with expected output

        var cut = Render<TextInputsDemo>();

        var textArea = cut.Find("textarea[name='Description']");
        textArea.Change("This is a detailed description of the product.");

        var expected = "__";

        Assert.Contains($"Description: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenPassword_MasksInput()
    {
        // ABOUT: RadzenPassword renders as an <input type="password"> that
        // masks the entered characters for security.

        // TODO: What input type does RadzenPassword use?
        // Replace "__" with the HTML input type

        var cut = Render<TextInputsDemo>();

        var expected = "__";

        var passwordInput = cut.Find("input[name='Password']");
        Assert.Equal(expected, passwordInput.GetAttribute("type"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenPassword_BindsToProperty()
    {
        // ABOUT: RadzenPassword works exactly like RadzenTextBox for binding,
        // but the value is visually masked in the browser.

        // TODO: After setting the password, what appears in the display?
        // HINT: The component shows the password length, not the actual password

        var cut = Render<TextInputsDemo>();

        var passwordInput = cut.Find("input[name='Password']");
        passwordInput.Change("SecretPassword123!");

        var expected = 0;

        Assert.Contains($"Password Length: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Disabled_PreventsInput()
    {
        // ABOUT: Setting Disabled=true prevents the user from interacting with
        // the input. It's typically used for read-only data or when conditions
        // aren't met (e.g., form is saving).

        // TODO: Is the Email field disabled by default?
        // Replace false with true or false

        var cut = Render<TextInputsDemo>();

        var expected = false;

        var emailInput = cut.Find("input[name='Email']");
        var isDisabled = emailInput.HasAttribute("disabled");
        Assert.Equal(expected, isDisabled);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_ReadOnly_DisplaysButNoEdit()
    {
        // ABOUT: ReadOnly=true displays the value but prevents editing.
        // Unlike Disabled, ReadOnly fields are still submitted with forms
        // and can be focused.

        // TODO: Is the ReadOnlyField field read-only?
        // Replace false with true or false

        var cut = Render<TextInputsDemo>();

        var expected = false;

        var readOnlyInput = cut.Find("input[name='ReadOnlyField']");
        var isReadOnly = readOnlyInput.HasAttribute("readonly");
        Assert.Equal(expected, isReadOnly);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_Name_Property()
    {
        // ABOUT: The Name property is crucial for form validation. It identifies
        // the field to validators and is used in validation messages.

        // TODO: What is the Name property value for the Name textbox?
        // Replace "__" with the exact name

        var cut = Render<TextInputsDemo>();

        var expected = "__";

        var textBox = cut.Find("input[name='Name']");
        Assert.Equal(expected, textBox.GetAttribute("name"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenTextBox_ClearButton()
    {
        // ABOUT: Some Radzen inputs can show a clear button that removes the value.
        // This is controlled by the ShowClearButton property (not available on all input types).

        // TODO: After entering text and clicking clear, what should the Name value be?
        // Replace "__" with expected value after clearing

        var cut = Render<TextInputsDemo>();

        var textBox = cut.Find("input[name='Name']");
        textBox.Change("Test Name");

        // Note: In a real scenario, you'd click the clear button
        // For this koan, the component resets on a button click
        var clearButton = cut.Find("button.clear-name");
        clearButton.Click();

        var expected = "__";

        Assert.Contains($"Name: {expected}", cut.Markup);
    }
}
