using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenNumeric is a specialized input for numeric values. It provides:
/// - Type-safe binding to numeric types (int, decimal, double, etc.)
/// - Min/Max constraints enforced in the browser
/// - Step increment for up/down arrows
/// - Format strings for display (currency, percentage, custom)
/// - ShowUpDown arrows for incrementing/decrementing
///
/// RadzenNumeric prevents non-numeric input and ensures valid values,
/// making it ideal for quantities, prices, percentages, and measurements.
/// </summary>
public class B_NumericInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_BindsToInt()
    {
        // ABOUT: RadzenNumeric<int> creates a numeric input bound to an integer property.
        // TValue specifies the numeric type (int, decimal, double, etc.).

        // TODO: Replace 0 with the initial Quantity value

        var cut = Render<NumericInputsDemo>();

        var expected = 0;

        var numericInput = cut.Find("input[name='Quantity']");
        Assert.Equal(expected.ToString(), numericInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_BindsToDecimal()
    {
        // ABOUT: RadzenNumeric<decimal> provides precise decimal arithmetic,
        // ideal for money and measurements requiring exact values.

        // TODO: Replace 0.00m with the initial Price value
        // HINT: Look for the decimal type binding in NumericInputsDemo

        var cut = Render<NumericInputsDemo>();

        var expected = 0.00m;

        Assert.Contains($"Price: {expected:C}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Min_EnforcesMinimum()
    {
        // ABOUT: The Min property sets the minimum allowed value.
        // The browser prevents entering values below this minimum.

        // TODO: What is the minimum Quantity allowed?
        // Replace 0 with the Min value

        var cut = Render<NumericInputsDemo>();

        var expected = 0;

        var numericInput = cut.Find("input[name='Quantity']");
        Assert.Equal(expected.ToString(), numericInput.GetAttribute("min"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Max_EnforcesMaximum()
    {
        // ABOUT: The Max property sets the maximum allowed value.
        // Useful for inventory limits, percentage caps, etc.

        // TODO: What is the maximum Quantity allowed?
        // Replace 0 with the Max value

        var cut = Render<NumericInputsDemo>();

        var expected = 0;

        var numericInput = cut.Find("input[name='Quantity']");
        Assert.Equal(expected.ToString(), numericInput.GetAttribute("max"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Step_IncrementsBy()
    {
        // ABOUT: The Step property determines how much the value changes
        // when using the up/down arrow buttons or keyboard arrows.

        // TODO: What is the step increment for Price?
        // Replace "0" with the step value

        var cut = Render<NumericInputsDemo>();

        var expected = "0";

        var priceInput = cut.Find("input[name='Price']");
        Assert.Equal(expected, priceInput.GetAttribute("step"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_Currency()
    {
        // ABOUT: Format="c" displays the value as currency using the current culture.
        // The format is applied for display, but the underlying value remains numeric.

        // TODO: After setting Price to 99.99, what is the formatted display?
        // Replace "__" with the expected currency format (e.g., "$99.99")

        var cut = Render<NumericInputsDemo>();

        var priceInput = cut.Find("input[name='Price']");
        priceInput.Change("99.99");

        var expected = "__";

        Assert.Contains($"Price: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_Percentage()
    {
        // ABOUT: Format="P" displays the value as a percentage.
        // Note: 0.15 displays as "15%", not "0.15%"

        // TODO: What format string is used for the Discount field?
        // Replace "__" with the format specifier

        var cut = Render<NumericInputsDemo>();

        var expected = "__";

        // The component should show format in some way
        Assert.Contains($"Discount Format: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_CustomDecimalPlaces()
    {
        // ABOUT: Format="N2" displays with 2 decimal places, "N4" with 4, etc.
        // "N" is the number format specifier.

        // TODO: How many decimal places are shown for Weight?
        // Replace 0 with the number of decimal places

        var cut = Render<NumericInputsDemo>();

        var expected = 0;

        Assert.Contains($"Weight Decimals: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ShowUpDown_Arrows()
    {
        // ABOUT: ShowUpDown=true displays up/down arrow buttons for incrementing
        // and decrementing the value by the Step amount.

        // TODO: Does the Quantity field show up/down arrows?
        // Replace false with true or false

        var cut = Render<NumericInputsDemo>();

        var expected = false;

        Assert.Contains($"Quantity ShowUpDown: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_UpdatesOnChange()
    {
        // ABOUT: When the user changes the value, the bound property updates
        // and the TValue type is preserved (int stays int, decimal stays decimal).

        // TODO: After changing Quantity to 50, what is the new value?
        // Replace 0 with expected value

        var cut = Render<NumericInputsDemo>();

        var quantityInput = cut.Find("input[name='Quantity']");
        quantityInput.Change("50");

        var expected = 0;

        Assert.Contains($"Quantity: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_NullableTypes()
    {
        // ABOUT: RadzenNumeric<int?> supports nullable numeric types.
        // An empty input represents null, not zero.

        // TODO: What is the initial value of OptionalCount (nullable int)?
        // Replace "__" with "null" or the actual number

        var cut = Render<NumericInputsDemo>();

        var expected = "__";

        Assert.Contains($"Optional Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ClearsToNull()
    {
        // ABOUT: When a RadzenNumeric<int?> field is cleared, the value becomes null.
        // This is different from non-nullable types which default to 0.

        // TODO: After clearing OptionalCount, what is its value?
        // Replace "__" with expected value

        var cut = Render<NumericInputsDemo>();

        var optionalInput = cut.Find("input[name='OptionalCount']");
        optionalInput.Change("100");
        optionalInput.Change("");

        var expected = "__";

        Assert.Contains($"Optional Count: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Placeholder()
    {
        // ABOUT: Placeholder text appears when the numeric input is empty.
        // Useful for nullable types to indicate expected input.

        // TODO: What is the placeholder for OptionalCount?
        // Replace "__" with the placeholder text

        var cut = Render<NumericInputsDemo>();

        var expected = "__";

        var optionalInput = cut.Find("input[name='OptionalCount']");
        Assert.Equal(expected, optionalInput.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_TValueType()
    {
        // ABOUT: The TValue generic parameter determines the bound property type.
        // Common types: int, long, decimal, double, float, and their nullable versions.

        // TODO: What TValue type is used for Price?
        // Replace "__" with the C# type name

        var cut = Render<NumericInputsDemo>();

        var expected = "__";

        Assert.Contains($"Price Type: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ReadOnly_DisplaysValue()
    {
        // ABOUT: ReadOnly=true displays the formatted value but prevents editing.
        // Useful for calculated fields or confirmed values.

        // TODO: Is the TotalAmount field read-only?
        // Replace false with true or false

        var cut = Render<NumericInputsDemo>();

        var expected = false;

        var totalInput = cut.Find("input[name='TotalAmount']");
        var isReadOnly = totalInput.HasAttribute("readonly");
        Assert.Equal(expected, isReadOnly);
    }
}
