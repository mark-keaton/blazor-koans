using Bunit;
using BlazorKoans.App.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._07_Validation;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                      CUSTOM VALIDATION ATTRIBUTES                            ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  When built-in attributes aren't enough, create your own validators.        ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  public class MinimumAgeAttribute : ValidationAttribute              │  ║
/// ║  │  {                                                                    │  ║
/// ║  │      private int _minimumAge;                                         │  ║
/// ║  │      public MinimumAgeAttribute(int minimumAge) =&gt;                    │  ║
/// ║  │          _minimumAge = minimumAge;                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │      protected override ValidationResult IsValid(...)                 │  ║
/// ║  │      {                                                                 │  ║
/// ║  │          // Return ValidationResult.Success or new ValidationResult  │  ║
/// ║  │      }                                                                 │  ║
/// ║  │  }                                                                    │  ║
/// ║  │                                                                        │  ║
/// ║  │  Usage: [MinimumAge(18, ErrorMessage = "Must be 18+")]                 │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_CustomValidation : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void CustomValidation_MinimumAgeAttribute()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Custom Attributes Enforce Custom Rules
        // ═══════════════════════════════════════════════════════════════════════
        //
        // [MinimumAge(18)] checks if a birth date makes someone at least 18.
        // It calculates age from the provided DateTime.
        //
        // EXERCISE: Should a 15-year-old FAIL [MinimumAge(18)] validation?
        //           (Answer true if they should fail, false if they should pass)
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a model with a 15-year-old
        // ──────────────────────────────────────────────────────────────────────
        var model = new RegistrationModel
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123",
            BirthDate = DateTime.Today.AddYears(-15),
            AcceptTerms = true
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Should a 15-year-old fail MinimumAge(18)?        ║
        // ║                                                                    ║
        // ║  true = yes they should fail (invalid), false = they should pass   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: !isValid means validation FAILED
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, !isValid);
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void CustomValidation_PassesWhenValid()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Valid Input Passes Custom Validation
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Custom validators return ValidationResult.Success when criteria are met.
        // A 25-year-old should pass [MinimumAge(18)] because 25 >= 18.
        //
        // EXERCISE: Should a 25-year-old PASS [MinimumAge(18)]?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a model with a 25-year-old
        // ──────────────────────────────────────────────────────────────────────
        var model = new RegistrationModel
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123",
            BirthDate = DateTime.Today.AddYears(-25),
            AcceptTerms = true
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Should a 25-year-old pass MinimumAge(18)?        ║
        // ║                                                                    ║
        // ║  true = yes they should pass (valid), false = they should fail     ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: isValid means validation PASSED
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, isValid);
    }
}
