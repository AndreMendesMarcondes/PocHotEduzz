using System.Net.Http.Json;
using PHE.Domain.Domain;
using PHE.Domain.DTO;

namespace PHE.Blazor.Services;

public sealed class ProductApiClient
{
    private readonly HttpClient _httpClient;

    public ProductApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EduzzProductDTO>> GetEduzzProductsAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync("api/product/eduzz", cancellationToken);
        var details = await ReadJsonOrThrowAsync<EduzzProductDetails>(response, cancellationToken);
        return details?.Data ?? [];
    }

    public async Task<List<HotmartProductDetails>> GetHotmartProductsAsync(
        CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync("api/product/hotmart", cancellationToken);
        var products = await ReadJsonOrThrowAsync<List<HotmartProductDetails>>(response, cancellationToken);
        return products ?? [];
    }

    public async Task<HttpResponseMessage> MigrateToEduzzAsync(
        HotmartProduct hotmartProduct,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/product/migrate-to-eduzz");
        request.Content = JsonContent.Create(hotmartProduct);

        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<HttpResponseMessage> MigrateToHotmartAsync(
        EduzzProduct eduzzProduct,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/product/migrate-to-hotmart");
        request.Content = JsonContent.Create(eduzzProduct);

        return await _httpClient.SendAsync(request, cancellationToken);
    }

    private static async Task<T?> ReadJsonOrThrowAsync<T>(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException(
                $"Request failed ({(int)response.StatusCode}): {errorBody}");
        }

        return await response.Content.ReadFromJsonAsync<T>(cancellationToken);
    }
}
