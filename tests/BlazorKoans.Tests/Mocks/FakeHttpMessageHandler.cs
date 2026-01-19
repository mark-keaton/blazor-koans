using System.Net;
using System.Text.Json;

namespace BlazorKoans.Tests.Mocks;

public class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly Dictionary<string, HttpResponseMessage> _responses = new();
    private Func<HttpRequestMessage, HttpResponseMessage>? _responseFactory;

    public void AddResponse(string url, HttpResponseMessage response)
    {
        _responses[url] = response;
    }

    public void AddJsonResponse<T>(string url, T data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var json = JsonSerializer.Serialize(data);
        var response = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
        };
        _responses[url] = response;
    }

    public void SetResponseFactory(Func<HttpRequestMessage, HttpResponseMessage> factory)
    {
        _responseFactory = factory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (_responseFactory != null)
        {
            return Task.FromResult(_responseFactory(request));
        }

        var url = request.RequestUri?.ToString() ?? "";

        if (_responses.TryGetValue(url, out var response))
        {
            return Task.FromResult(response);
        }

        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent($"No mock response configured for {url}")
        });
    }
}
