using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHE.Domain.DTO;
using System.Text.Json;

namespace PHE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static string EduzzToken => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE3NzAxNTM3ODksImN1c3RvbWVyX2lkIjozODUyMjgxMiwiYWNjb3VudHNfaWQiOiI5NjE0MDkyNy02NjYyLTRiMmUtODY2MC1iZDUzNWM2MmYyNmEiLCJvcmlnaW5hbF9jdXN0b21lcl9pZCI6Mzg1MjI4MTIsIm9yaWdpbmFsX2N1c3RvbWVyX2FjY291bnRzX2lkIjoiOTYxNDA5MjctNjY2Mi00YjJlLTg2NjAtYmQ1MzVjNjJmMjZhIiwiaXNfc3VwcG9ydCI6ZmFsc2UsInN1cHBvcnRfaWQiOjB9.5ITlGNvSFJpcg-OPkpUd4HL3OEhywBQDaUPV-6vJZ2Y";

        [HttpGet("eduzz-products")]
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
    }
}
