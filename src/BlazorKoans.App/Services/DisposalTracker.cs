namespace BlazorKoans.App.Services;

public class DisposalTracker
{
    private readonly HashSet<object> _activeComponents = new();

    public void Register(object component)
    {
        _activeComponents.Add(component);
    }

    public void Unregister(object component)
    {
        _activeComponents.Remove(component);
    }

    public bool IsRegistered(object component) => _activeComponents.Contains(component);

    public int ActiveCount => _activeComponents.Count;
}
