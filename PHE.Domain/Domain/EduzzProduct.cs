using System.Text.Json.Serialization;

public sealed class EduzzProduct
{
    [JsonPropertyName("active")]
    public int Active { get; set; } = 1;

    [JsonPropertyName("affiliate_instructions")]
    public string AffiliateInstructions { get; set; } = string.Empty;

    [JsonPropertyName("affiliation_contract")]
    public string AffiliationContract { get; set; } = string.Empty;

    [JsonPropertyName("allow_affiliation")]
    public bool AllowAffiliation { get; set; }

    [JsonPropertyName("allows_boleto")]
    public bool AllowsBoleto { get; set; } = true;

    [JsonPropertyName("allows_card")]
    public bool AllowsCard { get; set; } = true;

    [JsonPropertyName("allows_downgrade")]
    public bool AllowsDowngrade { get; set; }

    [JsonPropertyName("allows_eduzz_balance")]
    public bool AllowsEduzzBalance { get; set; }

    [JsonPropertyName("allows_multiple_cards")]
    public bool AllowsMultipleCards { get; set; } = true;

    [JsonPropertyName("allows_paypal")]
    public bool AllowsPaypal { get; set; }

    [JsonPropertyName("allows_pix")]
    public bool AllowsPix { get; set; } = true;

    [JsonPropertyName("allows_combine_payment")]
    public bool AllowsCombinePayment { get; set; } = true;

    [JsonPropertyName("credit_card_installments")]
    public EduzzCreditCardInstallments CreditCardInstallments { get; set; } = new();

    [JsonPropertyName("allows_upgrade")]
    public bool AllowsUpgrade { get; set; }

    [JsonPropertyName("alternative_url")]
    public string AlternativeUrl { get; set; } = string.Empty;

    [JsonPropertyName("ask_address_checkout")]
    public bool AskAddressCheckout { get; set; }

    [JsonPropertyName("ask_address_thanks")]
    public bool AskAddressThanks { get; set; }

    [JsonPropertyName("auto_affiliation")]
    public bool AutoAffiliation { get; set; }

    [JsonPropertyName("auto_refund")]
    public bool AutoRefund { get; set; }

    [JsonPropertyName("beta")]
    public List<object> Beta { get; set; } = [];

    [JsonPropertyName("can_create_pixel")]
    public bool CanCreatePixel { get; set; }

    [JsonPropertyName("categories")]
    public List<int> Categories { get; set; } = [163];

    [JsonPropertyName("charge_type")]
    public string ChargeType { get; set; } = "N";

    [JsonPropertyName("comission_type")]
    public string ComissionType { get; set; } = "P";

    [JsonPropertyName("comission_value")]
    public string ComissionValue { get; set; } = "0.00";

    [JsonPropertyName("connects")]
    public int Connects { get; set; }

    [JsonPropertyName("coproducers")]
    public List<object> Coproducers { get; set; } = [];

    [JsonPropertyName("currency_id")]
    public int CurrencyId { get; set; } = 1;

    [JsonPropertyName("price")]
    public string Price { get; set; } = "0.00";

    [JsonPropertyName("recurring_value")]
    public string RecurringValue { get; set; } = "0.00";

    [JsonPropertyName("recurring_frequency_type")]
    public string RecurringFrequencyType { get; set; } = "M";

    [JsonPropertyName("recurring_frequency")]
    public int RecurringFrequency { get; set; } = 1;

    [JsonPropertyName("undetermined_charges")]
    public bool UndeterminedCharges { get; set; } = true;

    [JsonPropertyName("limit_charges")]
    public int LimitCharges { get; set; } = 2;

    [JsonPropertyName("overdue_limit")]
    public int OverdueLimit { get; set; } = 5;

    [JsonPropertyName("permanent_access")]
    public bool PermanentAccess { get; set; }

    [JsonPropertyName("deliver_first_charge")]
    public bool DeliverFirstCharge { get; set; }

