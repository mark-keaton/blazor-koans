namespace BlazorKoans.App.Services;

public interface IGreetingService
{
    string Greet(string name);
    string GetServiceType();
}
