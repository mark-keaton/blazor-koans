using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          RADZEN NUMERIC INPUTS                               ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenNumeric is a specialized input for numeric values with type-safe      ║
/// ║  binding, min/max constraints, step increments, and format strings.          ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenNumeric TValue="int" @bind-Value="model.Quantity"             │  ║
/// ║  │                 Min="0" Max="100" Step="1" /&gt;                          │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenNumeric TValue="decimal" @bind-Value="model.Price"            │  ║
/// ║  │                 Format="c" Step="0.01" ShowUpDown="true" /&gt;            │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_NumericInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_BindsToInt()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Binding to Integer Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenNumeric<int> creates a numeric input bound to an integer property.
        // TValue specifies the numeric type (int, decimal, double, etc.).
        //
        // EXERCISE: What is the initial Quantity value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the quantity input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var numericInput = cut.Find("input[name='Quantity']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial Quantity?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The input value matches the initial quantity
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer.ToString(), numericInput.GetAttribute("value"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_BindsToDecimal()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Binding to Decimal Values
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenNumeric<decimal> provides precise decimal arithmetic,
        // ideal for money and measurements requiring exact values.
        //
        // EXERCISE: What is the initial Price value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial Price?                      ║
        // ║                                                                    ║
        // ║  HINT: Look for the decimal type binding in NumericInputsDemo      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0.00m;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the initial price
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Price: {answer:C}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Min_EnforcesMinimum()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Minimum Value Constraint
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Min property sets the minimum allowed value.
        // The browser prevents entering values below this minimum.
        //
        // EXERCISE: What is the minimum Quantity allowed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the quantity input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var numericInput = cut.Find("input[name='Quantity']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the Min value?                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The min attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer.ToString(), numericInput.GetAttribute("min"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Max_EnforcesMaximum()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Maximum Value Constraint
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Max property sets the maximum allowed value.
        // Useful for inventory limits, percentage caps, etc.
        //
        // EXERCISE: What is the maximum Quantity allowed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the quantity input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var numericInput = cut.Find("input[name='Quantity']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the Max value?                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The max attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer.ToString(), numericInput.GetAttribute("max"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Step_IncrementsBy()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Step Increment
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Step property determines how much the value changes
        // when using the up/down arrow buttons or keyboard arrows.
        //
        // EXERCISE: What is the step increment for Price?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the price input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var priceInput = cut.Find("input[name='Price']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the step value?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "0";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The step attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, priceInput.GetAttribute("step"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_Currency()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Currency Formatting
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Format="c" displays the value as currency using the current culture.
        // The format is applied for display, but the underlying value is numeric.
        //
        // EXERCISE: After setting Price to 99.99, what is the formatted display?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and change the price
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var priceInput = cut.Find("input[name='Price']");
        priceInput.Change("99.99");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the formatted display? (e.g., "$99.99") ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the formatted price
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Price: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_Percentage()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Percentage Formatting
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Format="P" displays the value as a percentage.
        // Note: 0.15 displays as "15%", not "0.15%"
        //
        // EXERCISE: What format string is used for the Discount field?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the format specifier?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the format
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Discount Format: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Format_CustomDecimalPlaces()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Decimal Places
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Format="N2" displays with 2 decimal places, "N4" with 4, etc.
        // "N" is the number format specifier.
        //
        // EXERCISE: How many decimal places are shown for Weight?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many decimal places?                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the decimal count
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Weight Decimals: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ShowUpDown_Arrows()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Up/Down Arrow Buttons
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ShowUpDown=true displays up/down arrow buttons for incrementing
        // and decrementing the value by the Step amount.
        //
        // EXERCISE: Does the Quantity field show up/down arrows?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it show up/down arrows?                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms ShowUpDown setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Quantity ShowUpDown: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_UpdatesOnChange()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reactive Updates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When the user changes the value, the bound property updates
        // and the TValue type is preserved (int stays int, decimal stays decimal).
        //
        // EXERCISE: After changing Quantity to 50, what is the new value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and change the quantity
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var quantityInput = cut.Find("input[name='Quantity']");
        quantityInput.Change("50");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the new Quantity value?                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the updated quantity
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Quantity: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_NullableTypes()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nullable Numeric Types
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenNumeric<int?> supports nullable numeric types.
        // An empty input represents null, not zero.
        //
        // EXERCISE: What is the initial value of OptionalCount (nullable int)?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is OptionalCount's initial value?          ║
        // ║                                                                    ║
        // ║  HINT: Answer "null" or the actual number                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the initial value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Optional Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ClearsToNull()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Nullable Fields
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a RadzenNumeric<int?> field is cleared, the value becomes null.
        // This is different from non-nullable types which default to 0.
        //
        // EXERCISE: After clearing OptionalCount, what is its value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render, set value, then clear
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var optionalInput = cut.Find("input[name='OptionalCount']");
        optionalInput.Change("100");
        optionalInput.Change("");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the value after clearing?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the cleared value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Optional Count: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_Placeholder()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Placeholder for Empty Inputs
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Placeholder text appears when the numeric input is empty.
        // Useful for nullable types to indicate expected input.
        //
        // EXERCISE: What is the placeholder for OptionalCount?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the optional input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var optionalInput = cut.Find("input[name='OptionalCount']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the placeholder text?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The placeholder attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, optionalInput.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_TValueType()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: TValue Generic Parameter
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The TValue generic parameter determines the bound property type.
        // Common types: int, long, decimal, double, float, and nullable versions.
        //
        // EXERCISE: What TValue type is used for Price?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the C# type name?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the type name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Price Type: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenNumeric_ReadOnly_DisplaysValue()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ReadOnly Numeric Fields
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ReadOnly=true displays the formatted value but prevents editing.
        // Useful for calculated fields or confirmed values.
        //
        // EXERCISE: Is the TotalAmount field read-only?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the total input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<NumericInputsDemo>();
        var totalInput = cut.Find("input[name='TotalAmount']");
        var isReadOnly = totalInput.HasAttribute("readonly");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is TotalAmount read-only?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The read-only state matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isReadOnly);
    }
}
