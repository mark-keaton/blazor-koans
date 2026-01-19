namespace BlazorKoans.App.Services;

public class GreetingService : IGreetingService
{
    private readonly Guid _instanceId = Guid.NewGuid();

    public string Greet(string name)
    {
        return $"Hello, {name}!";
    }

    public string GetServiceType()
    {
        return "Scoped";
    }

    public string GetInstanceId()
    {
        return _instanceId.ToString();
    }
}
