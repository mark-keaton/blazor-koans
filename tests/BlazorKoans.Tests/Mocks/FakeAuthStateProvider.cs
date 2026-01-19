using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorKoans.Tests.Mocks;

public class FakeAuthStateProvider : AuthenticationStateProvider
{
    private AuthenticationState _currentState;

    public FakeAuthStateProvider(AuthenticationState? initialState = null)
    {
        _currentState = initialState ?? new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(_currentState);
    }

    public void SetAuthenticationState(AuthenticationState newState)
    {
        _currentState = newState;
        NotifyAuthenticationStateChanged(Task.FromResult(newState));
    }

    public void SetAuthenticatedUser(string username, string? role = null)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        if (role != null)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims, "TestAuth");
        var user = new ClaimsPrincipal(identity);
        SetAuthenticationState(new AuthenticationState(user));
    }

    public void SetUnauthenticatedUser()
    {
        SetAuthenticationState(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
    }
}
