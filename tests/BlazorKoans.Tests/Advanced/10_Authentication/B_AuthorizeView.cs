using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

public class B_AuthorizeView : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_shows_NotAuthorized_for_unauthenticated_users()
    {
        // ABOUT: AuthorizeView is a component that conditionally renders content
        // based on the user's authentication status.

        // TODO: Render LoginStatus with an unauthenticated user.
        // What text is displayed?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetUnauthenticatedUser();

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render<LoginStatus>();

        var expected = "__"; // SOLUTION: "Not logged in"

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_shows_Authorized_for_authenticated_users()
    {
        // ABOUT: The <Authorized> section renders when user is authenticated.

        // TODO: Set an authenticated user and render LoginStatus.
        // What username is displayed?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Charlie");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render<LoginStatus>();

        var expected = "__"; // SOLUTION: "Charlie"

        Assert.Contains($"Logged in as: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_provides_context_with_user_info()
    {
        // ABOUT: The context parameter in <Authorized> gives access to the user's claims.

        // TODO: Access the user's name through context.User.Identity.Name.
        // Does the LoginStatus component use this pattern?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Diana");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render<LoginStatus>();

        var expected = "__"; // SOLUTION: "Diana"

        Assert.Contains(expected, cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_updates_when_authentication_changes()
    {
        // ABOUT: AuthorizeView automatically re-renders when authentication state changes.

        // TODO: Change from unauthenticated to authenticated.
        // Does the UI update automatically?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetUnauthenticatedUser();

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render<LoginStatus>();

        Assert.Contains("Not logged in", cut.Markup);

        authProvider.SetAuthenticatedUser("Eve");

        var expected = "__"; // SOLUTION: "Eve"

        cut.WaitForAssertion(() =>
            Assert.Contains($"Logged in as: {expected}", cut.Markup));
    }
}
