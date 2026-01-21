using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;

namespace BlazorKoans.Tests.Beginner._05_ConditionalRendering;

/// <summary>
/// Conditional Rendering in Blazor
///
/// Blazor provides several ways to conditionally render content:
/// - @if/@else if/@else: Block-level conditional rendering
/// - Ternary operator: Inline conditional expressions @(condition ? "yes" : "no")
/// - Null checks: Safely rendering when data might be null
///
/// Understanding conditional rendering is essential for creating dynamic UIs
/// that respond to application state, user roles, and data availability.
/// </summary>
public class ConditionalKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void A_IfStatement()
    {
        // ABOUT: @if is the most basic conditional rendering in Blazor.
        // Content inside the @if block only renders when the condition is true.
        // Syntax: @if (condition) { <markup /> }

        // TODO: Look at the ConditionalDemo component with IsLoggedIn = true.
        // What text appears in the element with class "auth-message"?
        // Replace "__" with the expected message.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.IsLoggedIn, true));

        var expectedMessage = "__";

        Assert.Equal(expectedMessage, cut.Find(".auth-message").TextContent);

        // HINT: When logged in, the component shows a welcome message
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void B_IfElse()
    {
        // ABOUT: @if/@else lets you render one block or another based on a condition.
        // This is perfect for showing different content to logged-in vs logged-out users.
        // Syntax: @if (condition) { <a /> } else { <b /> }

        // TODO: When IsLoggedIn is false, what message appears?
        // Replace "__" with the expected message.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.IsLoggedIn, false));

        var expectedMessage = "__";

        Assert.Equal(expectedMessage, cut.Find(".auth-message").TextContent);

        // HINT: The else block shows a different message for guests
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void C_ElseIf()
    {
        // ABOUT: @else if allows multiple conditions to be checked in sequence.
        // Only the first matching condition's block is rendered.
        // Syntax: @if (a) { } else if (b) { } else { }

        // TODO: The component checks UserRole to display different content.
        // When UserRole is "admin", what CSS class is on the role-badge element?
        // Replace "__" with the expected class name.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.UserRole, "admin"));

        var expectedClass = "__";

        var badge = cut.Find(".role-badge");
        Assert.Contains(expectedClass, badge.ClassName);

        // HINT: Each role gets a different CSS class (admin, moderator, user)
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void D_TernaryExpression()
    {
        // ABOUT: For simple inline conditionals, use the ternary operator.
        // Syntax: @(condition ? "value if true" : "value if false")
        // This is great for toggling classes, text, or simple values.

        // TODO: The component uses a ternary to show item count status.
        // When ItemCount is 0, what text appears in the .count-status element?
        // Replace "__" with the expected text.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.ItemCount, 0));

        var expectedStatus = "__";

        Assert.Equal(expectedStatus, cut.Find(".count-status").TextContent);

        // HINT: The ternary shows "Empty" or "Has items" based on count
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void E_NullCheck()
    {
        // ABOUT: Always check for null before accessing object properties.
        // @if (user != null) prevents null reference exceptions.
        // This is crucial when data is loaded asynchronously or is optional.

        // TODO: When User is null, how many .user-info elements are rendered?
        // Replace 0 with the expected count.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.UserName, (string?)null));

        var expectedCount = 0;

        var userInfoElements = cut.FindAll(".user-info");
        Assert.Equal(expectedCount, userInfoElements.Count);

        // HINT: When User is null, the user-info section should not render at all
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void F_ConditionalCssClass()
    {
        // ABOUT: You can conditionally apply CSS classes using ternary expressions.
        // Syntax: class="base-class @(condition ? "active" : "inactive")"
        // This is a common pattern for styling based on state.

        // TODO: The component applies different classes based on ItemCount.
        // When ItemCount > 0, what additional class is on .item-container?
        // Replace "__" with the expected class.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.ItemCount, 5));

        var expectedClass = "__";

        var container = cut.Find(".item-container");
        Assert.Contains(expectedClass, container.ClassName);

        // HINT: Non-empty containers get a "has-items" class
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void G_ToggleState()
    {
        // ABOUT: Conditional rendering often responds to user actions.
        // Clicking a button can toggle a boolean, causing different content to render.
        // This is how you build interactive, stateful UIs.

        // TODO: Click the "Toggle Login" button. Does the auth-message change?
        // Initially IsLoggedIn is false. After clicking, is it true or false?
        // Replace false with the expected value.

        var cut = Render<ConditionalDemo>(parameters =>
            parameters.Add(p => p.IsLoggedIn, false));

        // Verify initial state
        Assert.Equal("Please log in", cut.Find(".auth-message").TextContent);

        // Click the toggle button
        cut.Find(".toggle-login").Click();

        var expectedIsLoggedIn = false;

        // After toggle, check if the message changed to logged-in state
        var isShowingLoggedInMessage = cut.Find(".auth-message").TextContent == "Welcome back!";
        Assert.Equal(expectedIsLoggedIn, isShowingLoggedInMessage);

        // HINT: Clicking the button should toggle from logged-out to logged-in
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void H_MultipleConditions()
    {
        // ABOUT: You can combine multiple conditions with && and ||.
        // @if (isAdmin && isActive) renders only when both are true.
        // This allows for complex permission and state checks.

        // TODO: The premium content only shows when IsLoggedIn AND UserRole is "premium".
        // When both conditions are met, is the .premium-content element present?
        // Replace false with true if it should be present.

        var cut = Render<ConditionalDemo>(parameters => parameters
            .Add(p => p.IsLoggedIn, true)
            .Add(p => p.UserRole, "premium"));

        var expectedToBePresent = false;

        var premiumContent = cut.FindAll(".premium-content");
        Assert.Equal(expectedToBePresent, premiumContent.Count > 0);

        // HINT: Premium content requires BOTH logged in AND premium role
    }
}
