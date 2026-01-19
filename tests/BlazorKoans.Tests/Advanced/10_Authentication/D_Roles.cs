using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

public class D_Roles : BunitContext
{
    public D_Roles()
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
    public void Roles_are_stored_as_claims()
    {
        // ABOUT: User roles are represented as claims with type ClaimTypes.Role.

        // TODO: Set a user with role "Admin".
        // What role does the user have?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Admin", "Admin");

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

        var expected = "Admin"; // SOLUTION: "Admin"

        Assert.Contains($"Role: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Users_without_roles_show_default_role()
    {
        // ABOUT: Users without specific roles can have a default role display.

        // TODO: Set a user without a role.
        // What role is displayed in LoginStatus?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Regular");

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

        var expected = "User"; // SOLUTION: "User"

        Assert.Contains($"Role: {expected}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void IsInRole_checks_user_role()
    {
        // ABOUT: ClaimsPrincipal.IsInRole() checks if user has a specific role.

        // TODO: Check if a user with "Admin" role is in the "Admin" role.
        // What does IsInRole return?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("SuperUser", "Admin");

        var state = authProvider.GetAuthenticationStateAsync().Result;

        var expected = "true"; // SOLUTION: "true"

        Assert.Equal(expected, state.User.IsInRole("Admin").ToString().ToLower());
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_can_filter_by_roles()
    {
        // ABOUT: AuthorizeView has a Roles parameter to show content only to specific roles.

        // TODO: The LoginStatus component checks for "Admin" role.
        // What is displayed for a user with "Admin" role?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("AdminUser", "Admin");

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

        var expected = "Admin"; // SOLUTION: "Admin"

        Assert.Contains($"Role: {expected}", cut.Markup);
    }
}
