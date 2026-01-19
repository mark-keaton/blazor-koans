using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

public class D_ErrorHandling : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task HttpRequestException_is_thrown_for_network_errors()
    {
        // ABOUT: When HTTP requests fail, HttpRequestException is thrown.

        // TODO: What exception type is thrown when HTTP requests fail?
        // Replace "__" with the exception type name

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather",
            new HttpResponseMessage(HttpStatusCode.InternalServerError));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var service = new WeatherService(httpClient);

        var expected = "HttpRequestException"; // SOLUTION: "HttpRequestException"

        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");
        });

        Assert.Equal("HttpRequestException", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task EnsureSuccessStatusCode_throws_on_error_responses()
    {
        // ABOUT: EnsureSuccessStatusCode throws if the status code is not 2xx.

        // TODO: Call EnsureSuccessStatusCode on a 404 response.
        // What happens?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather/999",
            new HttpResponseMessage(HttpStatusCode.NotFound));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var response = await httpClient.GetAsync("api/weather/999");

        var expected = "throws"; // SOLUTION: "throws"

        Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        Assert.Equal("throws", expected);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task IsSuccessStatusCode_checks_without_throwing()
    {
        // ABOUT: IsSuccessStatusCode returns bool without throwing exceptions.

        // TODO: Check a 404 response using IsSuccessStatusCode.
        // What value does it return?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather/999",
            new HttpResponseMessage(HttpStatusCode.NotFound));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var response = await httpClient.GetAsync("api/weather/999");

        var expected = false; // SOLUTION: false

        Assert.Equal(expected, response.IsSuccessStatusCode);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task Try_catch_handles_HTTP_errors_gracefully()
    {
        // ABOUT: Wrapping HTTP calls in try-catch prevents app crashes.

        // TODO: Catch HttpRequestException and return a default value.
        // What should the error message contain?

        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather",
            new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        string errorMessage = "";

        try
        {
            var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");
        }
        catch (HttpRequestException ex)
        {
            errorMessage = ex.Message;
        }

        var expected = "503"; // SOLUTION: "503"

        Assert.Contains(expected, errorMessage);
    }
}
