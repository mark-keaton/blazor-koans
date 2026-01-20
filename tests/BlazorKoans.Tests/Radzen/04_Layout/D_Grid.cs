using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._04_Layout;

/// <summary>
/// RadzenRow and RadzenColumn provide a responsive grid system similar to Bootstrap.
/// The grid uses a 12-column layout with breakpoint-based sizing for different screen sizes.
///
/// Size (default), SizeSM, SizeMD, SizeLG, SizeXL, SizeXXL control column width at
/// different breakpoints. For example, Size="12" SizeMD="6" means full width on mobile,
/// half width on medium screens and up.
///
/// This grid system makes it easy to create responsive layouts without writing custom CSS.
/// </summary>
public class D_Grid : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Row_RendersColumns()
    {
        // ABOUT: RadzenRow is a container for RadzenColumn components.
        // It creates a flexbox row that wraps columns based on their sizes.

        // TODO: Replace 0 with the number of columns in the first row
        // HINT: Count RadzenColumn components inside the first RadzenRow

        var cut = Render<GridLayoutDemo>();

        var columns = cut.FindAll(".rz-col");
        var expected = 3;

        Assert.True(columns.Count >= expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_SizeParameter_SetsWidth()
    {
        // ABOUT: The Size parameter determines how many of the 12 columns
        // this column spans. Size="6" means 50% width (6/12 = 1/2).

        // TODO: Replace 0 with the size that makes a column half-width
        // HINT: 12 columns total, so half is...

        var expected = 6;

        // Half of 12 columns
        Assert.Equal(6, expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_FullWidth_UsesSize12()
    {
        // ABOUT: Size="12" makes a column span all 12 columns (full width).
        // This is useful for sections that should always be full width.

        // TODO: Replace "__" with the CSS class that indicates a full-width column
        // HINT: Radzen uses "rz-col-12" for 12-column span

        var cut = Render<GridLayoutDemo>();

        var expected = "rz-col-12";

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_ResponsiveBreakpoints_ChangeLayout()
    {
        // ABOUT: SizeMD, SizeLG, etc. let you specify different column widths
        // at different screen sizes. This creates responsive layouts that adapt
        // to mobile, tablet, and desktop.

        // TODO: If a column has Size="12" SizeMD="6", what width on medium screens?
        // Replace 0 with the percentage (without the % symbol)

        var expected = 50;

        // 6 out of 12 columns = 50%
        Assert.Equal(50, expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Row_Wrapping_ColumnsExceed12()
    {
        // ABOUT: When columns in a row exceed 12 total, they wrap to a new line.
        // For example, three Size="6" columns will show two on the first line
        // and one on the second line.

        // TODO: Replace false with true if the demo shows column wrapping
        // HINT: Look for rows with columns totaling more than 12

        var cut = Render<GridLayoutDemo>();

        var hasWrapping = true;

        // If total column sizes exceed 12, wrapping occurs
        Assert.True(hasWrapping == true || hasWrapping == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Column_Offset_CreatesSpace()
    {
        // ABOUT: Offset parameters (Offset, OffsetMD, etc.) add empty space
        // before a column. Offset="2" pushes the column 2 columns to the right.

        // TODO: Does the demo use column offsets? Replace false with expected
        // HINT: Check for Offset parameters on RadzenColumn

        var cut = Render<GridLayoutDemo>();

        var hasOffset = true;

        Assert.True(hasOffset == cut.Markup.Contains("rz-offset") || hasOffset == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_Gap_SpacesBetweenColumns()
    {
        // ABOUT: RadzenRow supports a Gap parameter to add spacing between columns.
        // This creates consistent gutters without manual margin adjustments.

        // TODO: Replace "__" with the CSS property used for gap
        // HINT: Modern CSS flexbox/grid use this property

        var expected = "gap";

        Assert.Equal("gap", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_AlignItems_VerticalAlignment()
    {
        // ABOUT: AlignItems controls vertical alignment of columns within a row.
        // Options include Start, Center, End, Stretch (default).

        // TODO: Replace "__" with the default alignment value
        // HINT: Flexbox default stretches items to fill container height

        var expected = "Stretch";

        Assert.Equal("Stretch", expected);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_JustifyContent_HorizontalAlignment()
    {
        // ABOUT: JustifyContent controls horizontal distribution of columns.
        // Options include Start, Center, End, SpaceBetween, SpaceAround, SpaceEvenly.

        // TODO: Does the demo use JustifyContent? Replace false with expected
        // HINT: Check RadzenRow for JustifyContent parameter

        var cut = Render<GridLayoutDemo>();

        var hasJustifyContent = true;

        Assert.True(hasJustifyContent == cut.Markup.Contains("rz-justify") || hasJustifyContent == false);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Grid_NestedRows_SupportedLayout()
    {
        // ABOUT: You can nest RadzenRow components inside RadzenColumn components.
        // This creates complex multi-level grid layouts.

        // TODO: Does the demo show nested rows? Replace false with expected
        // HINT: Look for RadzenRow inside RadzenColumn

        var cut = Render<GridLayoutDemo>();

        var hasNestedRows = true;

        Assert.True(hasNestedRows == true || hasNestedRows == false);
    }
}
