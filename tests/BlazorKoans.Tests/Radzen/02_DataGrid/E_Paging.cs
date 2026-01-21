using Bunit;
using BlazorKoans.App.Components.Exercises.RadzenKoans;
using Xunit;

namespace BlazorKoans.Tests.Radzen._02_DataGrid;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                               DATAGRID PAGING                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Paging splits large datasets into smaller pages for better performance      ║
/// ║  and usability. RadzenDataGrid supports automatic paging with configurable   ║
/// ║  page sizes and navigation controls.                                         ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  &lt;RadzenDataGrid Data="@employees"                                     │  ║
/// ║  │                   AllowPaging="true"                                   │  ║
/// ║  │                   PageSize="10"                                        │  ║
/// ║  │                   PageSizeOptions="@(new int[] { 5, 10, 20 })"         │  ║
/// ║  │                   ShowPagingSummary="true" /&gt;                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ║                                                                              ║
/// ║  Think of paging like chapters in a book - instead of showing all 1000       ║
/// ║  rows at once, show 20 at a time with "Next" and "Previous" buttons.         ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class E_Paging : BunitContext
{
    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_EnabledByProperty_AllowsPaging()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Enabling Paging
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set AllowPaging="true" on RadzenDataGrid to enable paging.
        // This adds pager controls below the grid (by default).
        //
        // EXERCISE: What property enables paging on the DataGrid?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Name the property that enables paging           ║
        // ║                                                                    ║
        // ║  HINT: It starts with "Allow"                                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you named the correct property
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("AllowPaging", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_PageSize_ControlsRowsPerPage()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Page Size
        // ═══════════════════════════════════════════════════════════════════════
        //
        // PageSize sets how many rows appear on each page.
        // Common values: 10, 20, 50, 100. Smaller pages load faster,
        // larger pages reduce clicking.
        //
        // EXERCISE: In PagingDemo, what is the PageSize set to?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PagingDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<PagingDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What PageSize is configured?                    ║
        // ║                                                                    ║
        // ║  HINT: Look at the PagingDemo component to find the value          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if the PageSize matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, 3);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_FirstPage_ShowsFirstRows()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: First Page Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The first page shows rows 1 through PageSize.
        // If PageSize is 3 and you have 10 employees, page 1 shows employees 1-3.
        //
        // EXERCISE: On page 1 with PageSize=3, how many rows are visible?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Render the PagingDemo component
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<PagingDemo>();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows are visible on page 1?            ║
        // ║                                                                    ║
        // ║  HINT: Count the table rows in tbody                               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if the row count matches
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.FindAll("tbody tr").Count);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_Navigation_MovesToNextPage()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Page Navigation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The pager shows navigation buttons: First, Previous, Page Numbers,
        // Next, Last. Clicking Next shows the next PageSize rows.
        //
        // EXERCISE: After clicking "Next" from page 1, which page are you on?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What page number after clicking Next?           ║
        // ║                                                                    ║
        // ║  HINT: Pages are numbered sequentially starting from 1             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the next page number
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(2, answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_LastPage_MayHaveFewerRows()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Last Page Row Count
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The last page might have fewer rows than PageSize.
        // With 10 rows and PageSize=3, the last page has only 1 row (row 10).
        //
        // EXERCISE: With 10 employees and PageSize=3, how many rows on the last page?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many rows on the last page?                 ║
        // ║                                                                    ║
        // ║  HINT: 10 ÷ 3 = 3 remainder 1                                      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = 0;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you calculated correctly
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(1, answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_PageSizeOptions_AllowsUserSelection()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Page Size Options
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Set PageSizeOptions to an array like new int[] { 10, 20, 50 }
        // to let users choose their preferred page size via a dropdown.
        //
        // EXERCISE: Can users change the page size if PageSizeOptions is set?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Can users change page size?                     ║
        // ║                                                                    ║
        // ║  HINT: PageSizeOptions provides a dropdown for selection           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_PagerPosition_ControlsLocation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Pager Position
        // ═══════════════════════════════════════════════════════════════════════
        //
        // PagerPosition controls where the pager appears:
        // PagerPosition.Bottom (default), Top, or Both.
        //
        // EXERCISE: What is the default PagerPosition?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the default pager position?             ║
        // ║                                                                    ║
        // ║  HINT: Think about where pagers typically appear in most grids     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the default position
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Bottom", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_ShowPagingSummary_DisplaysInfo()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Paging Summary
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ShowPagingSummary="true" displays text like "Showing 1 to 10 of 100 entries"
        // which helps users understand their position in the data.
        //
        // EXERCISE: Does ShowPagingSummary show the total number of records?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it show total records?                     ║
        // ║                                                                    ║
        // ║  HINT: "Showing 1 to 10 of 100 entries" - what's the 100?          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_PageChanged_EventFires()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: PageChanged Event
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The PageChanged event fires when the user navigates to a different page.
        // You can use this to load data for the new page or track analytics.
        //
        // EXERCISE: What parameter type does PageChanged event receive?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the event args type?                    ║
        // ║                                                                    ║
        // ║  HINT: It's a PageChangedEventArgs                                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if you know the event args type
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("PageChangedEventArgs", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_Count_TotalRecords()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Count Property
        // ═══════════════════════════════════════════════════════════════════════
        //
        // For server-side paging, you must set the Count property to the
        // total number of records. The grid uses this to calculate page numbers.
        //
        // EXERCISE: Is Count required for client-side paging (Data parameter)?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is Count required for client-side paging?       ║
        // ║                                                                    ║
        // ║  HINT: The grid counts the IEnumerable automatically               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("No", answer);
    }

    [Fact]
    [Trait("Category", "Radzen")]
    public void Paging_PreservesFiltersAndSorts()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Filters and Sorts with Paging
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you navigate pages, active filters and sorts remain applied.
        // Each page shows filtered/sorted results, not the original data order.
        //
        // EXERCISE: After filtering and paging, are filters still active on page 2?
        // ═══════════════════════════════════════════════════════════════════════

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Are filters preserved across pages?             ║
        // ║                                                                    ║
        // ║  HINT: Paging shows different slices of the same filtered data     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__"; // "Yes" or "No"

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check your understanding
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal("Yes", answer);
    }
}
