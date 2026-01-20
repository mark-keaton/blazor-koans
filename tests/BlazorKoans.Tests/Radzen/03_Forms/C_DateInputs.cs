using Bunit;
using BlazorKoans.App.Components.Exercises.Radzen;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// RadzenDatePicker provides date and time selection with:
/// - Calendar popup for visual date selection
/// - DateFormat for custom display formats
/// - Min/Max dates for valid ranges
/// - ShowTime for including time selection
/// - TimeOnly mode for selecting only time
/// - Inline mode to show calendar always visible
///
/// It binds to DateTime, DateOnly, TimeOnly, and their nullable versions,
/// providing a superior UX compared to native HTML date inputs.
/// </summary>
public class C_DateInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_BindsToDateTime()
    {
        // ABOUT: RadzenDatePicker<DateTime> creates a date picker bound to a DateTime property.
        // It shows a calendar popup when clicked.

        // TODO: Replace "__" with the initial BirthDate value format
        // HINT: Check the component's display output

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Birth Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_DateFormat()
    {
        // ABOUT: DateFormat property controls how the date is displayed in the input.
        // Common formats: "MM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd"

        // TODO: What DateFormat is used for BirthDate?
        // Replace "__" with the format string

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Date Format: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ShowTime_IncludesTime()
    {
        // ABOUT: ShowTime=true includes time selection in addition to the date.
        // The picker shows both calendar and time spinners.

        // TODO: Does the AppointmentTime picker show time selection?
        // Replace false with true or false

        var cut = Render<DateInputsDemo>();

        var expected = false;

        Assert.Contains($"Show Time: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_TimeOnlyMode()
    {
        // ABOUT: When binding to TimeOnly type (or using ShowTimeOkButton),
        // only the time portion is selected, not the date.

        // TODO: What initial time is shown for DailyReminder?
        // Replace "__" with the time format (e.g., "09:00")

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Daily Reminder: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Min_EnforcesMinimumDate()
    {
        // ABOUT: Min property sets the earliest selectable date.
        // Dates before this are disabled in the calendar.

        // TODO: What is the minimum date for StartDate?
        // Replace "__" with description like "today", "tomorrow", or specific date

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Min Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Max_EnforcesMaximumDate()
    {
        // ABOUT: Max property sets the latest selectable date.
        // Useful for preventing future dates or enforcing deadlines.

        // TODO: What is the maximum date for EndDate?
        // Replace "__" with description relative to some date

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Max Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_DateOnly_DotNet6Plus()
    {
        // ABOUT: .NET 6+ introduced DateOnly type for dates without time.
        // RadzenDatePicker<DateOnly> binds to this type.

        // TODO: What type is EventDate bound to?
        // Replace "__" with the C# type name

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Event Date Type: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_NullableDateTime()
    {
        // ABOUT: RadzenDatePicker<DateTime?> supports nullable dates.
        // An empty picker represents null, not DateTime.MinValue.

        // TODO: What is the initial value of OptionalDate?
        // Replace "__" with "null" or a date

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Optional Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ClearsToNull()
    {
        // ABOUT: When a nullable date picker is cleared, the value becomes null.
        // The component provides a clear button for this purpose.

        // TODO: After selecting then clearing OptionalDate, what is its value?
        // Replace "__" with expected value

        var cut = Render<DateInputsDemo>();

        var dateInput = cut.Find("input[name='OptionalDate']");
        dateInput.Change("2024-01-15");

        // Simulate clearing
        var clearButton = cut.Find("button.clear-date");
        clearButton.Click();

        var expected = "__";

        Assert.Contains($"Optional Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Placeholder()
    {
        // ABOUT: Placeholder appears when the date picker is empty,
        // guiding users on the expected format or purpose.

        // TODO: What is the placeholder for OptionalDate?
        // Replace "__" with the placeholder text

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        var dateInput = cut.Find("input[name='OptionalDate']");
        Assert.Equal(expected, dateInput.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Inline_AlwaysVisible()
    {
        // ABOUT: Inline=true displays the calendar permanently without a popup.
        // Useful for prominent date selection or date-centric UIs.

        // TODO: Is the CalendarView picker displayed inline?
        // Replace false with true or false

        var cut = Render<DateInputsDemo>();

        var expected = false;

        Assert.Contains($"Inline Calendar: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_MonthYearPicker()
    {
        // ABOUT: DatePicker can be configured to select only month/year
        // by setting appropriate view modes.

        // TODO: What view mode is used for ExpiryDate (month/year only)?
        // Replace "__" with the view mode

        var cut = Render<DateInputsDemo>();

        var expected = "__";

        Assert.Contains($"Expiry View: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_UpdatesOnSelection()
    {
        // ABOUT: When a date is selected from the calendar, the bound property
        // updates immediately and the calendar closes (unless Inline=true).

        // TODO: After selecting 2024-06-15, what date is displayed?
        // Replace "__" with the formatted date

        var cut = Render<DateInputsDemo>();

        var dateInput = cut.Find("input[name='BirthDate']");
        dateInput.Change("2024-06-15");

        var expected = "__";

        Assert.Contains($"Birth Date: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_FooterTemplate()
    {
        // ABOUT: FooterTemplate allows custom content at the bottom of the calendar,
        // such as "Today" and "Clear" buttons.

        // TODO: Does the BirthDate picker have a footer with action buttons?
        // Replace false with true or false

        var cut = Render<DateInputsDemo>();

        var expected = false;

        Assert.Contains($"Has Footer Template: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ReadOnly_DisplaysDate()
    {
        // ABOUT: ReadOnly=true displays the date but prevents editing.
        // The calendar popup is disabled.

        // TODO: Is the ConfirmedDate field read-only?
        // Replace false with true or false

        var cut = Render<DateInputsDemo>();

        var expected = false;

        var confirmedInput = cut.Find("input[name='ConfirmedDate']");
        var isReadOnly = confirmedInput.HasAttribute("readonly");
        Assert.Equal(expected, isReadOnly);
    }
}
