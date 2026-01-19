using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.Tests.Mocks;
using Xunit;

namespace BlazorKoans.Tests.Advanced.StateManagement;

public class D_BrowserStorage : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_persists_data_across_sessions()
    {
        // ABOUT: Browser localStorage persists data even after the browser is closed.

        // TODO: Use FakeLocalStorage to store a value.
        // Can it be retrieved later?

        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("username", "Alice");
        var retrieved = await localStorage.GetItemAsync<string>("username");

        var expected = "__"; // SOLUTION: "Alice"

        Assert.Equal(expected, retrieved);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_stores_complex_objects()
    {
        // ABOUT: localStorage can store serialized objects, not just strings.

        // TODO: Store and retrieve a complex object.
        // Does FakeLocalStorage handle it?

        var localStorage = new FakeLocalStorage();

        var user = new { Name = "Bob", Age = 30 };
        await localStorage.SetItemAsync("user", user);

        var retrieved = await localStorage.GetItemAsync<dynamic>("user");

        var expected = "__"; // SOLUTION: "Bob"

        Assert.NotNull(retrieved);
        Assert.Equal(expected, retrieved.Name);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_RemoveItem_deletes_data()
    {
        // ABOUT: RemoveItemAsync deletes a specific key from storage.

        // TODO: Store a value, then remove it.
        // What is returned when getting a removed key?

        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("temp", "temporary");
        await localStorage.RemoveItemAsync("temp");

        var retrieved = await localStorage.GetItemAsync<string>("temp");

        var expected = "__"; // SOLUTION: "null"

        Assert.Null(retrieved);
        Assert.Equal("null", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task LocalStorage_Clear_removes_all_data()
    {
        // ABOUT: ClearAsync removes all items from storage.

        // TODO: Store multiple items, then clear storage.
        // How many items remain?

        var localStorage = new FakeLocalStorage();

        await localStorage.SetItemAsync("key1", "value1");
        await localStorage.SetItemAsync("key2", "value2");
        await localStorage.SetItemAsync("key3", "value3");

        await localStorage.ClearAsync();

        var item1 = await localStorage.GetItemAsync<string>("key1");
        var item2 = await localStorage.GetItemAsync<string>("key2");

        var expected = "__"; // SOLUTION: "0"

        Assert.Null(item1);
        Assert.Null(item2);
        Assert.Equal("0", expected); // 0 items remain
    }
}
