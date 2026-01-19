namespace BlazorKoans.Tests.Mocks;

public class FakeTimeProvider : TimeProvider
{
    private DateTimeOffset _now;

    public FakeTimeProvider(DateTimeOffset now)
    {
        _now = now;
    }

    public FakeTimeProvider(int year, int month, int day, int hour, int minute)
        : this(new DateTimeOffset(year, month, day, hour, minute, 0, TimeSpan.Zero))
    {
    }

    public override DateTimeOffset GetUtcNow() => _now;

    public void SetNow(DateTimeOffset now) => _now = now;
}
