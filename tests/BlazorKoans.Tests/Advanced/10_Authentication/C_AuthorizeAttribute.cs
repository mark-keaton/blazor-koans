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
/// ║                           AUTHORIZE ATTRIBUTE                                ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  The [Authorize] attribute restricts access to components and pages based    ║
/// ║  on authentication and authorization requirements.                           ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  @attribute [Authorize]                                                │  ║
/// ║  │  @page "/protected"                                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │  <h1>Protected Content</h1>                                            │  ║
/// ║  │  <p>Only authenticated users can see this.</p>                         │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
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
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: The [Authorize] Attribute
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The [Authorize] attribute on a component requires authentication to
        // access that page. When present and the user is authenticated, the
        // component's content renders normally.
        //
        // EXERCISE: Does ProtectedPage render "Welcome" for an authenticated user?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering ProtectedPage with authenticated user
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the markup contain "Welcome"?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: If [Authorize] is present and user is authenticated, content renders
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Markup.Contains("Welcome"));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Authorized_users_can_access_protected_pages()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Accessing Protected Pages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Users who are authenticated can access [Authorize] protected pages.
        // The component can access the user's identity to display personalized
        // content like a welcome message with the user's name.
        //
        // EXERCISE: What name is displayed when user is set to "Grace"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering ProtectedPage with user "Grace"
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What username is displayed in the welcome?      ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The welcome message should include the user's name
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Welcome, {answer}!", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Authorize_attribute_works_with_AuthorizeView()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Combining [Authorize] with AuthorizeView
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [Authorize] on the component and <AuthorizeView> inside work together.
        // The attribute protects the entire page while AuthorizeView can show
        // different content sections based on roles or policies.
        //
        // EXERCISE: Does the Authorized section render for user "Hank"?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering ProtectedPage with user "Hank"
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does the markup contain "Welcome"?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The Authorized section should render
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Markup.Contains("Welcome"));
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Unauthenticated_users_see_login_message()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: NotAuthorized Content for Protected Pages
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When unauthenticated users try to access protected pages, they see
        // the NotAuthorized content. This typically prompts them to log in.
        //
        // EXERCISE: What message is shown to unauthenticated users?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering ProtectedPage without authentication
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What message is shown to unauthenticated users? ║
        // ║                                                                    ║
        // ║  HINT: Check the NotAuthorized section of ProtectedPage            ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The NotAuthorized content should be displayed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, cut.Markup);
    }
}