    [JsonPropertyName("deliveries")]
    public List<EduzzDelivery> Deliveries { get; set; } = [new EduzzDelivery()];

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("document_on_checkout")]
    public bool DocumentOnCheckout { get; set; }

    [JsonPropertyName("email_welcome")]
    public bool EmailWelcome { get; set; }

    [JsonPropertyName("friendly_name")]
    public string FriendlyName { get; set; } = string.Empty;

    [JsonPropertyName("funnel_commission")]
    public int FunnelCommission { get; set; }

    [JsonPropertyName("has_children")]
    public bool HasChildren { get; set; }

    [JsonPropertyName("has_expiration_date")]
    public bool HasExpirationDate { get; set; }

    [JsonPropertyName("hide_quantity")]
    public bool HideQuantity { get; set; }

    [JsonPropertyName("image_id")]
    public int ImageId { get; set; } = 21279273;

    [JsonPropertyName("image")]
    public string Image { get; set; } = "21279273";

    [JsonPropertyName("infinity_funnel")]
    public bool InfinityFunnel { get; set; }

    [JsonPropertyName("interest_free_installment")]
    public bool InterestFreeInstallment { get; set; }

    [JsonPropertyName("is_producer")]
    public bool IsProducer { get; set; }

    [JsonPropertyName("marketplace")]
    public bool Marketplace { get; set; }

    [JsonPropertyName("membership_comission_type")]
    public string MembershipComissionType { get; set; } = "P";

    [JsonPropertyName("membership_comission_value")]
    public string MembershipComissionValue { get; set; } = "0.00";

    [JsonPropertyName("membership_fee")]
    public bool MembershipFee { get; set; }

    [JsonPropertyName("membership_price")]
    public string MembershipPrice { get; set; } = "0.00";

    [JsonPropertyName("notify_stock")]
    public int NotifyStock { get; set; }

    [JsonPropertyName("prelaunch")]
    public bool Prelaunch { get; set; }

    [JsonPropertyName("private_label_rights")]
    public int PrivateLabelRights { get; set; }

    [JsonPropertyName("producer_id")]
    public int ProducerId { get; set; }

    [JsonPropertyName("recovery_email")]
    public string RecoveryEmail { get; set; } = "cafecomcodigoconsultoria";

    [JsonPropertyName("recruit_commission_type")]
    public string RecruitCommissionType { get; set; } = "P";

    [JsonPropertyName("recruit_commission_value")]
    public string RecruitCommissionValue { get; set; } = "0.00";

    [JsonPropertyName("recruit_max_sales")]
    public int RecruitMaxSales { get; set; }

    [JsonPropertyName("recruit")]
    public bool Recruit { get; set; }

    [JsonPropertyName("recurring_comission_type")]
    public string RecurringComissionType { get; set; } = "P";

    [JsonPropertyName("recurring_comission_value")]
    public string RecurringComissionValue { get; set; } = "0.00";

    [JsonPropertyName("comission_on_first_invoice")]
    public bool ComissionOnFirstInvoice { get; set; }

    [JsonPropertyName("refund_days")]
    public int RefundDays { get; set; } = 7;

    [JsonPropertyName("remove_access")]
    public bool RemoveAccess { get; set; }

    [JsonPropertyName("sales_expectation")]
    public int SalesExpectation { get; set; }

    [JsonPropertyName("sales_recovery")]
    public bool SalesRecovery { get; set; } = true;

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("support_email")]
    public string SupportEmail { get; set; } = "cafecomcodigoconsultoria@gmail.com";

    [JsonPropertyName("thankyou_type")]
    public int ThankyouType { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("trial_days")]
    public int TrialDays { get; set; } = 1;

    [JsonPropertyName("trial")]
    public bool Trial { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; } = 1;

    [JsonPropertyName("unlimited_installment")]
    public bool UnlimitedInstallment { get; set; }

    [JsonPropertyName("url_thankyou_boleto")]
    public string UrlThankyouBoleto { get; set; } = string.Empty;

    [JsonPropertyName("url_thankyou_card")]
    public string UrlThankyouCard { get; set; } = string.Empty;

    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    [JsonPropertyName("webhook_type")]
    public string WebhookType { get; set; } = "E";

    [JsonPropertyName("webhook")]
    public bool Webhook { get; set; }

    [JsonPropertyName("yearly_installment")]
    public bool YearlyInstallment { get; set; }

    [JsonPropertyName("send_billing_reminder")]
    public bool SendBillingReminder { get; set; }

    [JsonPropertyName("prices")]
    public List<object> Prices { get; set; } = [];

    [JsonPropertyName("plan")]
    public List<object> Plan { get; set; } = [];

    [JsonPropertyName("allow_all_deliveries_for_free_charge_product")]
    public bool AllowAllDeliveriesForFreeChargeProduct { get; set; } = true;

    [JsonPropertyName("nullableFields")]
    public List<string> NullableFields { get; set; } =
        ["url_thankyou_card", "url_thankyou_boleto", "alternative_url", "affiliate_instructions", "affiliation_contract"];
}

public sealed class EduzzCreditCardInstallments
{
    [JsonPropertyName("producer")]
    public bool Producer { get; set; }

    [JsonPropertyName("product")]
    public bool Product { get; set; }
}

public sealed class EduzzDelivery
{
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = "5";

    [JsonPropertyName("files")]
    public List<int> Files { get; set; } = [21279274];
}
