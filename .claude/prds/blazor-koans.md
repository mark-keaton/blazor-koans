---
name: blazor-koans
description: Test-driven learning exercises for mastering Blazor Server fundamentals
status: backlog
created: 2026-01-19T04:14:44Z
---

# PRD: blazor-koans

## Executive Summary

Blazor Koans is a test-driven learning project that teaches C# developers how to build Blazor Server applications through progressive, hands-on exercises. Following the proven "koans" methodology (popularized by Ruby Koans and JavaScript Koans), learners work through failing xUnit tests, implementing solutions to make them pass while learning Blazor concepts organically.

The project targets experienced C# developers who want to learn Blazor Server, covering everything from basic components to full-stack concerns like forms, validation, HTTP integration, authentication, and state management.

## Problem Statement

### What problem are we solving?

C# developers wanting to learn Blazor face several challenges:
1. **Documentation overload** - Microsoft docs are comprehensive but overwhelming for beginners
2. **Passive learning** - Most tutorials involve copying code without deep understanding
3. **Gaps in knowledge** - Easy to miss fundamental concepts when jumping into projects
4. **No immediate feedback** - Hard to know if you truly understand a concept

### Why is this important now?

- Blazor Server has matured significantly in .NET 10 with improved performance and features
- More enterprises are adopting Blazor for internal tooling and line-of-business apps
- The C# developer pool is large, but Blazor expertise is still relatively rare
- Test-driven learning provides measurable progress and builds good testing habits

## User Stories

### Primary Persona: The C# Developer

**Alex** is a senior C# developer with 5 years of experience building backend services and WPF desktop applications. Their team is building a new internal dashboard and has chosen Blazor Server. Alex knows C# deeply but has never built a web UI with Blazor.

### User Journeys

#### Journey 1: Getting Started
```
As a C# developer new to Blazor,
I want to clone the repo and run my first failing test,
So that I can start learning immediately without complex setup.
```

**Acceptance Criteria:**
- Clone repo and run `dotnet test` within 2 minutes
- First test fails with a clear message about what to implement
- README explains the learning path

#### Journey 2: Progressive Learning
```
As a learner,
I want exercises organized by difficulty (Beginner → Intermediate → Advanced),
So that I build knowledge incrementally without getting overwhelmed.
```

**Acceptance Criteria:**
- Clear folder structure: `Koans/Beginner/`, `Koans/Intermediate/`, `Koans/Advanced/`
- Each level builds on concepts from previous levels
- Difficulty is indicated in test names or comments

#### Journey 3: Understanding Failures
```
As a learner working through a koan,
I want failing tests to provide helpful hints,
So that I can learn without getting completely stuck.
```

**Acceptance Criteria:**
- Test failure messages explain what's expected
- Inline comments provide hints (solutions available as commented code)
- Each test file has a brief explanation of the concept being taught

#### Journey 4: Validating Understanding
```
As a learner who completed an exercise,
I want to run the test and see it pass,
So that I have confidence I understood the concept correctly.
```

**Acceptance Criteria:**
- Tests run quickly (< 5 seconds for full suite)
- Passing tests show clear success message
- Progress can be tracked by counting passing vs total tests

### Pain Points Being Addressed

1. **"Where do I start?"** - Clear numbered exercises with progressive difficulty
2. **"Did I do it right?"** - Immediate test feedback validates understanding
3. **"I'm stuck"** - Inline solution comments prevent complete blockers
4. **"What should I learn next?"** - Structured curriculum covers full-stack topics

## Requirements

### Functional Requirements

#### FR1: Project Structure
- Single .NET 10 solution with xUnit test project
- Folder structure organized by difficulty level
- Each topic area has its own folder within difficulty levels
- Example structure:
  ```
  BlazorKoans/
  ├── BlazorKoans.sln
  ├── src/
  │   └── BlazorKoans.App/          # Blazor Server app for testing
  ├── tests/
  │   └── BlazorKoans.Tests/
  │       ├── Beginner/
  │       │   ├── 01_Components/
  │       │   ├── 02_DataBinding/
  │       │   ├── 03_Events/
  │       │   └── 04_Lifecycle/
  │       ├── Intermediate/
  │       │   ├── 05_Routing/
  │       │   ├── 06_Forms/
  │       │   ├── 07_Validation/
  │       │   └── 08_DependencyInjection/
  │       └── Advanced/
  │           ├── 09_HttpClients/
  │           ├── 10_Authentication/
  │           ├── 11_StateManagement/
  │           └── 12_ErrorHandling/
  ```

#### FR2: Koan Format
- Each koan is an xUnit test with a descriptive name
- Tests start in a failing state (using placeholder values like `__` or `FILL_ME_IN`)
- Learner modifies the test or component code to make it pass
- Solution is provided as inline comments that can be uncommented

#### FR3: Topic Coverage

**Beginner (Exercises 01-04)**
- Components: Creating components, parameters, child content
- Data Binding: One-way binding, two-way binding with @bind
- Events: Event callbacks, EventCallback<T>, preventing default
- Lifecycle: OnInitialized, OnParametersSet, OnAfterRender, IDisposable

**Intermediate (Exercises 05-08)**
- Routing: @page directive, route parameters, query strings, NavigationManager
- Forms: EditForm, InputText/Number/Date, form submission
- Validation: DataAnnotations, ValidationMessage, custom validators
- Dependency Injection: Injecting services, scoped vs singleton in Blazor

