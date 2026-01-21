# Blazor Prerequisites for Radzen Koans

This document outlines the Blazor concepts you should understand before tackling the Radzen component koans. Each concept includes where it's covered in the existing koans and whether gaps exist.

## Legend

- **Covered**: Concept is explicitly taught in Beginner/Intermediate/Advanced koans
- **Partial**: Concept is used but not deeply explained
- **Gap**: Concept is required but not currently taught

---

## 1. Render Modes

**Status: Partial**

Radzen components require interactive render mode to function. All Radzen demos use:

```razor
@rendermode InteractiveServer
```

**What you need to know:**
- Blazor .NET 8+ requires explicit render mode declaration
- `InteractiveServer` enables event handling and state management
- Without interactive mode, components render as static HTML

**Where it's covered:** Mentioned in `A_RadzenSetup.cs` but not deeply explained

---

## 2. Component Parameters

**Status: Partial**

Components accept data from parents via parameters:

```csharp
[Parameter]
public bool UseEmptyData { get; set; }

[Parameter]
public string Title { get; set; } = "Default";
```

**What you need to know:**
- `[Parameter]` attribute marks properties as settable from parent
- Parameters can have default values
- Used in Razor: `<MyComponent Title="Hello" />`

**Where it's covered:** Beginner koans use parameters but don't explain them

---

## 3. Component Lifecycle

**Status: Gap**

Components have lifecycle methods that run at specific times:

```csharp
protected override void OnInitialized()
{
    // Runs once after parameters are set
    employees = LoadEmployees();
}

protected override async Task OnInitializedAsync()
{
    // Async version for API calls
    employees = await httpClient.GetFromJsonAsync<List<Employee>>("api/employees");
}
```

**What you need to know:**
- `OnInitialized` / `OnInitializedAsync` - runs once when component is created
- `OnParametersSet` / `OnParametersSetAsync` - runs when parameters change
- `OnAfterRender` / `OnAfterRenderAsync` - runs after DOM is updated

**Where it's covered:** Used in every Radzen demo but never explicitly taught

**Recommendation:** Add to Intermediate koans

---

## 4. Data Binding

### One-Way Binding
**Status: Covered**

Display values from C# in HTML:

```razor
<p>Name: @Name</p>
<p>Count: @employees.Count</p>
<span>@(employee.IsActive ? "Yes" : "No")</span>
```

### Two-Way Binding
**Status: Covered**

Sync values between UI and C#:

```razor
<RadzenTextBox @bind-Value="@Name" />
<input @bind="SearchTerm" />
```

**What you need to know:**
- `@property` displays the value (one-way)
- `@bind-Value` or `@bind` syncs both directions (two-way)
- Changes to bound properties trigger re-render

**Where it's covered:** Beginner koans cover binding well

---

## 5. Event Handling

**Status: Covered**

Handle user interactions with event callbacks:

```razor
<!-- Simple click handler -->
<RadzenButton Click="@HandleClick" />

<!-- Lambda with parameters -->
<RadzenButton Click="@(() => EditRow(employee))" />

<!-- Typed change handler -->
<RadzenCheckBox Change="@((bool value) => OnChange(value))" />
```

```csharp
private void HandleClick()
{
    clickCount++;
}

private void EditRow(Employee employee)
{
    // Edit logic
}
```

**What you need to know:**
- Events use `@EventName="@Handler"` syntax
- Lambdas allow passing parameters: `@(() => Method(param))`
- Typed handlers receive event data: `@((bool val) => ...)`

**Where it's covered:** Beginner and Intermediate koans

---

## 6. Generic Components (TItem)

**Status: Partial**

Generic components work with any data type:

```razor
<RadzenDataGrid Data="@employees" TItem="Employee">
    <Columns>
        <RadzenDataGridColumn TItem="Employee" Property="Name" />
    </Columns>
</RadzenDataGrid>
```

**What you need to know:**
- `TItem` specifies the data type for type-safe binding
- Enables IntelliSense for properties
- `TValue` is similar, used for input components

**Where it's covered:** `A_BasicDataGrid.cs` asks about TItem but doesn't explain generics

