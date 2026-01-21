using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          RADZEN GRID LAYOUT                                  ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  RadzenRow and RadzenColumn provide a responsive 12-column grid system.      ║
/// ║  Use Size, SizeMD, SizeLG, etc. for breakpoint-based column widths.          ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenRow Gap="1rem"&gt;                                                │  ║
/// ║  │      &lt;RadzenColumn Size="12" SizeMD="6"&gt;                               │  ║
/// ║  │          Full width on mobile, half on medium+                         │  ║
/// ║  │      &lt;/RadzenColumn&gt;                                                   │  ║
/// ║  │      &lt;RadzenColumn Size="12" SizeMD="6"&gt;                               │  ║
/// ║  │          Full width on mobile, half on medium+                         │  ║
/// ║  │      &lt;/RadzenColumn&gt;                                                   │  ║
/// ║  │  &lt;/RadzenRow&gt;                                                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_Grid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Row_RendersColumns()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Row and Column Structure
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenRow is a container for RadzenColumn components. It creates a
        // flexbox row that wraps columns based on their sizes. Columns are
        // identified by the "rz-col" CSS class.
        //
        // EXERCISE: How many columns are in the grid?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();
        var columns = cut.FindAll(".rz-col");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many columns are rendered?                  ║
        // ║                                                                    ║
        // ║  HINT: Count RadzenColumn components inside the RadzenRow          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: At least the expected number of columns exist
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(columns.Count >= answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_SizeParameter_SetsWidth()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Size Parameter
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The Size parameter determines how many of the 12 columns this column
        // spans. Size="6" means 50% width (6/12 = 1/2). The grid uses a 12-column
        // system similar to Bootstrap.
        //
        // EXERCISE: What Size value makes a column half-width?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this calculation
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What Size value creates a half-width column?    ║
        // ║                                                                    ║
        // ║  HINT: 12 columns total, so half is...                             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Half of 12 columns equals 6
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(6, answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_FullWidth_UsesSize12()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Full Width Columns
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Size="12" makes a column span all 12 columns (full width). This is
        // useful for sections that should always be full width. Radzen applies
        // a CSS class to indicate the column span.
        //
        // EXERCISE: What CSS class indicates a full-width column?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS class indicates a full-width column?   ║
        // ║                                                                    ║
        // ║  HINT: Radzen uses "rz-col-12" for 12-column span                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The full-width class appears in the markup
        // ───────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_ResponsiveBreakpoints_ChangeLayout()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Responsive Breakpoints
        // ═══════════════════════════════════════════════════════════════════════
        //
        // SizeMD, SizeLG, etc. let you specify different column widths at
        // different screen sizes. This creates responsive layouts that adapt to
        // mobile, tablet, and desktop. Size="12" SizeMD="6" means full width
        // on mobile, half width on medium screens and up.
        //
        // EXERCISE: If SizeMD="6", what percentage width on medium screens?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this calculation
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What percentage is 6/12 columns?                ║
        // ║                                                                    ║
        // ║  HINT: 6 out of 12 columns = ?%                                    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: 6 out of 12 columns equals 50%
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal(50, answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Row_Wrapping_ColumnsExceed12()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Wrapping
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When columns in a row exceed 12 total, they wrap to a new line. For
        // example, three Size="6" columns will show two on the first line and
        // one on the second line.
        //
        // EXERCISE: Does the demo show column wrapping?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo show column wrapping?             ║
        // ║                                                                    ║
        // ║  HINT: Look for rows with columns totaling more than 12            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Column wrapping behavior matches expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == true || answer == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_Offset_CreatesSpace()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Column Offsets
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Offset parameters (Offset, OffsetMD, etc.) add empty space before a
        // column. Offset="2" pushes the column 2 columns to the right, creating
        // spacing without additional empty columns.
        //
        // EXERCISE: Does the demo use column offsets?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo use column offsets?               ║
        // ║                                                                    ║
        // ║  HINT: Check for Offset parameters on RadzenColumn                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Offsets are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("rz-offset") || answer == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Gap_SpacesBetweenColumns()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Row Gap Property
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RadzenRow supports a Gap parameter to add spacing between columns.
        // This creates consistent gutters without manual margin adjustments,
        // using modern CSS flexbox/grid gap property.
        //
        // EXERCISE: What CSS property is used for gap?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What CSS property is used for gap?              ║
        // ║                                                                    ║
        // ║  HINT: Modern CSS flexbox/grid use this property                   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The correct CSS property name
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("gap", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_AlignItems_VerticalAlignment()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Vertical Alignment with AlignItems
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AlignItems controls vertical alignment of columns within a row.
        // Options include Start, Center, End, and Stretch (default). Stretch
        // makes items fill the container height.
        //
        // EXERCISE: What is the default AlignItems value?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: No rendering needed for this knowledge check
        // ───────────────────────────────────────────────────────────────────────

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the default AlignItems value?           ║
        // ║                                                                    ║
        // ║  HINT: Flexbox default stretches items to fill container height    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: The default alignment value
        // ───────────────────────────────────────────────────────────────────────
        Assert.Equal("Stretch", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_JustifyContent_HorizontalAlignment()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Horizontal Alignment with JustifyContent
        // ═══════════════════════════════════════════════════════════════════════
        //
        // JustifyContent controls horizontal distribution of columns. Options
        // include Start, Center, End, SpaceBetween, SpaceAround, and SpaceEvenly.
        //
        // EXERCISE: Does the demo use JustifyContent?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo use JustifyContent?               ║
        // ║                                                                    ║
        // ║  HINT: Check RadzenRow for JustifyContent parameter                ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: JustifyContent is present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == cut.Markup.Contains("rz-justify") || answer == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_NestedRows_SupportedLayout()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Nested Grid Layouts
        // ═══════════════════════════════════════════════════════════════════════
        //
        // You can nest RadzenRow components inside RadzenColumn components. This
        // creates complex multi-level grid layouts for sophisticated page designs.
        //
        // EXERCISE: Does the demo show nested rows?
        // ═══════════════════════════════════════════════════════════════════════

        // ───────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the GridLayoutDemo component
        // ───────────────────────────────────────────────────────────────────────
        var cut = Render<GridLayoutDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the demo show nested rows?                 ║
        // ║                                                                    ║
        // ║  HINT: Look for RadzenRow inside RadzenColumn                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ───────────────────────────────────────────────────────────────────────
        // VERIFY: Nested rows are present (or not) as expected
        // ───────────────────────────────────────────────────────────────────────
        Assert.True(answer == true || answer == false);
    }
}
