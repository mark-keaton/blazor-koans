using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorKoans.App.Models;
using BlazorKoans.App.Services;
using BlazorKoans.Tests.Mocks;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BlazorKoans.Tests.Advanced.HttpClients;

/// <summary>
/// ╔══════════════════════════════════════════════════════════════════════════════╗
/// ║                            HTTP ERROR HANDLING                               ║
/// ╠══════════════════════════════════════════════════════════════════════════════╣
/// ║  HTTP requests can fail for many reasons: network errors, server errors,     ║
/// ║  or invalid responses. Proper error handling is essential for robust apps.   ║
/// ║                                                                              ║
/// ║  ┌────────────────────────────────────────────────────────────────────────┐  ║
/// ║  │  try                                                                   │  ║
/// ║  │  {                                                                     │  ║
/// ║  │      var data = await httpClient.GetFromJsonAsync<T>("api/endpoint"); │  ║
/// ║  │  }                                                                     │  ║
/// ║  │  catch (HttpRequestException ex)                                       │  ║
/// ║  │  {                                                                     │  ║
/// ║  │      // Handle network or HTTP errors                                  │  ║
/// ║  │  }                                                                     │  ║
/// ║  └────────────────────────────────────────────────────────────────────────┘  ║
/// ╚══════════════════════════════════════════════════════════════════════════════╝
/// </summary>
public class D_ErrorHandling : BunitContext
{
    [Fact]
    [Trait("Category", "Advanced")]
    public async Task HttpRequestException_is_thrown_for_network_errors()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: HttpRequestException for Failed Requests
        // ═══════════════════════════════════════════════════════════════════════
        //
        // When HTTP requests fail due to network issues or non-success status
        // codes, HttpRequestException is thrown. This is the primary exception
        // type for HTTP-related failures.
        //
        // EXERCISE: What exception type is thrown when HTTP requests fail?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a fake handler that returns 500 error
        // ──────────────────────────────────────────────────────────────────────
        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather",
            new HttpResponseMessage(HttpStatusCode.InternalServerError));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var service = new WeatherService(httpClient);

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What exception type name is thrown?             ║
        // ║                                                                    ║
        // ║  HINT: Replace "__" with the exception type name as a string       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The correct exception type is thrown
        // ──────────────────────────────────────────────────────────────────────
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var result = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weather");
        });

        Assert.Equal("HttpRequestException", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task EnsureSuccessStatusCode_throws_on_error_responses()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: EnsureSuccessStatusCode Method
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The EnsureSuccessStatusCode method checks if the response status code
        // is in the 2xx range. If not, it throws HttpRequestException. This is
        // useful when you want to fail fast on error responses.
        //
        // EXERCISE: What happens when you call EnsureSuccessStatusCode on a 404?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a fake handler that returns 404 Not Found
        // ──────────────────────────────────────────────────────────────────────
        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather/999",
            new HttpResponseMessage(HttpStatusCode.NotFound));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var response = await httpClient.GetAsync("api/weather/999");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - Does it "throws" or "returns"?                  ║
        // ║                                                                    ║
        // ║  HINT: What behavior do you expect on a non-2xx status code?       ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: EnsureSuccessStatusCode throws on error responses
        // ──────────────────────────────────────────────────────────────────────
        Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        Assert.Equal("throws", answer);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task IsSuccessStatusCode_checks_without_throwing()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: IsSuccessStatusCode Property
        // ═══════════════════════════════════════════════════════════════════════
        //
        // The IsSuccessStatusCode property returns a boolean indicating whether
        // the response has a 2xx status code. Unlike EnsureSuccessStatusCode,
        // it doesn't throw - it just returns true or false.
        //
        // EXERCISE: What does IsSuccessStatusCode return for a 404 response?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a fake handler that returns 404 Not Found
        // ──────────────────────────────────────────────────────────────────────
        var fakeHandler = new FakeHttpMessageHandler();
        fakeHandler.AddResponse("https://api.test.com/api/weather/999",
            new HttpResponseMessage(HttpStatusCode.NotFound));

        var httpClient = new HttpClient(fakeHandler)
        {
            BaseAddress = new Uri("https://api.test.com/")
        };

        var response = await httpClient.GetAsync("api/weather/999");

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What boolean value is returned for 404?         ║
        // ║                                                                    ║
        // ║  HINT: Is 404 a success status code (2xx)?                         ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = false;

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: IsSuccessStatusCode returns false for non-2xx responses
        // ──────────────────────────────────────────────────────────────────────
        Assert.Equal(answer, response.IsSuccessStatusCode);
    }

    [Fact]
    [Trait("Category", "Advanced")]
    public async Task Try_catch_handles_HTTP_errors_gracefully()
    {
        // ═══════════════════════════════════════════════════════════════════════
        // LESSON: Graceful Error Handling with Try-Catch
        // ═══════════════════════════════════════════════════════════════════════
        //
        // Wrapping HTTP calls in try-catch blocks prevents app crashes and allows
        // you to handle errors gracefully. You can log errors, show user-friendly
        // messages, or provide fallback behavior.
        //
        // EXERCISE: What text is contained in the error message for a 503 error?
        // ═══════════════════════════════════════════════════════════════════════

        // ──────────────────────────────────────────────────────────────────────
        // ARRANGE: Setup - creating a fake handler that returns 503 Service Unavailable
        // ──────────────────────────────────────────────────────────────────────
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

        // ╔════════════════════════════════════════════════════════════════════╗
        // ║  ✏️  YOUR ANSWER - What text does the error message contain?       ║
        // ║                                                                    ║
        // ║  HINT: Look for the status code number or description in message   ║
        // ╚════════════════════════════════════════════════════════════════════╝
        var answer = "__";

        // ──────────────────────────────────────────────────────────────────────
        // VERIFY: The error message contains expected text
        // ──────────────────────────────────────────────────────────────────────
        Assert.Contains(answer, errorMessage);
    }
}
