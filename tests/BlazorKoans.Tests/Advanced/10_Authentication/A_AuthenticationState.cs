using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                          AUTHENTICATION STATE                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  AuthenticationStateProvider is the core service that manages the current    ║
/// ║  user's authentication state in Blazor applications.                         ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Inject AuthenticationStateProvider                                 │  ║
/// ║  │  @inject AuthenticationStateProvider AuthStateProvider                 │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Get the current authentication state                               │  ║
/// ║  │  var authState = await AuthStateProvider.GetAuthenticationStateAsync() │  ║
/// ║  │  var user = authState.User;                                            │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
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
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Default Authentication State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AuthenticationStateProvider is the core service that manages the current
        // user's authentication state in Blazor. By default, when no user is set,
        // the provider returns an unauthenticated state.
        //
        // EXERCISE: Is the default user authenticated?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a FakeAuthStateProvider with default state
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        var state = await authProvider.GetAuthenticationStateAsync();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Is the default user authenticated?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Check if the user identity is authenticated
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, state.User.Identity?.IsAuthenticated ?? false);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task AuthenticationStateProvider_can_set_authenticated_user()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Setting an Authenticated User
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Custom AuthenticationStateProvider implementations can programmatically
        // set the current user. The SetAuthenticatedUser method creates a new
        // ClaimsPrincipal with the specified username.
        //
        // EXERCISE: What is the username after setting it to "TestUser"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - setting an authenticated user
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("TestUser");
        var state = await authProvider.GetAuthenticationStateAsync();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the username?                           ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The user's name should match what was set
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, state.User.Identity?.Name);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task AuthenticationState_contains_ClaimsPrincipal()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: AuthenticationState and ClaimsPrincipal
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AuthenticationState wraps a ClaimsPrincipal which represents the user.
        // The ClaimsPrincipal contains one or more ClaimsIdentity objects that
        // hold the user's claims (name, roles, etc.).
        //
        // EXERCISE: What type is the User property on AuthenticationState?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating an AuthenticationState with a ClaimsPrincipal
        // ──────────────────────────────────────────────────────────────────────
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Alice")
        }, "TestAuth");

        var principal = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(principal);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What type is the User property?                 ║
        // ║                                                                    ║
        // ║  HINT: It's the standard .NET type for representing a user         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The User property should be a ClaimsPrincipal
        // ──────────────────────────────────────────────────────────────────────
        Assert.IsType<ClaimsPrincipal>(state.User);
        Assert.Equal("ClaimsPrincipal", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthenticationStateProvider_must_be_registered_in_DI()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Registering AuthenticationStateProvider in DI
        // ═══════════════════════════════════════════════════════════════════════
        //
        // To use authentication in components, AuthenticationStateProvider must
        // be registered in the service collection. Components can then access
        // authentication state through cascading parameters or direct injection.
        //
        // EXERCISE: Can components access authentication state after registration?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - registering auth provider and rendering component
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the markup contain "Logged in as: Bob"?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The component should display the logged-in user
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Markup.Contains("Logged in as: Bob"));
    }
}
