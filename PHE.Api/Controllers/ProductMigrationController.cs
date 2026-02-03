using Microsoft.AspNetCore.Mvc;
using PHE.Domain.Domain;

[ApiController]
[Route("minhaapi/produto")]
public class ProductMigrationController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductMigrationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }



    [HttpPost("migrate-to-eduzz")]
    public async Task<IActionResult> MigrateHotmartToEduzz(
        [FromBody] HotmartProduct hotmartData,
        [FromHeader] string eduzzToken)
    {
        var eduzzProduct = MapToEduzz(hotmartData);

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Token", eduzzToken);

        var response = await client.PostAsJsonAsync("https://new.eduzz.com/api/products", eduzzProduct);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            return BadRequest(error);
        }

        return Ok(await response.Content.ReadAsStringAsync());
    }

    private EduzzProduct MapToEduzz(HotmartProduct source)
    {
        return new EduzzProduct
        {
            Title = source.ProductDetails.Name,
            Description = source.ProductDetails.Description,
            Price = source.OfferPayments.Detail.Value.Value.ToString("F2"),
            RefundDays = source.OfferPayments.Warranty,
            FriendlyName = source.ProductDetails.Name.Replace(" ", "").ToLower(),
            Active = 1,
            ImageId = 21279273,
            Image = "21279273",
            //notMappedYet: support_email
            //notMappedYet: categories
        };
    }

    [HttpPost("migrate-to-hotmart")]
    public async Task<IActionResult> MigrateEduzzToHotmart(
        [FromBody] EduzzProduct eduzzData,
        [FromHeader] string hotmartToken)
    {
        var hotmartProduct = MapToHotmart(eduzzData);

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {hotmartToken}");

        var response = await client.PostAsJsonAsync("https://api-product.vulcano.hotmart.com/product/v1/product", hotmartProduct);

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