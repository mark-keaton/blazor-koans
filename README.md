# Blazor Koans

Learn Blazor Server through test-driven exercises. Fix the failing tests to master Blazor fundamentals.

## What are Koans?

Koans are small, focused exercises that teach programming concepts through failing tests. Your job is to make the tests pass by understanding and implementing the correct solution.

Each koan includes:
- **ABOUT**: Explanation of the concept
- **TODO**: What you need to implement

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A code editor (VS Code, Visual Studio, or JetBrains Rider)

## Quick Start

```bash
# Clone the repository
git clone <repository-url>
cd blazor-koans

# Run the tests (they should fail!)
dotnet test

# Open in your editor and start learning
code .
```

## How to Use

1. **Run the tests** - they execute in learning order and stop at the first failure:
   ```bash
   dotnet test
   ```

2. **Read the failing test** - it shows you exactly what to learn:
   - `ABOUT:` explains the concept
   - `TODO:` tells you what to fix

<!-- TODO: It doesn't seem that the actual XUnit output does has either ABOUT or TODO entries. -->

3. **Fix the placeholder** - replace `"__"` with the correct answer

4. **Run tests again** - when it passes, you'll see the next koan

5. **Repeat** until all 114 tests pass!

### Example Workflow

```bash
$ dotnet test

Failed BlazorKoans.Tests.Beginner.Components.ComponentKoans.A_CreatingComponents
Expected: <h1>__</h1>
Actual:   <h1>Hello, Blazor!</h1>

# Open the test file, find the SOLUTION comment, replace "__" with "Hello, Blazor!"

$ dotnet test

Failed BlazorKoans.Tests.Beginner.Components.ComponentKoans.B_ComponentParameters
# Next koan!
```

## Learning Path

### Week 1: Beginner (16 koans)
| Topic          | Concepts                                                         |
| -------------- | ---------------------------------------------------------------- |
| 01_Components  | Creating components, parameters, child content, render fragments |
| 02_DataBinding | One-way binding, two-way binding, bind modifiers, bind:after     |
| 03_Events      | onclick, EventCallback, EventCallback<T>, preventDefault         |
| 04_Lifecycle   | OnInitialized, OnParametersSet, OnAfterRender, IDisposable       |

### Week 2: Intermediate (16 koans)
| Topic                  | Concepts                                                                 |
| ---------------------- | ------------------------------------------------------------------------ |
| 05_Routing             | @page directive, route parameters, query strings, NavigationManager      |
| 06_Forms               | EditForm, input components, form submission, EditContext                 |
| 07_Validation          | DataAnnotations, ValidationMessage, ValidationSummary, custom validators |
| 08_DependencyInjection | @inject, service lifetimes, scoped services, [Inject] attribute          |

### Week 3: Advanced (16+ koans)
| Topic              | Concepts                                                              |
| ------------------ | --------------------------------------------------------------------- |
| 09_HttpClients     | HttpClient injection, GET/POST requests, error handling               |
| 10_Authentication  | AuthenticationStateProvider, AuthorizeView, [Authorize], roles        |
| 11_StateManagement | CascadingValue, state containers, NotifyStateChanged, browser storage |
| 12_ErrorHandling   | ErrorBoundary, lifecycle errors, recovery, ILogger                    |

## Running Specific Tests

By default, tests run in order and stop at the first failure. You can also run specific sections:

```bash
# Run all tests in order (recommended)
dotnet test

# Run only Beginner koans (in order)
dotnet test --filter "Category=Beginner"

# Run only Intermediate koans
dotnet test --filter "Category=Intermediate"

# Run only Advanced koans
dotnet test --filter "Category=Advanced"

# Run a specific topic
dotnet test --filter "FullyQualifiedName~Components"

# Run ALL tests without stopping on failure (see full progress)
dotnet test -- xUnit.StopOnFail=false
```

## Project Structure

```
BlazorKoans/
├── src/BlazorKoans.App/           # The Blazor Server application
│   ├── Components/
│   │   └── Exercises/             # Components you'll be implementing
│   │       ├── Beginner/
│   │       ├── Intermediate/
│   │       └── Advanced/
│   ├── Services/                  # Services for DI exercises
│   └── Models/                    # Model classes for form exercises
│
└── tests/BlazorKoans.Tests/       # The koans (test files)
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

## Running the App

You can also run the Blazor app to see your components in action:

```bash
cd src/BlazorKoans.App
dotnet run
```

Then open https://localhost:5001 in your browser.

## Getting Stuck?

1. **Read the ABOUT section** in the test - it explains the concept
2. **Check the TODO section** - it tells you exactly what to implement
3. **Run the app** - sometimes seeing the component in action helps
4. **Check the solutions branch** - all answers are available there:
   ```bash
   git checkout solutions
   # Compare the test file to see the answer
   git checkout epic/blazor-koans  # Return to continue learning
   ```

## Tips for Success

- Start with Beginner koans even if you have some Blazor experience
- Read the test assertions carefully - they tell you what's expected
- Don't just copy solutions - understand why they work
- Run `dotnet run` to see your components in the browser
- Take breaks - learning is more effective in short sessions

## Technologies Used

- .NET 10
- Blazor Server
- xUnit (testing framework)
- bunit (Blazor component testing library)

## Contributing

Found a bug or want to add more koans? Contributions are welcome!

1. Fork the repository
2. Create a feature branch
3. Add your koans following the existing pattern
4. Submit a pull request

## License

MIT License - feel free to use this for learning and teaching!
