# Blazor Koans Test Pattern Guide

This document describes the standard pattern for writing educational koan tests in this project. Following this pattern ensures consistency and provides learners with clear, structured exercises.

---

## Overview

Each koan file consists of:
1. **Class-level documentation** - A visual "chapter header" explaining the topic
2. **Individual test methods** - Each with LESSON, ARRANGE, YOUR ANSWER, and VERIFY sections

---

## Class-Level Documentation

Every koan class should have a `/// <summary>` block with an ASCII art box header:

```csharp
/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                           TOPIC NAME IN CAPS                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Brief 1-2 sentence description of what this topic covers.                   ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // Code example showing the concept                                   │  ║
/// ║  │  <ExampleComponent Parameter="value" />                                │  ║
/// ║  │                                                                        │  ║
/// ║  │  // Another example line                                               │  ║
/// ║  │  @bind-Value="model.Property"                                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class TopicKoans : BunitContext
{
```

### Box Drawing Characters Reference

```
╔ ═ ╗    Top corners and horizontal line (double)
║   ║    Vertical lines (double)
╠ ═ ╣    Middle divider with connections (double)
╚ ═ ╝    Bottom corners and horizontal line (double)

┌ ─ ┐    Top corners and horizontal line (single) - for code boxes
│   │    Vertical lines (single)
└ ─ ┘    Bottom corners and horizontal line (single)
```

---

## Test Method Structure

Each test method follows a 4-part structure:

### 1. LESSON Section (═══)

Explains the concept being tested. Uses double-line separators:

```csharp
[Fact]
[Trait("Category", "Beginner")]  // or "Intermediate" or "Advanced"
public void ConceptName_BehaviorDescription()
{
    // ═══════════════════════════════════════════════════════════════════════
    // LESSON: Short Title of the Concept
    // ═══════════════════════════════════════════════════════════════════════
    //
    // Detailed explanation of the concept (2-4 lines).
    // Include relevant syntax examples if helpful.
    //
    // EXERCISE: Clear question about what the learner needs to figure out.
    // ═══════════════════════════════════════════════════════════════════════
```

### 2. ARRANGE Section (───)

Describes and contains the setup code. Uses single-line separators:

```csharp
    // ──────────────────────────────────────────────────────────────────────
    // ARRANGE: Setup - brief description of what's being set up
    // ──────────────────────────────────────────────────────────────────────
    var cut = Render<SomeComponent>();
    
    // Any additional setup code...
```

### 3. YOUR ANSWER Section (╔═══╗)

The visual box where learners input their answer. Always uses `var answer = ...`:

```csharp
    // ╔════════════════════════════════════════════════════════════════════╗
    // ║  ✏️  YOUR ANSWER - Brief description of what to answer             ║
    // ║                                                                    ║
    // ║  HINT: Optional hint to help the learner (if needed)               ║
    // ╚════════════════════════════════════════════════════════════════════╝
    var answer = "__";  // String answer
    // or
    var answer = 0;     // Numeric answer
    // or  
    var answer = false; // Boolean answer
```

### 4. VERIFY Section (───)

Contains the assertion(s). Uses single-line separators:

```csharp
    // ──────────────────────────────────────────────────────────────────────
    // VERIFY: Brief description of what's being verified
    // ──────────────────────────────────────────────────────────────────────
    Assert.Equal(expectedValue, answer);
}
```

---

## Complete Example

```csharp
using Bunit;
using BlazorKoans.App.Components.Exercises.Beginner;
using Xunit;

namespace BlazorKoans.Tests.Beginner._01_Components;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                         COMPONENT PARAMETERS                                 ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Parameters allow parent components to pass data to child components.        ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  // In the child component:                                            │  ║
/// ║  │  [Parameter]                                                           │  ║
/// ║  │  public string Title { get; set; }                                     │  ║
/// ║  │                                                                        │  ║
/// ║  │  // In the parent component:                                           │  ║
/// ║  │  <ChildComponent Title="Hello" />                                      │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class ComponentParameterKoans : BunitContext
{
    [Fact]
    [Trait("Category", "Beginner")]
    public void Parameter_PassesValueToChild()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Passing Values via Parameters
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When you add Title="Welcome" to a component tag, Blazor sets the
        // Title parameter property to "Welcome" before rendering.
        //
        // EXERCISE: What value will the Title parameter have?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - rendering component with Title parameter
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<Greeting>(parameters => parameters
            .Add(p => p.Title, "Welcome"));

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What is the Title parameter value?              ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The component's Title property should match
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.Title);
    }
}
```

---

## Answer Variable Guidelines

### String Answers
```csharp
var answer = "__";  // Placeholder for unknown string
```

### Numeric Answers
```csharp
var answer = 0;     // Placeholder for unknown number
```

### Boolean Answers
```csharp
var answer = false; // Placeholder for unknown boolean
```

### Choice Answers (same/different, true/false as strings)
```csharp
var answer = "__";  // User types "same" or "different"
```

---

## Hint Guidelines

Include hints when:
- The answer requires looking at another file
- The concept might be confusing for beginners
- There's a specific attribute or property name to find

```csharp
// ╔════════════════════════════════════════════════════════════════════╗
// ║  ✏️  YOUR ANSWER - What is the greeting message?                   ║
// ║                                                                    ║
// ║  HINT: Check the GreetingService.GetGreeting() method              ║
// ╚════════════════════════════════════════════════════════════════════╝
```

---

## Category Traits

Always include the appropriate category trait:

```csharp
[Trait("Category", "Beginner")]      // Basic concepts
[Trait("Category", "Intermediate")]  // More complex topics
[Trait("Category", "Advanced")]      // Advanced patterns
```

---

## File Naming Convention

```
{Letter}_{TopicName}.cs

Examples:
A_BasicConcept.cs
B_NextConcept.cs
C_AdvancedConcept.cs
D_FinalConcept.cs
```

The letter prefix determines the order tests appear in the test explorer.

---

## Folder Structure

```
tests/BlazorKoans.Tests/
├── Beginner/
│   ├── 01_Components/
│   ├── 02_DataBinding/
│   ├── 03_Events/
│   └── 04_Lifecycle/
├── Intermediate/
│   ├── 05_Routing/
│   ├── 06_Forms/
│   ├── 07_Validation/
│   ├── 08_DependencyInjection/
│   └── 09_TemplatedComponents/
├── Advanced/
│   ├── 09_HttpClients/
│   ├── 10_Authentication/
│   ├── 11_StateManagement/
│   └── 12_ErrorHandling/
└── Radzen/
    └── ...
```

---

## Line Length Guidelines

- Keep box widths consistent at ~78 characters (fits in most editors)
- The outer box uses 78 `═` characters
- Inner code boxes use 72 `─` characters
- Section separators use 71 `═` or `─` characters

---

## Tips for Writing Good Koans

1. **One concept per test** - Each test should teach exactly one thing
2. **Progressive difficulty** - Earlier tests in a file should be easier
3. **Clear exercises** - The EXERCISE line should be a clear question
4. **Helpful hints** - Include hints that point to specific files or methods
5. **Meaningful names** - Test names should describe what's being learned: `Parameter_PassesValueToChild`
6. **Real examples** - Use the actual components in the project, not hypothetical ones