**Advanced (Exercises 09-12)**
- HTTP Clients: HttpClient injection, calling APIs, handling responses
- Authentication: AuthenticationStateProvider, AuthorizeView, [Authorize]
- State Management: Cascading values, state containers, browser storage
- Error Handling: Error boundaries, global error handling, logging

#### FR4: Test Runner Integration
- All tests runnable via `dotnet test`
- Tests can be filtered by category: `dotnet test --filter "Category=Beginner"`
- Test output provides progress summary

#### FR5: Companion Blazor App
- Working Blazor Server app in `src/` folder
- Components that tests reference are real, runnable components
- Learner can run the app to see their solutions in action

### Non-Functional Requirements

#### NFR1: Performance
- Full test suite completes in under 30 seconds
- Individual koans run in under 1 second
- App startup time under 3 seconds

#### NFR2: Simplicity
- No external dependencies beyond .NET 10 SDK
- No database required (use in-memory or mocked data)
- No Docker required for basic usage

#### NFR3: Maintainability
- Code follows C# and Blazor best practices
- Tests are isolated and don't depend on execution order
- Clear separation between exercise code and solution code

#### NFR4: Accessibility
- Works on Windows, macOS, and Linux
- Compatible with VS Code, Visual Studio, and JetBrains Rider
- README provides setup instructions for all platforms

## Success Criteria

### Quantitative Metrics
- **Completion rate**: 70%+ of users who start complete at least the Beginner section
- **Time to first test**: < 5 minutes from clone to first failing test
- **Test suite stability**: 100% of tests pass when solutions are applied
- **GitHub stars**: 100+ stars within 6 months (indicates community interest)

### Qualitative Metrics
- Positive feedback on clarity of exercises
- Users report feeling confident building Blazor apps after completion
- Low issue count for "I'm stuck" type problems

## Constraints & Assumptions

### Constraints
- **Technical**: Must work with xUnit (most common .NET test framework)
- **Scope**: Blazor Server only (not Blazor WebAssembly or Blazor United)
- **Time**: Single developer building incrementally
- **Platform**: .NET 10 is required (no multi-targeting)

### Assumptions
- Users have C# experience (not teaching C# basics)
- Users have a working .NET 10 SDK installed
- Users understand basic unit testing concepts
- Users can use git to clone repositories

## Out of Scope

The following are explicitly NOT included in this project:

1. **Blazor WebAssembly** - Focus is Server-side rendering only
2. **Blazor Hybrid / MAUI** - Desktop/mobile scenarios not covered
3. **JavaScript interop deep dives** - Basic coverage only
4. **SignalR fundamentals** - Assumed Blazor handles this automatically
5. **Deployment / hosting** - Focus is on development, not DevOps
6. **UI component libraries** - Uses built-in components only (no MudBlazor, Radzen, etc.)
7. **Database integration** - Uses in-memory/mocked data only
8. **Video tutorials** - Text-based koans only

## Dependencies

### External Dependencies
- .NET 10 SDK
- xUnit test framework
- bunit (Blazor component testing library)

### Internal Dependencies
- None (standalone project)

## Appendix: Example Koan

```csharp
// File: tests/BlazorKoans.Tests/Beginner/01_Components/A_CreatingComponents.cs

using Xunit;
using Bunit;

namespace BlazorKoans.Tests.Beginner._01_Components;

/// <summary>
/// Blazor applications are built from components.
/// A component is a self-contained piece of UI defined in a .razor file.
/// Let's learn how to create and use components!
/// </summary>
public class A_CreatingComponents : TestContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void Components_render_their_markup()
    {
        // ABOUT: Components render HTML markup defined in their .razor file.
        // The simplest component just contains static HTML.

        // TODO: Open src/BlazorKoans.App/Components/HelloWorld.razor
        // and add markup so this test passes.

        var cut = RenderComponent<HelloWorld>();

        // What text should HelloWorld render?
        var expected = "__"; // SOLUTION: "Hello, World!"

        cut.MarkupMatches($"<p>{expected}</p>");
    }

    [Fact]
    [Trait("Category", "Beginner")]
    public void Components_can_accept_parameters()
    {
        // ABOUT: Components can accept parameters to customize their output.
        // Parameters are defined as public properties with [Parameter] attribute.

        // TODO: Open src/BlazorKoans.App/Components/Greeting.razor
        // and add a Name parameter.

        var cut = RenderComponent<Greeting>(parameters =>
            parameters.Add(p => p.Name, "Blazor"));

        // What should Greeting render when Name is "Blazor"?
        var expected = "__"; // SOLUTION: "Hello, Blazor!"

        cut.MarkupMatches($"<p>{expected}</p>");
    }
}
```

## Appendix: Learning Path

```
Week 1: Beginner
├── Day 1-2: Components (creating, parameters, child content)
├── Day 3-4: Data Binding (one-way, two-way, bind modifiers)
├── Day 5-6: Events (callbacks, event args, prevention)
└── Day 7: Lifecycle (initialization, rendering, cleanup)

Week 2: Intermediate
├── Day 1-2: Routing (pages, parameters, navigation)
├── Day 3-4: Forms (EditForm, input components)
├── Day 5-6: Validation (annotations, custom validators)
└── Day 7: Dependency Injection (services, scopes)

Week 3: Advanced
├── Day 1-2: HTTP Clients (API calls, error handling)
├── Day 3-4: Authentication (state, authorization)
├── Day 5-6: State Management (cascading, containers)
└── Day 7: Error Handling (boundaries, logging)
```
