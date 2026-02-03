using System.Text.Json.Serialization;

namespace PHE.Domain.DTO
{
    public sealed class HotmartProductSummary
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public sealed class HotmartProductDetails
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("category")]
        public HotmartCategory? Category { get; set; }

        [JsonPropertyName("subcategory")]
        public HotmartSubcategory? Subcategory { get; set; }

        [JsonPropertyName("contentLocale")]
        public string? ContentLocale { get; set; }

        [JsonPropertyName("targetCountry")]
        public string? TargetCountry { get; set; }

        [JsonPropertyName("affiliationType")]
        public string? AffiliationType { get; set; }

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; }

        [JsonPropertyName("newHotLeads")]
        public bool NewHotLeads { get; set; }

        [JsonPropertyName("urlCoverPhoto")]
        public string? UrlCoverPhoto { get; set; }

        [JsonPropertyName("commission")]
        public HotmartPrice? Commission { get; set; }

        [JsonPropertyName("price")]
        public HotmartPrice? Price { get; set; }

        [JsonPropertyName("producer")]
        public HotmartProducer? Producer { get; set; }

        [JsonPropertyName("reviewRating")]
        public decimal ReviewRating { get; set; }

        [JsonPropertyName("cookieType")]
        public int CookieType { get; set; }

        [JsonPropertyName("affiliateCookieDuration")]
        public int AffiliateCookieDuration { get; set; }

        [JsonPropertyName("salesCheckout")]
        public string? SalesCheckout { get; set; }

        [JsonPropertyName("salesCheckoutRef")]
        public string? SalesCheckoutRef { get; set; }

        [JsonPropertyName("ucode")]
        public string? Ucode { get; set; }

        [JsonPropertyName("distributionForm")]
        public string? DistributionForm { get; set; }

        [JsonPropertyName("allowAffiliationBonus")]
        public bool AllowAffiliationBonus { get; set; }

        [JsonPropertyName("salesPageLink")]
        public string? SalesPageLink { get; set; }

        [JsonPropertyName("pendencies")]
        public HotmartPendencies? Pendencies { get; set; }

        [JsonPropertyName("activationMode")]
        public int ActivationMode { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("paymentMode")]
        public string? PaymentMode { get; set; }

        [JsonPropertyName("personType")]
        public int PersonType { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("pixelEnabled")]
        public bool PixelEnabled { get; set; }

        [JsonPropertyName("widgetCheckoutCode")]
        public string? WidgetCheckoutCode { get; set; }

        [JsonPropertyName("allowsMultiProducerAffiliation")]
        public bool AllowsMultiProducerAffiliation { get; set; }

        [JsonPropertyName("situation")]
        public string? Situation { get; set; }

        [JsonPropertyName("affiliationRequestAction")]
        public string? AffiliationRequestAction { get; set; }

        [JsonPropertyName("warranty")]
        public int Warranty { get; set; }

        [JsonPropertyName("hasCoProduction")]
        public bool HasCoProduction { get; set; }

        [JsonPropertyName("hasSpecialCampaign")]
        public bool HasSpecialCampaign { get; set; }

        [JsonPropertyName("hotMembership")]
        public bool HotMembership { get; set; }

        [JsonPropertyName("creationDate")]
        public long CreationDate { get; set; }

        [JsonPropertyName("hasSmartInstallmentOffer")]
        public bool HasSmartInstallmentOffer { get; set; }

        [JsonPropertyName("supportAffiliateEmail")]
        public string? SupportAffiliateEmail { get; set; }

        [JsonPropertyName("publicProfileLink")]
        public string? PublicProfileLink { get; set; }

        [JsonPropertyName("smartRecoveryConfiguration")]
        public string? SmartRecoveryConfiguration { get; set; }

        [JsonPropertyName("userEligibleToBind")]
        public bool UserEligibleToBind { get; set; }

        [JsonPropertyName("coProducer")]
        public bool CoProducer { get; set; }

        [JsonPropertyName("checkinTerminated")]
        public bool CheckinTerminated { get; set; }

        [JsonPropertyName("affiliate")]
        public bool Affiliate { get; set; }

        [JsonPropertyName("subscription")]
        public bool Subscription { get; set; }

        [JsonPropertyName("owner")]
        public bool Owner { get; set; }
    }

    public sealed class HotmartCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }

    public sealed class HotmartSubcategory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public sealed class HotmartPrice
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }
    }

    public sealed class HotmartProducer
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("ucode")]
        public string? Ucode { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        [JsonPropertyName("userPublicProfileUrl")]
        public string? UserPublicProfileUrl { get; set; }

        [JsonPropertyName("userKey")]
        public string? UserKey { get; set; }
    }

    public sealed class HotmartPendencies
    {
        [JsonPropertyName("content")]
        public bool Content { get; set; }

        [JsonPropertyName("salesPage")]
        public bool SalesPage { get; set; }

        [JsonPropertyName("lotSerial")]
        public bool LotSerial { get; set; }
    }
}
