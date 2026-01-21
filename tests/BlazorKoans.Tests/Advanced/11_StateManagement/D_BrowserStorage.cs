using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.Tests.Mocks;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    BROWSER STORAGE IN BLAZOR                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Browser storage (localStorage/sessionStorage) persists data on the client.  ║
/// ║  localStorage persists even after browser closes; sessionStorage clears      ║
/// ║  when the tab closes.                                                        ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Store data                                                         │  ║
/// ║  │  await localStorage.SetItemAsync("key", value);                        │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Retrieve data                                                      │  ║
/// ║  │  var value = await localStorage.GetItemAsync&lt;T&gt;("key");                │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Remove specific item                                               │  ║
/// ║  │  await localStorage.RemoveItemAsync("key");                            │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Clear all items                                                    │  ║
/// ║  │  await localStorage.ClearAsync();                                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_BrowserStorage : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_persists_data_across_sessions()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: LocalStorage Persists Data
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Browser localStorage persists data even after the browser is closed.
        // Data stored with SetItemAsync can be retrieved later with GetItemAsync.
        //
        // EXERCISE: What value is retrieved after storing "Alice"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - storing and retrieving a value
        // ──────────────────────────────────────────────────────────────────────
        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("username", "Alice");
        var retrieved = await localStorage.GetItemAsync<string>("username");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What value is retrieved?                         ║
        // ║     HINT: The stored value "Alice" can be retrieved later           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The retrieved value should match what was stored
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, retrieved);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_stores_complex_objects()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: LocalStorage Handles Complex Objects
        // ═══════════════════════════════════════════════════════════════════════
        //
        // localStorage can store serialized objects, not just strings.
        // Objects are automatically serialized to JSON when storing and
        // deserialized when retrieving.
        //
        // EXERCISE: What is the Name property of the retrieved user object?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - storing and retrieving a complex object
        // ──────────────────────────────────────────────────────────────────────
        var localStorage = new FakeLocalStorage();

        var user = new { Name = "Bob", Age = 30 };
        await localStorage.SetItemAsync("user", user);

        var retrieved = await localStorage.GetItemAsync<dynamic>("user");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the Name of the retrieved object?        ║
        // ║     HINT: The object { Name = "Bob", Age = 30 } was stored          ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The retrieved object should have the correct Name
        // ──────────────────────────────────────────────────────────────────────
        Assert.NotNull(retrieved);
        Assert.Equal(answer, (string)retrieved.Name);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_RemoveItem_deletes_data()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: RemoveItemAsync Deletes Specific Keys
        // ═══════════════════════════════════════════════════════════════════════
        //
        // RemoveItemAsync deletes a specific key from storage.
        // After removal, GetItemAsync returns null for that key.
        //
        // EXERCISE: What is returned when getting a removed key?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - storing, removing, then retrieving
        // ──────────────────────────────────────────────────────────────────────
        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("temp", "temporary");
        await localStorage.RemoveItemAsync("temp");

        var retrieved = await localStorage.GetItemAsync<string>("temp");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is returned for a removed key?              ║
        // ║     HINT: After removal, the key no longer exists - returns null    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The retrieved value should be null
        // ──────────────────────────────────────────────────────────────────────
        Assert.Null(retrieved);
        Assert.Equal(answer, "null");
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_Clear_removes_all_data()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: ClearAsync Removes All Data
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ClearAsync removes all items from storage at once.
        // This is useful for logging out users or resetting application state.
        //
        // EXERCISE: How many items remain after ClearAsync?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - storing multiple items then clearing
        // ──────────────────────────────────────────────────────────────────────
        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("key1", "value1");
        await localStorage.SetItemAsync("key2", "value2");
        await localStorage.SetItemAsync("key3", "value3");

        await localStorage.ClearAsync();

        var item1 = await localStorage.GetItemAsync<string>("key1");
        var item2 = await localStorage.GetItemAsync<string>("key2");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - How many items remain after Clear?               ║
        // ║     HINT: ClearAsync removes ALL items from storage                 ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: All items should be null after clearing
        // ──────────────────────────────────────────────────────────────────────
        Assert.Null(item1);
        Assert.Null(item2);
        Assert.Equal(answer, "0");
    }
}
