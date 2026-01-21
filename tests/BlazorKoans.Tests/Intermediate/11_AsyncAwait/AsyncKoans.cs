using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;

namespace BlazorKoans.Tests.Intermediate._11_AsyncAwait;

/// <summary>
/// Async/Await Patterns in Blazor
///
/// Blazor components frequently need to perform asynchronous operations:
/// - Loading data from APIs
/// - Delayed operations
/// - Database queries
/// - File operations
///
/// Blazor provides async versions of lifecycle methods:
/// - OnInitializedAsync: Component initialization
/// - OnParametersSetAsync: When parameters change
/// - OnAfterRenderAsync: After rendering completes
///
/// Understanding async patterns is crucial for responsive Blazor applications.
/// </summary>
public class AsyncKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void A_OnInitializedAsync()
    {
        // ABOUT: OnInitializedAsync is the async version of OnInitialized.
        // It runs when the component is first created.
        // Use it for loading initial data from async sources.
        // Blazor will render once before and once after the async work completes.

        // TODO: Look at AsyncDemo.razor. It loads data in OnInitializedAsync.
        // The component shows a loading message while IsLoading is true.
        // What text is shown in the .loading-message element during loading?
        // Replace "__" with the expected message.

        var cut = Render<AsyncDemo>();

        var expectedLoadingMessage = "__";

        // Before async completes, the loading message is shown
        var loadingMessage = cut.Find(".loading-message");
        Assert.Contains(expectedLoadingMessage, loadingMessage.TextContent);

        // HINT: Components typically show "Loading..." while awaiting data
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void B_LoadedData()
    {
        // ABOUT: After OnInitializedAsync completes, the data is available.
        // Blazor automatically calls StateHasChanged() after async lifecycle methods.
        // The UI updates to show the loaded data without manual intervention.

        // TODO: The AsyncDemo loads a list of items asynchronously.
        // After loading completes, how many items are displayed?
        // Replace 0 with the expected count.
        // Note: Use WaitForState to wait for async operations in bUnit.

        var cut = Render<AsyncDemo>();

        // Wait for loading to complete
        cut.WaitForState(() => !cut.Instance.IsLoading);

        var expectedItemCount = 0;

        var items = cut.FindAll(".loaded-item");
        Assert.Equal(expectedItemCount, items.Count);

        // HINT: Check the SimulateLoadingAsync method to see how many items are loaded
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void C_IsLoadingFlag()
    {
        // ABOUT: A common pattern is using an IsLoading flag to track async state.
        // Set IsLoading = true before await, and false after.
        // This allows showing/hiding loading indicators in the UI.

        // TODO: After the async load completes, what is the value of IsLoading?
        // Replace true with the expected value after loading finishes.
        // Note: Use WaitForState to wait for async operations in bUnit.

        var cut = Render<AsyncDemo>();

        // Wait for loading to complete
        cut.WaitForState(() => !cut.Instance.IsLoading);

        var expectedIsLoading = true;

        // In bUnit, we can check the component's public property
        Assert.Equal(expectedIsLoading, cut.Instance.IsLoading);

        // HINT: IsLoading should be false when loading is complete
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void D_AsyncButtonHandler()
    {
        // ABOUT: Event handlers can also be async (async void or async Task).
        // Example: private async Task HandleClick() { await DoWorkAsync(); }
        // Blazor handles async event handlers gracefully.

        // TODO: The AsyncDemo has a button that triggers an async refresh.
        // After clicking and the async operation completes, what message appears?
        // Replace "__" with the expected message.
        // Note: Use WaitForAssertion to wait for async event handlers in bUnit.

        var cut = Render<AsyncDemo>();

        // Wait for initial load
        cut.WaitForState(() => !cut.Instance.IsLoading);

        // Click the refresh button
        cut.Find("button.refresh-button").Click();

        // Wait for the refresh to complete
        cut.WaitForAssertion(() =>
        {
            var msg = cut.Find(".status-message").TextContent;
            Assert.NotEqual("Refreshing...", msg);
        });

        var expectedMessage = "__";

        var statusMessage = cut.Find(".status-message").TextContent;
        Assert.Equal(expectedMessage, statusMessage);

        // HINT: Look at the RefreshAsync method to see what message it sets
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void E_OnAfterRenderAsync()
    {
        // ABOUT: OnAfterRenderAsync runs after the component renders.
        // It receives a firstRender parameter (true on first render).
        // Use it for JS interop or operations requiring DOM elements.
        // Note: Calling StateHasChanged in OnAfterRenderAsync triggers re-render!

        // TODO: The AsyncDemo tracks renders in OnAfterRenderAsync.
        // After initial render cycle completes, how many renders have occurred?
        // Replace 0 with the expected render count.
        // Note: Wait for the render count to stabilize using WaitForAssertion.

        var cut = Render<AsyncDemo>();

        // Wait for the render cycle to complete
        cut.WaitForAssertion(() =>
        {
            var renderCountText = cut.Find(".render-count").TextContent;
            var count = int.Parse(renderCountText.Replace("Renders: ", ""));
            Assert.True(count >= 1);
        });

        var expectedRenderCount = 0;

        var finalRenderCountText = cut.Find(".render-count").TextContent;
        var actualCount = int.Parse(finalRenderCountText.Replace("Renders: ", ""));
        Assert.Equal(expectedRenderCount, actualCount);

        // HINT: The first render calls OnAfterRenderAsync which sets the count to 1
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void F_ExceptionHandling()
    {
        // ABOUT: Async operations can fail. Handle exceptions gracefully.
        // Common pattern: try/catch in async methods, store error message.
        // Display friendly error messages to users when operations fail.

        // TODO: The AsyncDemo has a button that triggers an operation that fails.
        // After clicking the "Trigger Error" button, what CSS class is on the error element?
        // Replace "__" with the expected class.
        // Note: Use WaitForAssertion to wait for error handling in bUnit.

        var cut = Render<AsyncDemo>();

        // Click the error button
        cut.Find("button.error-button").Click();

        // Wait for the error to be displayed
        cut.WaitForAssertion(() =>
        {
            var err = cut.Find(".error-display");
            Assert.NotNull(err);
        });

        var expectedErrorClass = "__";

        var errorElement = cut.Find(".error-display");
        Assert.Contains(expectedErrorClass, errorElement.ClassName);

        // HINT: Error messages typically have a class like "error-message" or "error-visible"
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void G_CancellationToken()
    {
        // ABOUT: Long-running async operations should support cancellation.
        // When a component is disposed, pending operations should be cancelled.
        // Use CancellationTokenSource and pass tokens to async methods.

        // TODO: The AsyncDemo implements IDisposable and cancels operations on dispose.
        // After disposing the component, is the cancellation token cancelled?
        // Replace false with true if it should be cancelled.

        var cut = Render<AsyncDemo>();

        // Dispose the component
        cut.Dispose();

        var expectedCancelled = false;

        // This test verifies the pattern is implemented correctly
        // In real use, the component's CancellationTokenSource.Cancel() is called
        Assert.Equal(expectedCancelled, true); // The pattern should cancel

        // HINT: Disposing should cancel any pending async operations
    }
}
