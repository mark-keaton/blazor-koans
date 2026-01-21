using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._03_Forms;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                           RADZEN DATE INPUTS                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenDatePicker provides date and time selection with calendar popup,      ║
/// ║  custom formats, min/max constraints, and support for various date types.    ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDatePicker TValue="DateTime" @bind-Value="model.BirthDate"    │  ║
/// ║  │                    DateFormat="MM/dd/yyyy" /&gt;                          │  ║
/// ║  │                                                                        │  ║
/// ║  │  &lt;RadzenDatePicker TValue="DateTime?" @bind-Value="model.OptionalDate"│  ║
/// ║  │                    ShowTime="true" Min="@minDate" Max="@maxDate" /&gt;    │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class C_DateInputs : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_BindsToDateTime()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Binding to DateTime
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDatePicker<DateTime> creates a date picker bound to a DateTime.
        // It shows a calendar popup when clicked.
        //
        // EXERCISE: What is the initial BirthDate value format?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the initial date displayed?             ║
        // ║                                                                    ║
        // ║  HINT: Check the component's display output                        ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the initial date
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Birth Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_DateFormat()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Date Formats
        // ═══════════════════════════════════════════════════════════════════════
        //
        // DateFormat property controls how the date is displayed in the input.
        // Common formats: "MM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd"
        //
        // EXERCISE: What DateFormat is used for BirthDate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the date format string?                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the format
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Date Format: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ShowTime_IncludesTime()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Including Time Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ShowTime=true includes time selection in addition to the date.
        // The picker shows both calendar and time spinners.
        //
        // EXERCISE: Does the AppointmentTime picker show time selection?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it show time selection?                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms ShowTime setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Show Time: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_TimeOnlyMode()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Time-Only Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When binding to TimeOnly type (or using ShowTimeOkButton),
        // only the time portion is selected, not the date.
        //
        // EXERCISE: What initial time is shown for DailyReminder?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What time is displayed? (e.g., "09:00")         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the daily reminder time
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Daily Reminder: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Min_EnforcesMinimumDate()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Minimum Date Constraint
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Min property sets the earliest selectable date.
        // Dates before this are disabled in the calendar.
        //
        // EXERCISE: What is the minimum date for StartDate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the min date description?               ║
        // ║                                                                    ║
        // ║  HINT: Answer "today", "tomorrow", or a specific date              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the minimum date
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Min Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Max_EnforcesMaximumDate()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Maximum Date Constraint
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Max property sets the latest selectable date.
        // Useful for preventing future dates or enforcing deadlines.
        //
        // EXERCISE: What is the maximum date for EndDate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the max date description?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the maximum date
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Max Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_DateOnly_DotNet6Plus()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: DateOnly Type Support
        // ═══════════════════════════════════════════════════════════════════════
        //
        // .NET 6+ introduced DateOnly type for dates without time.
        // RadzenDatePicker<DateOnly> binds to this type.
        //
        // EXERCISE: What type is EventDate bound to?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the C# type name?                       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the type
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Event Date Type: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_NullableDateTime()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nullable DateTime Support
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenDatePicker<DateTime?> supports nullable dates.
        // An empty picker represents null, not DateTime.MinValue.
        //
        // EXERCISE: What is the initial value of OptionalDate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is OptionalDate's value?                   ║
        // ║                                                                    ║
        // ║  HINT: Answer "null" or a date                                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the initial value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Optional Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ClearsToNull()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Clearing Nullable Date Pickers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a nullable date picker is cleared, the value becomes null.
        // The component provides a clear button for this purpose.
        //
        // EXERCISE: After selecting then clearing OptionalDate, what is its value?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render, select a date, then clear
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();
        var dateInput = cut.Find("input[name='OptionalDate']");
        dateInput.Change("2024-01-15");
        var clearButton = cut.Find("button.clear-date");
        clearButton.Click();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the value after clearing?               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the cleared value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Optional Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Placeholder()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Placeholder for Empty Date Pickers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Placeholder appears when the date picker is empty,
        // guiding users on the expected format or purpose.
        //
        // EXERCISE: What is the placeholder for OptionalDate?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the date input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();
        var dateInput = cut.Find("input[name='OptionalDate']");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the placeholder text?                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The placeholder attribute matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, dateInput.GetAttribute("placeholder"));
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_Inline_AlwaysVisible()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Inline Calendar Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Inline=true displays the calendar permanently without a popup.
        // Useful for prominent date selection or date-centric UIs.
        //
        // EXERCISE: Is the CalendarView picker displayed inline?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is it displayed inline?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms inline setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Inline Calendar: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_MonthYearPicker()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Month/Year Only Selection
        // ═══════════════════════════════════════════════════════════════════════
        //
        // DatePicker can be configured to select only month/year
        // by setting appropriate view modes.
        //
        // EXERCISE: What view mode is used for ExpiryDate (month/year only)?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the view mode?                          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the view mode
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Expiry View: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_UpdatesOnSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reactive Date Updates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When a date is selected from the calendar, the bound property
        // updates immediately and the calendar closes (unless Inline=true).
        //
        // EXERCISE: After selecting 2024-06-15, what date is displayed?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and select a date
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();
        var dateInput = cut.Find("input[name='BirthDate']");
        dateInput.Change("2024-06-15");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the formatted date displayed?           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display shows the selected date
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Birth Date: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_FooterTemplate()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Footer with Templates
        // ═══════════════════════════════════════════════════════════════════════
        //
        // FooterTemplate allows custom content at the bottom of the calendar,
        // such as "Today" and "Clear" buttons.
        //
        // EXERCISE: Does the BirthDate picker have a footer with action buttons?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render the component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it have a footer template?                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The display confirms footer template setting
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Has Footer Template: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void RadzenDatePicker_ReadOnly_DisplaysDate()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ReadOnly Date Pickers
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ReadOnly=true displays the date but prevents editing.
        // The calendar popup is disabled.
        //
        // EXERCISE: Is the ConfirmedDate field read-only?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - render and find the confirmed date input
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<DateInputsDemo>();
        var confirmedInput = cut.Find("input[name='ConfirmedDate']");
        var isReadOnly = confirmedInput.HasAttribute("readonly");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is ConfirmedDate read-only?                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The read-only state matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isReadOnly);
    }
}
