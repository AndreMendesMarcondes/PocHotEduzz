using Microsoft.AspNetCore.Mvc;
using PHE.Domain.Domain;
using PHE.Domain.DTO;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PHE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static string EduzzToken => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE3NzAyMTIzNTYsImN1c3RvbWVyX2lkIjozODUyMjgxMiwiYWNjb3VudHNfaWQiOiI5NjE0MDkyNy02NjYyLTRiMmUtODY2MC1iZDUzNWM2MmYyNmEiLCJvcmlnaW5hbF9jdXN0b21lcl9pZCI6Mzg1MjI4MTIsIm9yaWdpbmFsX2N1c3RvbWVyX2FjY291bnRzX2lkIjoiOTYxNDA5MjctNjY2Mi00YjJlLTg2NjAtYmQ1MzVjNjJmMjZhIiwiaXNfc3VwcG9ydCI6ZmFsc2UsInN1cHBvcnRfaWQiOjB9.WbV8hZeXaxIPSa4p_7Hurq180Rw9qRGn31Cm8StH9wQ";
        private static string HotmartToken => "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJUR1QtMjM5MDYtTWo5b0RiRVlDRkxPUkQ5LUgyWTFicmFwUXE3SjFUUkdUZzBWZVBDWkxSR2l0WE84UVJwLW8wZ2NvYTJZa3NxNVM2RS1ob3Qtc3NvLTdiNjc0OTdmN2MtY2w2cnoiLCJzaWQiOiI4NTllZDc3ZC0zMjAxLTQ5M2MtYjZiZi05NDI4YzJiMGRiMWEiLCJpc3MiOiJodHRwczovL3Nzby5ob3RtYXJ0LmNvbS9vaWRjIiwiYXVkIjpbImZiNWUxOGJhLTIwM2YtMTFlYS05NzhmLTJlNzI4Y2U4ODEyNSIsIjhjZWYzNjFiLTk0ZjgtNDY3OS1iZDkyLTlkMWNiNDk2NDUyZCJdLCJleHAiOjE3NzAzODE5NzcsImlhdCI6MTc3MDIwODc3NywibmJmIjoxNzcwMjA4NDc3LCJzdWIiOiIxNDA3MzM0NTgiLCJhbXIiOlsiSG90bWFydENyZWRlbnRpYWxzQXV0aGVudGljYXRpb25IYW5kbGVyIl0sImNsaWVudF9pZCI6IjhjZWYzNjFiLTk0ZjgtNDY3OS1iZDkyLTlkMWNiNDk2NDUyZCIsImF1dGhfdGltZSI6MTc3MDIwODc3NSwic3RhdGUiOiI5MGNhNTNhODg1OWE0MmZhYjQ2MzdlMGVkM2IwZDQzNyIsImF0X2hhc2giOiJ1VHAta0UyanVSUlcySkdzV1p3cWJRIiwiYWRkcmVzcyI6eyJjb3VudHJ5IjoiQnJhc2lsIiwiaWQiOjE1NTg3NzM1NH0sImFkZHJlc3NDb3VudHJ5IjoiQnJhc2lsIiwiYWRkcmVzc0lkIjoxNTU4NzczNTQsImF1dGhvcml0aWVzIjpbInZlbmRlZG9yIiwicHJvZHV0b3IiLCJjb21wcmFkb3IiLCJQTEFURk9STV9TSUdOVVAiLCJ1c2VyX2JyIl0sImN1cnJlbmN5Q29kZUNvbWlzc2lvbiI6IlVTRCIsImVtYWlsIjoiY2FmZWNvbWNvZGlnb2NvbnN1bHRvcmlhQGdtYWlsLmNvbSIsImlkIjoiMTQwNzMzNDU4IiwibG9jYWxlIjoiUFRfQlIiLCJsb2dpbiI6ImNhZmVjb21jb2RpZ29jb25zdWx0b3JpYSIsImxvZ2luQXR0ZW1wdHMiOjAsIm5hbWUiOiJBbmRyw6kgTWVuZGVzIE1hcmNvbmRlcyIsInNpZ251cERhdGUiOjE3NzAwNjY4OTcwMDAsInN0YXR1cyI6IkF0aXZvIiwidWNvZGUiOiI0ZDQ4Mjg5OC00MGE1LTRlNTAtYTNjMy01ZjQ0ZTcxZjUyYWIiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiIxNDA3MzM0NTgiLCJzY29wZSI6WyJ1c2VyIiwiYXV0aG9yaXRpZXMiLCJlbWFpbCIsIm9wZW5pZCIsInByb2ZpbGUiXSwiYWNjZXNzX3Rva2VuIjoiQVQtNDIxNjItN20zSjA4ZWh3Nzh3djdBcm5ZMEEtZ2xLRGFoZEJOTE4ifQ.EhKEWiazaxMKoezo1yLLIO-FcBxBtS4iyposqHxHDDJ1M8BmKNvyuNZh2vWNMWLuTlBoxSbG2HO1AEByvgP-WyX2jAu4RN9rft4qd_CfCwl7xYqt_2Awkcde-M4MPA7-Q4I2N3hhEHX8exM-jmCy3r43IxmZ18AIKcilcxJWHGGInedIxZ7ZqNljQiG_Yr0HMU4Aqpsyx4urmOdlXBmoorHajp3e5k2Y-qREx7rECB4mgN_gs5cgZw74--1Tp5KbBAUbd5CGS4aJjnHQorBIjWPMMf1_VCfmMxyZFvp7oFD43F9C9E2Xm0tUvfZ9B4MDuPUetkJCorr1L2TdGz6S2Q";

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
                if (detail != null && (!String.IsNullOrWhiteSpace(detail.Status) && detail.Status != "DELETED"))
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
            var title = EnsureUniqueTitle(source.Title);
            var priceValue = ParsePrice(source.Price);

            return new HotmartProduct
            {
                ProductDetails = new HotmartProduct.ProductDetail
                {
                    Ucode = Guid.NewGuid().ToString(), 
                    Name = title,
                    Description = EnsureMinDescription(source.Description),
                    ContentLocale = "PT_BR",
                    TargetCountry = "1",
                    Category = 2,
                    GeneratedByAI = false,
                    CoverPhoto = new HotmartProduct.CoverPhoto
                    {
                        Id = 6238587,
                        Type = "image/png"
                    },
                    Format = new HotmartProduct.Format { Id = "1" }
                },
                OfferPayments = new HotmartProduct.OfferPayment
                {
                    Warranty = source.RefundDays,
                    PaymentMode = "PAY_IN_FULL",
                    CheckoutConfiguration = new HotmartProduct.CheckoutConfiguration
                    {
                        VatValueEmbedded = false
                    },
                    Detail = new HotmartProduct.PaymentDetail
                    {
                        Value = new HotmartProduct.PriceValue
                        {
                            CurrencyCode = "BRL",
                            Value = priceValue
                        },
                        InstallmentCustomizationEnabled = false,
                        DisableConversion = false,
                        ActiveInstallments = [true],
                        LotOffer = new object(),
                        RecoveryWithSmartInstallments = false,
                        SmartInstallmentTermsAgreed = false
                    }
                }
            };
        }

        private static string EnsureMinDescription(string? description)
        {
            var normalized = description ?? string.Empty;
            return normalized.Length >= 201 ? normalized : normalized.PadRight(201, '.');
        }

        private static decimal ParsePrice(string? price)
        {
            if (string.IsNullOrWhiteSpace(price))
            {
                return 0m;
            }

            return decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed)
                ? parsed
                : decimal.TryParse(price, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out parsed)
                    ? parsed
                    : 0m;
        }
    }
}
