using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                             AUTHORIZE VIEW                                   ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  AuthorizeView is a component that conditionally renders content based on    ║
/// ║  the user's authentication and authorization status.                         ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  <AuthorizeView>                                                       │  ║
/// ║  │      <Authorized>                                                      │  ║
/// ║  │          Welcome, @context.User.Identity?.Name!                        │  ║
/// ║  │      </Authorized>                                                     │  ║
/// ║  │      <NotAuthorized>                                                   │  ║
/// ║  │          Please log in.                                                │  ║
/// ║  │      </NotAuthorized>                                                  │  ║
/// ║  │  </AuthorizeView>                                                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class B_AuthorizeView : BunitContext
{
    public B_AuthorizeView()
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
    public void AuthorizeView_shows_NotAuthorized_for_unauthenticated_users()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: NotAuthorized Content
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AuthorizeView is a component that conditionally renders content based
        // on the user's authentication status. The <NotAuthorized> section is
        // displayed when the user is not authenticated.
        //
        // EXERCISE: What text is displayed for an unauthenticated user?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering LoginStatus with unauthenticated user
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetUnauthenticatedUser();

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<LoginStatus>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text is shown to unauthenticated users?    ║
        // ║                                                                    ║
        // ║  HINT: Check what the NotAuthorized section displays               ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The NotAuthorized content should be displayed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_shows_Authorized_for_authenticated_users()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Authorized Content
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The <Authorized> section renders when the user is authenticated. This
        // section typically displays personalized content like the user's name.
        //
        // EXERCISE: What username is displayed after setting user to "Charlie"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering LoginStatus with authenticated user
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Charlie");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<LoginStatus>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What username is displayed?                     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The Authorized content should show the username
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Logged in as: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_provides_context_with_user_info()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Context Parameter in AuthorizeView
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The context parameter in <Authorized> gives access to the user's claims
        // through context.User.Identity.Name and other properties. This allows
        // displaying user-specific information.
        //
        // EXERCISE: What name is displayed when user is set to "Diana"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering LoginStatus with user "Diana"
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Diana");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<LoginStatus>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What name appears in the component?             ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The user name should be displayed via context
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_updates_when_authentication_changes()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Reactive Authentication State
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AuthorizeView automatically re-renders when authentication state changes.
        // This means the UI updates immediately when a user logs in or out without
        // requiring a page refresh.
        //
        // EXERCISE: After changing from unauthenticated to "Eve", what name shows?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - starting with unauthenticated user
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetUnauthenticatedUser();

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<LoginStatus>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        Assert.Contains("Not logged in", cut.Markup);

        // Change authentication state
        authProvider.SetAuthenticatedUser("Eve");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What username is displayed after the change?    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The UI should automatically update with the new user
        // ──────────────────────────────────────────────────────────────────────
        cut.WaitForAssertion(() =>
            Assert.Contains($"Logged in as: {answer}", cut.Markup));
    }
}
