using Microsoft.AspNetCore.Components;
using BlazorKoans.App.Services;

namespace BlazorKoans.App.Components.Exercises.Intermediate;

public class ServiceDemoCodeBehindBase : ComponentBase
{
    [Inject]
    private IGreetingService GreetingServiceFromAttribute { get; set; } = default!;

    public string GetGreetingFromCodeBehind()
    {
        return GreetingServiceFromAttribute.Greet("Code-Behind User");
    }
}
