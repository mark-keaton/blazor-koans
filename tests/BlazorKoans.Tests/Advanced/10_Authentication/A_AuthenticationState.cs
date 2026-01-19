using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

public class A_AuthenticationState : BunitContext
{
    public A_AuthenticationState()
    {
        // Register required services for AuthorizeView
        Services.AddAuthorizationCore();
        Services.AddLogging();
        Services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationService, Microsoft.AspNetCore.Authorization.DefaultAuthorizationService>();
        Services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationHandlerContextFactory, Microsoft.AspNetCore.Authorization.DefaultAuthorizationHandlerContextFactory>();
        Services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationEvaluator, Microsoft.AspNetCore.Authorization.DefaultAuthorizationEvaluator>();
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task AuthenticationStateProvider_provides_user_identity()
    {
        // ABOUT: AuthenticationStateProvider is the core service that manages
        // the current user's authentication state in Blazor.

        // TODO: Create a FakeAuthStateProvider and check if user is authenticated.
        // Is the default user authenticated?

        var authProvider = new FakeAuthStateProvider();
        var state = await authProvider.GetAuthenticationStateAsync();

        var expected = false; // SOLUTION: false

        Assert.Equal(expected, state.User.Identity?.IsAuthenticated ?? false);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task AuthenticationStateProvider_can_set_authenticated_user()
    {
        // ABOUT: Custom AuthenticationStateProvider implementations can
        // programmatically set the current user.

        // TODO: Use FakeAuthStateProvider.SetAuthenticatedUser().
        // What is the username after setting it to "TestUser"?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("TestUser");

        var state = await authProvider.GetAuthenticationStateAsync();

        var expected = "TestUser"; // SOLUTION: "TestUser"

        Assert.Equal(expected, state.User.Identity?.Name);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task AuthenticationState_contains_ClaimsPrincipal()
    {
        // ABOUT: AuthenticationState wraps a ClaimsPrincipal which represents the user.

        // TODO: Get the ClaimsPrincipal from AuthenticationState.
        // What type is the User property?

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Alice")
        }, "TestAuth");

        var principal = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(principal);

        var expected = "ClaimsPrincipal"; // SOLUTION: "ClaimsPrincipal"

        Assert.IsType<ClaimsPrincipal>(state.User);
        Assert.Equal("ClaimsPrincipal", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthenticationStateProvider_must_be_registered_in_DI()
    {
        // ABOUT: To use authentication in components, AuthenticationStateProvider
        // must be registered in the service collection.

        // TODO: Register FakeAuthStateProvider in the test context.
        // Can components now access authentication state?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Bob");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        // Wrap in CascadingAuthenticationState to provide authentication context
        var cut = Render(builder =>
        {
            builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<LoginStatus>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        var expected = true; // SOLUTION: true

        Assert.Equal(expected, cut.Markup.Contains("Logged in as: Bob"));
    }
}
