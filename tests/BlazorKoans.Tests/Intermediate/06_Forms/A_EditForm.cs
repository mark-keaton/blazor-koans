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
        // ABOUT: EditForm uses the Model parameter to bind form data.
        // InputText binds to string properties and renders as <input name="model.Property">.
        // The "name" attribute follows the pattern "model.PropertyName".

        // TODO: Replace "__" with the default name value
        // HINT: Look at the Person class initialization

        var cut = Render<FormDemo>();

        var expected = "";

        // InputText renders as <input name="person.Name"> (not type="text")
        var nameInput = cut.Find("input[name='person.Name']");
        Assert.Equal(expected, nameInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void EditForm_UpdatesModelOnInput()
    {
        // ABOUT: Input components update the model when the user types.
        // The Change event triggers binding and updates the model property.

        // TODO: Replace "__" with the name that will be displayed after input
        // HINT: The input updates the person.Name property

        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("Alice");

        var expected = "__";

        Assert.Contains($"Name: {expected}", cut.Markup);
    }
}
