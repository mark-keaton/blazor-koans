namespace BlazorKoans.App.Services;

public class CounterService : ICounterService
{
    public int Count { get; private set; }

    public void Increment()
    {
        Count++;
    }

    public void Reset()
    {
        Count = 0;
    }
}
