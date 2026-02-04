using System.Text.Json.Serialization;

namespace PHE.Domain.DTO
{
    public sealed class EduzzProductDetails
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<EduzzProductDTO> Data { get; set; } = [];

        [JsonPropertyName("pagination")]
        public EduzzPagination? Pagination { get; set; }

        [JsonPropertyName("profiler")]
        public EduzzProfiler? Profiler { get; set; }
    }

    public sealed class EduzzProductDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("details")]
        public string? Details { get; set; }

        [JsonPropertyName("currency")]
        public EduzzCurrency? Currency { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("url_checkout")]
        public string? UrlCheckout { get; set; }
    }

    public sealed class EduzzCurrency
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }
    }

    public sealed class EduzzPagination
    {
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }
    }

    public sealed class EduzzProfiler
    {
        [JsonPropertyName("start")]
        public double Start { get; set; }

        [JsonPropertyName("page")]
        public string? Page { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("finish")]
        public double Finish { get; set; }

        [JsonPropertyName("process")]
        public double Process { get; set; }
    }
}
