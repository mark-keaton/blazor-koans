namespace BlazorKoans.App.Services;

public interface ICounterService
{
    int Count { get; }
    void Increment();
    void Reset();
}
