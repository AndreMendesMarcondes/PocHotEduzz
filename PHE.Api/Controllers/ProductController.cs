using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHE.Domain.Domain;
using PHE.Domain.DTO;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PHE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static string EduzzToken => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE3NzAxNjU4OTYsImN1c3RvbWVyX2lkIjozODUyMjgxMiwiYWNjb3VudHNfaWQiOiI5NjE0MDkyNy02NjYyLTRiMmUtODY2MC1iZDUzNWM2MmYyNmEiLCJvcmlnaW5hbF9jdXN0b21lcl9pZCI6Mzg1MjI4MTIsIm9yaWdpbmFsX2N1c3RvbWVyX2FjY291bnRzX2lkIjoiOTYxNDA5MjctNjY2Mi00YjJlLTg2NjAtYmQ1MzVjNjJmMjZhIiwiaXNfc3VwcG9ydCI6ZmFsc2UsInN1cHBvcnRfaWQiOjB9.RdL-nSs_jHaBreBZyxJ8kVV5vE3WkpPb_Xt7CqmHZ6M";
        private static string HotmartToken => "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJUR1QtNjAxNi1tNFk2d3hVS1Z3UHJ1LUVYTUVjTzk2WEVkZ29GVlY4cWliNWx0VGlqNHhVMVkwelo3QW1ZVkk0WlpaQkl0ck1nLVVvLWhvdC1zc28tN2I2NzQ5N2Y3Yy02NzQ0bSIsInNpZCI6IjZkYzEzMTgzLWE4NGMtNDg1YS04MjJkLWIxYzg2MzA0MjcxYiIsImlzcyI6Imh0dHBzOi8vc3NvLmhvdG1hcnQuY29tL29pZGMiLCJhdWQiOlsiZmI1ZTE4YmEtMjAzZi0xMWVhLTk3OGYtMmU3MjhjZTg4MTI1IiwiOGNlZjM2MWItOTRmOC00Njc5LWJkOTItOWQxY2I0OTY0NTJkIl0sImV4cCI6MTc3MDMyNjE0NywiaWF0IjoxNzcwMTUyOTQ3LCJuYmYiOjE3NzAxNTI2NDcsInN1YiI6IjE0MDczMzQ1OCIsImFtciI6WyJIb3RtYXJ0Q3JlZGVudGlhbHNBdXRoZW50aWNhdGlvbkhhbmRsZXIiXSwiY2xpZW50X2lkIjoiOGNlZjM2MWItOTRmOC00Njc5LWJkOTItOWQxY2I0OTY0NTJkIiwiYXV0aF90aW1lIjoxNzcwMTUyOTQ1LCJzdGF0ZSI6IjhkZmY4ZWJlNzU5ZDQwN2M4MGYwOGJiODVmMDllMDQ1IiwiYXRfaGFzaCI6ImYyQjV1bVJScWpnWV9lRTI2MEU4MWciLCJhZGRyZXNzIjp7ImNvdW50cnkiOiJCcmFzaWwiLCJpZCI6MTU1ODc3MzU0fSwiYWRkcmVzc0NvdW50cnkiOiJCcmFzaWwiLCJhZGRyZXNzSWQiOjE1NTg3NzM1NCwiYXV0aG9yaXRpZXMiOlsidmVuZGVkb3IiLCJwcm9kdXRvciIsImNvbXByYWRvciIsIlBMQVRGT1JNX1NJR05VUCIsInVzZXJfYnIiXSwiY3VycmVuY3lDb2RlQ29taXNzaW9uIjoiVVNEIiwiZW1haWwiOiJjYWZlY29tY29kaWdvY29uc3VsdG9yaWFAZ21haWwuY29tIiwiaWQiOiIxNDA3MzM0NTgiLCJsb2NhbGUiOiJQVF9CUiIsImxvZ2luIjoiY2FmZWNvbWNvZGlnb2NvbnN1bHRvcmlhIiwibG9naW5BdHRlbXB0cyI6MCwibmFtZSI6IkFuZHLDqSBNZW5kZXMgTWFyY29uZGVzIiwic2lnbnVwRGF0ZSI6MTc3MDA2Njg5NzAwMCwic3RhdHVzIjoiQXRpdm8iLCJ1Y29kZSI6IjRkNDgyODk4LTQwYTUtNGU1MC1hM2MzLTVmNDRlNzFmNTJhYiIsInByZWZlcnJlZF91c2VybmFtZSI6IjE0MDczMzQ1OCIsInNjb3BlIjpbInVzZXIiLCJhdXRob3JpdGllcyIsImVtYWlsIiwib3BlbmlkIiwicHJvZmlsZSJdLCJhY2Nlc3NfdG9rZW4iOiJBVC0xMDk1MS03dktKWXpocWU0OFh5T3dzNDBsRUdSQVBYMllTcGJidyJ9.bgBagZApx5LQkPflVm-rH4i_jSl_53CsmZK5JcUdNTFDCZ16PKQ8Y-9cD0sAJwTjL4M3u6C6QMnc7SPND7u6Pmu6-zOqFikVcaI0ZFSD_NdGzfcKC5H_T4kvjqUD1bJV2QMrx26geVD7aLm8hEwgQJ67dr1AFRLXSNdTH9amVH1Wram_vwWMT1Z78CBiTiKeX0C0xjnvekrXGi3rCLIbBhfMTZwc0Y8_b90M8TNCoc13ZvB0qvn8CYZFu4pE_fxGONyp0tr15R-jv7dXk7DR4z4mv8a79wY82i5lnxgfBKUmBX6nKCzVAkeKm23D-noYPG68cS_BI6IfehIquNNrcA";

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("eduzz")]
        [ProducesResponseType(typeof(EduzzProductDetails), StatusCodes.Status200OK)]
        public async Task<ActionResult<EduzzProductDetails>> GetEduzzProducts()
        {
            var requestToken = EduzzToken;

            using var client = new HttpClient();
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://new.eduzz.com/api/products?per_page=10&page=1&orderby=created_at-desc&filter_fix_delivery=false");

            request.Headers.Add("Token", requestToken);

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<EduzzProductDetails>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(result);
        }

        [HttpGet("hotmart")]
        [ProducesResponseType(typeof(List<HotmartProductDetails>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HotmartProductDetails>>> GetHotmartProducts()
        {
            var requestToken = $"Bearer {HotmartToken.Trim()}";
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var client = new HttpClient();
            using var listRequest = new HttpRequestMessage(HttpMethod.Get, "https://api-business-workspace.hotmart.com/v1/product/club");
            listRequest.Headers.Add("Authorization", requestToken);

            using var listResponse = await client.SendAsync(listRequest);
            listResponse.EnsureSuccessStatusCode();

            var listJson = await listResponse.Content.ReadAsStringAsync();
            var summaries = JsonSerializer.Deserialize<List<HotmartProductSummary>>(listJson, serializerOptions) ?? [];
            var details = new List<HotmartProductDetails>(summaries.Count);

            foreach (var summary in summaries)
            {
                using var detailRequest = new HttpRequestMessage(
                    HttpMethod.Get,
                    $"https://api-vlc.hotmart.com/marketplace/rest/v2/product/{summary.Id}");
                detailRequest.Headers.Add("Authorization", requestToken);

                using var detailResponse = await client.SendAsync(detailRequest);
                detailResponse.EnsureSuccessStatusCode();

                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var detail = JsonSerializer.Deserialize<HotmartProductDetails>(detailJson, serializerOptions);
                if (detail != null)
                {
                    details.Add(detail);
                }
            }

            return Ok(details);
        }

        [HttpPost("migrate-to-eduzz")]
        public async Task<IActionResult> MigrateHotmartToEduzz(
        [FromBody] HotmartProduct hotmartData)
        {
            var eduzzProduct = MapToEduzz(hotmartData);
            var json = JsonSerializer.Serialize(eduzzProduct);

            using var client = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://new.eduzz.com/api/products");

            request.Headers.Add("Token", $"{EduzzToken}");
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

            return Ok(await response.Content.ReadAsStringAsync());
        }

        private EduzzProduct MapToEduzz(HotmartProduct source)
        {
            var title = source.ProductDetails?.Name ?? "hotmart-product";
            title = EnsureUniqueTitle(title);

            var description = source.ProductDetails?.Description ?? string.Empty;
            var priceValue = source.OfferPayments?.Detail?.Value?.Value ?? 0m;

            return new EduzzProduct
            {
                Title = title,
                Description = description,
                Price = priceValue.ToString("F2", CultureInfo.InvariantCulture),
                RefundDays = source.OfferPayments?.Warranty ?? 7,
                FriendlyName = ToFriendlyName(title),
                SupportEmail = "cafecomcodigoconsultoria@gmail.com",
                RecoveryEmail = "cafecomcodigoconsultoria",
                ImageId = 21279273,
                Image = "21279273",
                Deliveries = [new EduzzDelivery { MethodId = "5", Files = [21279274] }]
            };
        }

        private static string ToFriendlyName(string title)
        {
            var cleaned = Regex.Replace(title.ToLowerInvariant(), "[^a-z0-9]", string.Empty);

            if (cleaned.Length > 10)
                cleaned = cleaned.Substring(0, 9);

            return string.IsNullOrWhiteSpace(cleaned) ? "product" : cleaned;
        }

        private static string EnsureUniqueTitle(string title)
        {
            var trimmed = title.Trim();
            var match = Regex.Match(trimmed, @"\s(\d+)$");
            if (match.Success && int.TryParse(match.Groups[1].Value, out var number))
            {
                return $"{trimmed[..match.Index]} {number + 1}";
            }

            return $"{trimmed} 2";
        }

        [HttpPost("migrate-to-hotmart")]
        public async Task<IActionResult> MigrateEduzzToHotmart([FromBody] EduzzProduct eduzzData)
        {
            var hotmartProduct = MapToHotmart(eduzzData);
            var json = JsonSerializer.Serialize(hotmartProduct);

            using var client = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api-product.vulcano.hotmart.com/product/v1/product");

            request.Headers.Add("Authorization", $"Bearer {HotmartToken}");
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

            return Ok(await response.Content.ReadAsStringAsync());
        }

        private HotmartProduct MapToHotmart(EduzzProduct source)
        {
            return new HotmartProduct
            {
                ProductDetails = new HotmartProduct.ProductDetail
                {
                    Name = source.Title,
                    Description = source.Description,
                    CoverPhoto = new HotmartProduct.CoverPhoto { Id = 6238587 }
                },
                OfferPayments = new HotmartProduct.OfferPayment
                {
                    Warranty = source.RefundDays,
                    Detail = new HotmartProduct.PaymentDetail
                    {
                        Value = new HotmartProduct.PriceValue
                        {
                            Value = decimal.Parse(source.Price)
                        }
                    }
                }
            };
        }
    }
}