**Recommendation:** Add explanation of generic components

---

## 7. RenderFragment and Templates

**Status: Gap (newly added)**

RenderFragment allows passing UI content to components:

### Basic RenderFragment (ChildContent)
```razor
<RadzenCard>
    <h4>This becomes ChildContent</h4>
    <p>Any markup inside the tags</p>
</RadzenCard>
```

### Named RenderFragments
```razor
<SimpleCard>
    <Header>Card Title</Header>
    <ChildContent>Card Body</ChildContent>
    <Footer>Card Footer</Footer>
</SimpleCard>
```

### Generic RenderFragment with Context
```razor
<RadzenDataGridColumn TItem="Employee" Title="Status">
    <Template Context="employee">
        @if (employee.IsActive)
        {
            <RadzenBadge Text="Active" />
        }
    </Template>
</RadzenDataGridColumn>
```

**What you need to know:**
- Content between component tags becomes `ChildContent`
- Named fragments use `<FragmentName>...</FragmentName>` syntax
- `Context` attribute names the iteration variable
- Default context name is `context`

**Where it's covered:** Now in `09_TemplatedComponents` (Intermediate)

---

## 8. Component References (@ref)

**Status: Partial**

Get a reference to a component instance:

```razor
<RadzenDataGrid @ref="grid" Data="@employees" TItem="Employee" />

@code {
    private RadzenDataGrid<Employee>? grid;

    private async Task Refresh()
    {
        if (grid != null)
        {
            await grid.Reload();
        }
    }
}
```

**What you need to know:**
- `@ref` captures the component instance
- Type must match the component (including generics)
- Enables calling component methods programmatically
- Reference is null until after first render

**Where it's covered:** Used in DataGrid koans but not explained

**Recommendation:** Add to Intermediate koans

---

## 9. Forms and Validation

**Status: Covered**

Blazor forms use EditForm or RadzenTemplateForm:

```razor
<RadzenTemplateForm TItem="Model" Data="@model" Submit="@OnSubmit">
    <RadzenFormField Text="Username">
        <RadzenTextBox @bind-Value="@model.Username" Name="Username" />
        <RadzenRequiredValidator Component="Username" Text="Required" />
    </RadzenFormField>

    <RadzenButton ButtonType="ButtonType.Submit" Text="Submit" />
</RadzenTemplateForm>
```

**What you need to know:**
- Forms track field state (modified, valid, etc.)
- Validators check field values
- `Submit` fires for valid forms, `InvalidSubmit` for invalid
- `Name` attribute links inputs to validators

**Where it's covered:** Intermediate `06_Forms` and Radzen `03_Forms`

---

## 10. Conditional Rendering

**Status: Partial**

Render content based on conditions:

```razor
@if (isLoading)
{
    <p>Loading...</p>
}
else if (employees.Any())
{
    <RadzenDataGrid Data="@employees" ... />
}
else
{
    <p>No employees found</p>
}
```

**What you need to know:**
- `@if` / `@else if` / `@else` for conditional blocks
- Ternary for inline: `@(condition ? "Yes" : "No")`
- Null checks: `@if (data != null)`

**Where it's covered:** Used throughout but not explicitly taught

---

## 11. Loops and Iteration

**Status: Partial**

Render lists of items:

```razor
@foreach (var employee in employees)
{
    <div>@employee.Name</div>
}

@for (int i = 0; i < 5; i++)
{
    <span>@i</span>
}
```

**What you need to know:**
- `@foreach` renders for each item in collection
- `@for` for index-based iteration
- Changes to collection trigger re-render

**Where it's covered:** Used throughout but not explicitly taught

---

## 12. Async/Await

**Status: Gap**

Handle asynchronous operations:

```csharp
private async Task LoadData()
{
    isLoading = true;
    employees = await httpClient.GetFromJsonAsync<List<Employee>>("api/employees");
    isLoading = false;
}

private async Task SaveEmployee()
{
    await grid.Reload();
    await InvokeAsync(StateHasChanged);
}
```

