using System.Text.Json.Serialization;

namespace PHE.Domain.Domain
{
    public sealed class HotmartProduct
    {
        [JsonPropertyName("productDetail")]
        public ProductDetail ProductDetails { get; set; } = new();

        [JsonPropertyName("offerPayment")]
        public OfferPayment OfferPayments { get; set; } = new();

        public sealed class ProductDetail
        {
            [JsonPropertyName("ucode")]
            public string? Ucode { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            [JsonPropertyName("contentLocale")]
            public string ContentLocale { get; set; } = "PT_BR";

            [JsonPropertyName("targetCountry")]
            public string TargetCountry { get; set; } = "1";

            [JsonPropertyName("category")]
            public int Category { get; set; } = 2;

            [JsonPropertyName("coverPhoto")]
            public CoverPhoto CoverPhoto { get; set; } = new();

            [JsonPropertyName("generatedByAI")]
            public bool GeneratedByAI { get; set; }

            [JsonPropertyName("format")]
            public Format Format { get; set; } = new() { Id = "1" };
        }

        public sealed class CoverPhoto
        {
            [JsonPropertyName("type")]
            public string Type { get; set; } = "image/png";

            [JsonPropertyName("id")]
            public int Id { get; set; } = 6238587;

            [JsonPropertyName("webPath")] 
            public string? WebPath { get; set; } = "https://vulcano.hotmart.com/product_pictures/9508ca93-50b8-4e22-adc7-ccd8eacafaec/henry.png";

            [JsonPropertyName("name")]
            public string? Name { get; set; } = "henry.png";

            [JsonPropertyName("url")]
            public string? Url { get; set; } = "https://vulcano.hotmart.com/product_pictures/9508ca93-50b8-4e22-adc7-ccd8eacafaec/henry.png";

            [JsonPropertyName("size")]
            public int? Size { get; set; } = 121602;

            [JsonPropertyName("contentType")]
            public string? ContentType { get; set; } = "image/png";
        }

        public sealed class Format
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = "1";
        }

        public sealed class OfferPayment
        {
            [JsonPropertyName("warranty")]
            public int Warranty { get; set; }

            [JsonPropertyName("paymentMode")]
            public string PaymentMode { get; set; } = "PAY_IN_FULL";

            [JsonPropertyName("shoppingCartOpenPermanent")]
            public bool? ShoppingCartOpenPermanent { get; set; }

            [JsonPropertyName("checkoutConfiguration")]
            public CheckoutConfiguration CheckoutConfiguration { get; set; } = new();

            [JsonPropertyName("detail")]
            public PaymentDetail Detail { get; set; } = new();
        }

        public sealed class CheckoutConfiguration
        {
            [JsonPropertyName("vatValueEmbedded")]
            public bool VatValueEmbedded { get; set; }
        }

        public sealed class PaymentDetail
        {
            [JsonPropertyName("value")]
            public PriceValue Value { get; set; } = new();

            [JsonPropertyName("installmentCustomizationEnabled")]
            public bool InstallmentCustomizationEnabled { get; set; }

            [JsonPropertyName("disableConversion")]
            public bool DisableConversion { get; set; }

            [JsonPropertyName("activeInstallments")]
            public List<bool> ActiveInstallments { get; set; } = [true];

            [JsonPropertyName("lotOffer")]
            public object LotOffer { get; set; } = new();

            [JsonPropertyName("recoveryWithSmartInstallments")]
            public bool RecoveryWithSmartInstallments { get; set; }

            [JsonPropertyName("smartInstallmentTermsAgreed")]
            public bool SmartInstallmentTermsAgreed { get; set; }

            [JsonPropertyName("maxInstallmentsRecovery")]
            public int? MaxInstallmentsRecovery { get; set; }

            [JsonPropertyName("buyerInstallmentInterestRate")]
            public decimal? BuyerInstallmentInterestRate { get; set; }
        }

        public sealed class PriceValue
        {
            [JsonPropertyName("currencyCode")]
            public string CurrencyCode { get; set; } = "BRL";

            [JsonPropertyName("value")]
            public decimal Value { get; set; }
        }
    }
}
