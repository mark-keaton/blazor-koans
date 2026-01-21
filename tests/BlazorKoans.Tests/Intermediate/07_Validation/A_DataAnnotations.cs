using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                    DATA ANNOTATIONS VALIDATION                               ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  Data Annotations are attributes on model properties that define rules.      ║
/// ║  Blazor validates these automatically with DataAnnotationsValidator.         ║
/// ║                                                                              ║
/// ║  Common Validation Attributes:                                               ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  [Required]           → Field must have a value                       │  ║
/// ║  │  [StringLength(50)]   → Max (and optional min) string length          │  ║
/// ║  │  [Range(1, 100)]      → Numeric range validation                      │  ║
/// ║  │  [EmailAddress]       → Valid email format                            │  ║
/// ║  │  [Phone]              → Valid phone format                            │  ║
/// ║  │  [RegularExpression]  → Custom regex pattern                          │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class A_DataAnnotations : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_RequiredValidation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: [Required] Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [Required] ensures a field has a non-null, non-empty value.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  public class Person                                                │
        // │  {                                                                  │
        // │      [Required(ErrorMessage = "Name is required")]                  │
        // │      public string Name { get; set; }                               │
        // │  }                                                                  │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // To enable validation in EditForm, add DataAnnotationsValidator:
        // <EditForm Model="@person"><DataAnnotationsValidator /></EditForm>
        //
        // EXERCISE: If Name is [Required] and you submit an empty form,
        //           will IsInvalid be true or false?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - submitting form with empty fields
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - With empty required fields, is form invalid?     ║
        // ║      Change 'false' to 'true' if validation fails                  ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: OnInvalidSubmit should have set IsInvalid
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.IsInvalid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_RangeValidation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: [Range] Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [Range(min, max)] ensures a numeric value falls within bounds.
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [Range(18, 120, ErrorMessage = "Age must be 18-120")]               │
        // │  public int Age { get; set; }                                       │
        // │                                                                     │
        // │  Age = 5   → INVALID (below minimum)                                │
        // │  Age = 25  → VALID                                                  │
        // │  Age = 150 → INVALID (above maximum)                                │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: If Age=5 and the range is [18, 120], should validation fail?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - entering age below the minimum range
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var ageInput = cut.Find("input[type='number']");
        ageInput.Change("5");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - With Age=5 (below range), is form invalid?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: Range validation should have failed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.IsInvalid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void DataAnnotations_StringLengthValidation()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: [StringLength] Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [StringLength] validates string length with optional minimum:
        //
        // ┌─────────────────────────────────────────────────────────────────────┐
        // │  [StringLength(50, MinimumLength = 2)]                              │
        // │  public string Name { get; set; }                                   │
        // │                                                                     │
        // │  "A"       → INVALID (1 char, below minimum of 2)                   │
        // │  "Al"      → VALID   (2 chars, meets minimum)                       │
        // │  "Alice"   → VALID   (5 chars, within range)                        │
        // └─────────────────────────────────────────────────────────────────────┘
        //
        // EXERCISE: If Name has MinimumLength=2 and you enter "A", is it invalid?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - entering a too-short name
        // ──────────────────────────────────────────────────────────────────────
        var cut = Render<ValidationDemo>();

        var nameInput = cut.Find("input[name='person.Name']");
        nameInput.Change("A");

        var form = cut.Find("form");
        form.Submit();

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - With a 1-char name (min=2), is form invalid?     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: StringLength validation should have failed
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, cut.Instance.IsInvalid);
    }
}
