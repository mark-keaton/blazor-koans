namespace BlazorKoans.Tests.Mocks;

public class FakeTimeProvider(DateTimeOffset now) : TimeProvider
{
    private DateTimeOffset _now = now;

    public FakeTimeProvider(int year, int month, int day, int hour, int minute)
        : this(new DateTimeOffset(year, month, day, hour, minute, 0, TimeSpan.Zero))
    {
    }

    public override DateTimeOffset GetUtcNow() => _now;

    public void SetNow(DateTimeOffset now) => _now = now;
}
