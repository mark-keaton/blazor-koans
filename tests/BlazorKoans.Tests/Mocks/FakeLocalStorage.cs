namespace BlazorKoans.Tests.Mocks;

public interface ILocalStorageService
{
    Task<T?> GetItemAsync<T>(string key);
    Task SetItemAsync<T>(string key, T value);
    Task RemoveItemAsync(string key);
    Task ClearAsync();
}

public class FakeLocalStorage : ILocalStorageService
{
    private readonly Dictionary<string, object> _storage = new();

    public Task<T?> GetItemAsync<T>(string key)
    {
        if (_storage.TryGetValue(key, out var value))
        {
            return Task.FromResult((T?)value);
        }
        return Task.FromResult(default(T));
    }

    public Task SetItemAsync<T>(string key, T value)
    {
        if (value != null)
        {
            _storage[key] = value;
        }
        return Task.CompletedTask;
    }

    public Task RemoveItemAsync(string key)
    {
        _storage.Remove(key);
        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        _storage.Clear();
        return Task.CompletedTask;
    }

    public bool ContainsKey(string key) => _storage.ContainsKey(key);
}
