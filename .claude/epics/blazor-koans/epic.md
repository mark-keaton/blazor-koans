---
name: blazor-koans
status: backlog
created: 2026-01-19T04:19:22Z
progress: 0%
prd: .claude/prds/blazor-koans.md
github: [Will be updated when synced to GitHub]
---

# Epic: blazor-koans

## Overview

Implement a test-driven learning project for Blazor Server using xUnit and bunit. The project teaches C# developers Blazor fundamentals through progressive exercises where learners make failing tests pass.

The implementation creates a single .NET 10 solution containing:
- A Blazor Server app with skeleton components for learners to complete
- An xUnit test project with bunit-based koans organized by difficulty level
- 12 topic modules spanning Beginner → Intermediate → Advanced

## Architecture Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Test Framework | xUnit + bunit | Industry standard for .NET; bunit is the de facto Blazor testing library |
| Project Structure | Single solution, two projects | Simple structure, easy to navigate |
| Koan Pattern | Placeholder values (`"__"`) | Familiar pattern from other koan projects; clear what needs fixing |
| Solution Delivery | Inline comments | No separate branch to maintain; learner sees solution immediately when stuck |
| Difficulty Structure | Folders per level | Clear visual hierarchy; supports `--filter` for running specific levels |

## Technical Approach

### Project Structure
```
BlazorKoans/
├── BlazorKoans.sln
├── src/BlazorKoans.App/
│   ├── Program.cs
│   ├── Components/
│   │   ├── App.razor
│   │   ├── Routes.razor
│   │   └── Exercises/          # Skeleton components for koans
│   │       ├── Beginner/
│   │       ├── Intermediate/
│   │       └── Advanced/
│   └── Services/               # Demo services for DI/HTTP koans
└── tests/BlazorKoans.Tests/
    ├── Beginner/
    │   ├── 01_Components/
    │   ├── 02_DataBinding/
    │   ├── 03_Events/
    │   └── 04_Lifecycle/
    ├── Intermediate/
    │   ├── 05_Routing/
    │   ├── 06_Forms/
    │   ├── 07_Validation/
    │   └── 08_DependencyInjection/
    └── Advanced/
        ├── 09_HttpClients/
        ├── 10_Authentication/
        ├── 11_StateManagement/
        └── 12_ErrorHandling/
```

### Koan Design Pattern
Each koan follows this structure:
1. **XML doc comment** explaining the concept being taught
2. **ABOUT comment** with brief explanation
3. **TODO comment** telling learner what to implement
4. **Test assertion** with placeholder value
5. **SOLUTION comment** with the answer

### Component Strategy
- Skeleton `.razor` files in `src/` with minimal/empty implementation
- Tests in `tests/` reference these components via bunit
- Learner modifies components, runs tests to verify

### Services for Advanced Topics
- `IWeatherService` - mock HTTP client for HTTP koans
- `FakeAuthenticationStateProvider` - for auth koans
- `AppState` - cascading state container for state management koans

## Implementation Strategy

### Development Phases
1. **Scaffold** - Create solution structure, configure dependencies
2. **Beginner Koans** - Foundation concepts (Components, Binding, Events, Lifecycle)
3. **Intermediate Koans** - Application concepts (Routing, Forms, Validation, DI)
4. **Advanced Koans** - Full-stack concepts (HTTP, Auth, State, Errors)
5. **Polish** - README, verify all tests fail initially, verify solutions work

### Testing Approach
- Run `dotnet test` after each module to ensure tests compile
- Verify tests FAIL with placeholder values
- Verify tests PASS when solutions are applied
- Use `[Trait("Category", "Beginner|Intermediate|Advanced")]` for filtering

### Risk Mitigation
| Risk | Mitigation |
|------|------------|
| bunit API changes | Pin to stable bunit version |
| Tests pass when they shouldn't | Each koan uses unique placeholder that cannot accidentally match |
| Learner confusion | Clear comments and consistent patterns across all koans |

## Task Breakdown

- [ ] **Task 1: Project Scaffolding** - Create solution, projects, dependencies, folder structure
- [ ] **Task 2: Beginner Koans** - Components, DataBinding, Events, Lifecycle (16 koans, ~4 per topic)
- [ ] **Task 3: Intermediate Koans** - Routing, Forms, Validation, DI (16 koans, ~4 per topic)
- [ ] **Task 4: Advanced Koans** - HTTP, Auth, State, ErrorHandling (16 koans, ~4 per topic)
- [ ] **Task 5: Documentation & Verification** - README, verify all tests fail/pass correctly

## Dependencies

### NuGet Packages
- `Microsoft.NET.Sdk.Web` (Blazor Server)
- `xunit` + `xunit.runner.visualstudio`
- `bunit` (Blazor component testing)
- `Microsoft.NET.Test.Sdk`

### Prerequisites
- .NET 10 SDK installed
- No external services required

## Success Criteria (Technical)

| Metric | Target |
|--------|--------|
| Test compilation | All tests compile without errors |
| Initial state | All 48 tests fail with placeholder values |
| Solution state | All 48 tests pass when solutions applied |
| Test execution time | Full suite < 30 seconds |
| `dotnet test` exit code | Returns 1 (failure) initially |

## Estimated Effort

| Task | Complexity | Notes |
|------|------------|-------|
| Project Scaffolding | Low | Standard .NET setup |
| Beginner Koans | Medium | 4 topics × 4 koans each |
| Intermediate Koans | Medium | 4 topics × 4 koans each |
| Advanced Koans | High | Requires mock services |
| Documentation | Low | README template |

**Total: 5 tasks**

The project is content-heavy but technically straightforward - most work is writing educational test cases and corresponding skeleton components.

## Tasks Created

- [ ] 001.md - Project Scaffolding (parallel: false)
- [ ] 002.md - Beginner Koans (parallel: true)
- [ ] 003.md - Intermediate Koans (parallel: true)
- [ ] 004.md - Advanced Koans (parallel: true)
- [ ] 005.md - Documentation and Verification (parallel: false)

**Total tasks:** 5
**Parallel tasks:** 3 (002, 003, 004 can run concurrently after 001)
**Sequential tasks:** 2 (001 first, 005 last)
**Estimated total effort:** 25 hours

### Dependency Graph
```
001 (Scaffolding)
 ├── 002 (Beginner) ──┐
 ├── 003 (Intermediate) ├── 005 (Docs)
 └── 004 (Advanced) ──┘
```