**What you need to know:**
- `async Task` for async methods (not `async void`)
- `await` pauses until operation completes
- Many Radzen methods are async (Reload, EditRow, etc.)
- `InvokeAsync` for thread-safe UI updates

**Where it's covered:** Used in Radzen demos but not explained

**Recommendation:** Add to Intermediate koans

---

## 13. Nullable Types

**Status: Partial**

Handle optional values:

```csharp
private int? selectedId = null;
private string? searchTerm;
private RadzenDataGrid<Employee>? grid;

// Null-conditional operator
await grid?.Reload();

// Null-coalescing
var name = employee?.Name ?? "Unknown";
```

**What you need to know:**
- `?` after type allows null values
- Component references are nullable (null before first render)
- Use `?.` for safe member access
- Use `??` for default values

**Where it's covered:** Used throughout but assumed C# knowledge

---

## 14. Lambda Expressions

**Status: Partial**

Inline functions for event handlers and LINQ:

```razor
<!-- Event handler with parameter -->
<RadzenButton Click="@(() => DeleteEmployee(employee.Id))" />

<!-- Typed event handler -->
<RadzenDropDown Change="@((object val) => OnSelectionChange(val))" />
```

```csharp
// LINQ with lambdas
var activeEmployees = employees.Where(e => e.IsActive).ToList();
var names = employees.Select(e => e.Name);
```

**What you need to know:**
- `() => expression` for parameterless lambdas
- `(param) => expression` with parameters
- `(Type param) => expression` with explicit type
- Used extensively in LINQ and event handlers

**Where it's covered:** Used throughout, assumed C# knowledge

---

## 15. State Management

**Status: Covered**

Component state via properties and fields:

```csharp
@code {
    // Simple state
    private int count = 0;
    private string name = "";

    // Collection state
    private List<Employee> employees = new();

    // Computed state
    private decimal Total => Price * Quantity;

    // State change triggers re-render
    private void Increment()
    {
        count++;
        // No need to call StateHasChanged() for simple changes
    }
}
```

**What you need to know:**
- Private fields/properties store component state
- Changing state triggers re-render
- Use `StateHasChanged()` to force re-render if needed
- Computed properties recalculate automatically

**Where it's covered:** Beginner koans cover basics

---

## 16. Dependency Injection

**Status: Partial**

Inject services into components:

```razor
@inject HttpClient Http
@inject NavigationManager Navigation
@inject ILogger<MyComponent> Logger

@code {
    protected override async Task OnInitializedAsync()
    {
        var data = await Http.GetFromJsonAsync<List<Item>>("api/items");
    }
}
```

**What you need to know:**
- `@inject` provides service instances
- Services registered in `Program.cs`
- Radzen requires `builder.Services.AddRadzenComponents()`
- Common services: HttpClient, NavigationManager, IJSRuntime

**Where it's covered:** Setup mentioned in `A_RadzenSetup.cs`, covered in `08_DependencyInjection`

---

## Summary: Coverage Gaps

### Currently Taught (Good Coverage)
- Data binding (one-way and two-way)
- Event handling
- Forms and validation
- State management
- Dependency injection basics
- RenderFragment and templates (newly added)

### Needs Improvement (Partial Coverage)
- Render modes - mentioned but not explained
- Component parameters - used but not taught
- Generic components (TItem) - asked about but not explained
- Component references (@ref) - used but not taught
- Conditional rendering - used but not taught
- Loops - used but not taught
- Nullable types - assumed knowledge
- Lambda expressions - assumed knowledge

### Missing (Gaps to Fill)
- Component lifecycle (OnInitialized, etc.)
- Async/await patterns
- CSS isolation

---

## Recommended Learning Path

Before starting Radzen koans, complete:

1. **Beginner Koans** (01-04)
   - Component basics
   - Data binding
   - Event handling
   - State management

2. **Intermediate Koans** (05-09)
   - Routing
   - Forms
   - Validation
   - Dependency Injection
   - **Templated Components** (RenderFragment, Context)

3. **Then Radzen Koans**
   - 01_GettingStarted
   - 02_DataGrid
   - 03_Forms
   - 04_Layout
