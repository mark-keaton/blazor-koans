using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

public class A_EditForm : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditForm_BindsToModel()
    {
        // ABOUT: EditForm uses the Model parameter to bind form data
        // The model object holds the form state

        // TODO: Replace "__" with the default name value
        // HINT: Look at the Person class initialization

        var cut = Render<FormDemo>();

        var expected = "__"; // SOLUTION: "" (empty string by default)

        var nameInput = cut.Find("input[type='text']");
        Assert.Equal(expected, nameInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditForm_UpdatesModelOnInput()
    {
        // ABOUT: Input components update the model when the user types

        // TODO: Replace "__" with the name that will be displayed after input
        // HINT: The input updates the person.Name property

        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[type='text']");
        nameInput.Change("Alice");

        var expected = "__"; // SOLUTION: "Alice"

        Assert.Contains($"Name: {expected}", cut.Markup);
    }
}
