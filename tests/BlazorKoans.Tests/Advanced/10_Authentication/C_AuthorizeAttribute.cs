using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Components.Exercises.Advanced;
using BlazorKoans.Tests.Mocks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace BlazorKoans.Tests.Advanced.Authentication;

public class C_AuthorizeAttribute : BunitContext
{
    public C_AuthorizeAttribute()
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
    public void Authorize_attribute_restricts_page_access()
    {
        // ABOUT: The [Authorize] attribute on a component requires authentication
        // to access that page.

        // TODO: Does the ProtectedPage component have the [Authorize] attribute?
        // Check the component definition.

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Frank");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<ProtectedPage>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        var expected = false;

        // If [Authorize] is present and user is authenticated, content should render
        Assert.Equal(expected, cut.Markup.Contains("Welcome"));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Authorized_users_can_access_protected_pages()
    {
        // ABOUT: Users who are authenticated can access [Authorize] protected pages.

        // TODO: Authenticate a user and render ProtectedPage.
        // What message is displayed?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Grace");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<ProtectedPage>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        var expected = "__";

        Assert.Contains($"Welcome, {expected}!", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Authorize_attribute_works_with_AuthorizeView()
    {
        // ABOUT: [Authorize] on the component and <AuthorizeView> inside work together.

        // TODO: Render ProtectedPage with authenticated user.
        // Does the Authorized section render?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("Hank");

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<ProtectedPage>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        var expected = false;

        Assert.Equal(expected, cut.Markup.Contains("Welcome"));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Unauthenticated_users_see_login_message()
    {
        // ABOUT: When unauthenticated users try to access protected pages,
        // they see the NotAuthorized content.

        // TODO: Render ProtectedPage without authentication.
        // What message is shown?

        var authProvider = new FakeAuthStateProvider();
        authProvider.SetUnauthenticatedUser();

        Services.AddSingleton<AuthenticationStateProvider>(authProvider);

        var cut = Render(builder =>
        {
            builder.OpenComponent<CascadingAuthenticationState>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)(childBuilder =>
            {
                childBuilder.OpenComponent<ProtectedPage>(0);
                childBuilder.CloseComponent();
            }));
            builder.CloseComponent();
        });

        var expected = "__";

        Assert.Contains(expected, cut.Markup);
    }
}
