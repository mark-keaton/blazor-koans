using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._06_Forms;

public class B_InputComponents : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputText_BindsStringProperty()
    {
        // ABOUT: InputText binds to string properties
        // It renders as an HTML <input type="text"> element

        // TODO: Replace "__" with the name after changing the input
        // HINT: InputText uses @bind-Value for two-way binding

        var cut = Render<FormDemo>();

        var nameInput = cut.Find("input.valid");
        nameInput.Change("Bob");

        var expected = "Bob"; // SOLUTION: "Bob"

        Assert.Contains($"Name: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputNumber_BindsNumericProperty()
    {
        // ABOUT: InputNumber binds to numeric properties (int, decimal, etc.)
        // It renders as an HTML <input type="number"> element

        // TODO: Replace "__" with the expected input type attribute
        // HINT: InputNumber generates a specific input type

        var cut = Render<FormDemo>();

        var expected = "number"; // SOLUTION: "number"

        var ageInput = cut.Find("input[type='number']");
        Assert.Equal(expected, ageInput.GetAttribute("type"));
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void InputDate_BindsDateTimeProperty()
    {
        // ABOUT: InputDate binds to DateTime properties
        // It renders as an HTML <input type="date"> element

        // TODO: Replace "__" with the expected input type for dates
        // HINT: Look at how InputDate renders in HTML

        var cut = Render<RegistrationForm>();

        var expected = "date"; // SOLUTION: "date"

        var dateInput = cut.Find("input[type='date']");
        Assert.Equal(expected, dateInput.GetAttribute("type"));
    }
}
