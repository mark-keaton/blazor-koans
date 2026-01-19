using Bunit;
using BlazorKoans.App.Components.Exercises.Intermediate;
using Xunit;

namespace BlazorKoans.Tests.Intermediate._05_Routing;

public class B_RouteParameters : BunitContext
{
    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_CaptureValueFromUrl()
    {
        // ABOUT: Route parameters like {Id:int} capture values from the URL
        // The :int constraint ensures only integer values are accepted

        // TODO: Replace 0 with the ID value that will be displayed
        // HINT: Look at how the Id parameter is used in ProductPage.razor

        var cut = Render<ProductPage>(parameters =>
            parameters.Add(p => p.Id, 42));

        var expected = 0; // SOLUTION: 42

        cut.MarkupMatches($@"
            <h3>Product Details</h3>
            <p>Product ID: {expected}</p>
        ");
    }

    [Fact]
    [Trait("Category", "Intermediate")]
    public void RouteParameters_DifferentValues()
    {
        // ABOUT: Route parameters can receive different values for each request

        // TODO: Replace 0 with the ID value being passed

        var cut = Render<ProductPage>(parameters =>
            parameters.Add(p => p.Id, 123));

        var expected = 0; // SOLUTION: 123

        cut.MarkupMatches($@"
            <h3>Product Details</h3>
            <p>Product ID: {expected}</p>
        ");
    }
}
