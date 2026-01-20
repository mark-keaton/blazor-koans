using Xunit.Abstractions;
using Xunit.Sdk;

namespace BlazorKoans.Tests;

/// <summary>
/// Orders test cases by learning path: Beginner → Intermediate → Advanced,
/// then by topic number (01_, 02_), then by method name (A_, B_, C_, D_).
/// </summary>
public class KoanOrderer : ITestCaseOrderer
{
    private static readonly Dictionary<string, int> LevelOrder = new()
    {
        ["Beginner"] = 1,
        ["Intermediate"] = 2,
        ["Advanced"] = 3
    };

    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
        where TTestCase : ITestCase
    {
        return testCases.OrderBy(tc => GetSortKey(tc));
    }

    private static string GetSortKey<TTestCase>(TTestCase tc) where TTestCase : ITestCase
    {
        var typeName = tc.TestMethod.TestClass.Class.Name;
        var methodName = tc.TestMethod.Method.Name;

        // Extract level from namespace (e.g., "BlazorKoans.Tests.Beginner.Components")
        var levelOrder = "9"; // Default to last if not found
        foreach (var level in LevelOrder)
        {
            if (typeName.Contains(level.Key))
            {
                levelOrder = level.Value.ToString();
                break;
            }
        }

        // Sort key: level + class name + method name
        return $"{levelOrder}_{typeName}_{methodName}";
    }
}

/// <summary>
/// Orders test collections by learning path: Beginner → Intermediate → Advanced.
/// </summary>
public class KoanCollectionOrderer : ITestCollectionOrderer
{
    private static readonly Dictionary<string, int> LevelOrder = new()
    {
        ["Beginner"] = 1,
        ["Intermediate"] = 2,
        ["Advanced"] = 3
    };

    public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
    {
        return testCollections.OrderBy(tc => GetSortKey(tc));
    }

    private static string GetSortKey(ITestCollection tc)
    {
        var name = tc.DisplayName;

        foreach (var level in LevelOrder)
        {
            if (name.Contains(level.Key))
            {
                return $"{level.Value}_{name}";
            }
        }

        return $"9_{name}";
    }
}
