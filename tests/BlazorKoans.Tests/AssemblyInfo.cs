using Xunit;

// Configure test ordering for the koan learning experience
// Tests run in alphabetical order by class name, then by method name
[assembly: TestCaseOrderer("BlazorKoans.Tests.KoanOrderer", "BlazorKoans.Tests")]
[assembly: TestCollectionOrderer("BlazorKoans.Tests.KoanCollectionOrderer", "BlazorKoans.Tests")]
