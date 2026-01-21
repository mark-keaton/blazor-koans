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
/// ║                              ROLE-BASED AUTH                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Roles provide a way to group users and control access to features based     ║
/// ║  on their assigned roles (Admin, User, Manager, etc.).                       ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Check role in code                                                 │  ║
/// ║  │  if (user.IsInRole("Admin")) { ... }                                   │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Role-based AuthorizeView                                           │  ║
/// ║  │  <AuthorizeView Roles="Admin">                                         │  ║
/// ║  │      <p>Admin only content</p>                                         │  ║
/// ║  │  </AuthorizeView>                                                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
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
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Roles as Claims
        // ═══════════════════════════════════════════════════════════════════════
        //
        // User roles are represented as claims with type ClaimTypes.Role. When
        // you assign a role to a user, it becomes part of their identity claims
        // and can be checked throughout the application.
        //
        // EXERCISE: What role is displayed for a user with "Admin" role?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating user with Admin role
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What role is displayed?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The role should be displayed in the component
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Role: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void Users_without_roles_show_default_role()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Default Role Display
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Users without specific roles can have a default role display. This
        // provides a consistent UI experience even when no role is assigned.
        //
        // EXERCISE: What role is displayed for a user without any role?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating user without a role
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What default role is shown?                     ║
        // ║                                                                    ║
        // ║  HINT: Check what LoginStatus displays when no role is assigned    ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The default role should be displayed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Role: {answer}", cut.Markup);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void IsInRole_checks_user_role()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Checking Roles with IsInRole
        // ═══════════════════════════════════════════════════════════════════════
        //
        // ClaimsPrincipal.IsInRole() checks if a user has a specific role.
        // This method returns true if the user has the specified role claim,
        // false otherwise.
        //
        // EXERCISE: What does IsInRole("Admin") return for a user with Admin role?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating user with Admin role
        // ──────────────────────────────────────────────────────────────────────
        var authProvider = new FakeAuthStateProvider();
        authProvider.SetAuthenticatedUser("SuperUser", "Admin");

        var state = authProvider.GetAuthenticationStateAsync().Result;

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What does IsInRole return? ("true" or "false")  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: IsInRole should return the expected value
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, state.User.IsInRole("Admin").ToString().ToLower());
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public void AuthorizeView_can_filter_by_roles()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Role-Based AuthorizeView
        // ═══════════════════════════════════════════════════════════════════════
        //
        // AuthorizeView has a Roles parameter to show content only to users with
        // specific roles. Multiple roles can be specified as a comma-separated
        // string: Roles="Admin,Manager".
        //
        // EXERCISE: What role is displayed for a user with "Admin" role?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating user with Admin role
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What role is displayed?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The Admin role should be displayed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains($"Role: {answer}", cut.Markup);
    }
}
