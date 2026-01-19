namespace BlazorKoans.App.Services;

public class CounterStateContainer
{
    private int _count = 0;

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    public void Increment()
    {
        Count++;
    }

    public void Decrement()
    {
        Count--;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
