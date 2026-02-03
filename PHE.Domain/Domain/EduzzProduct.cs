public class EduzzProduct
{
    public int Active { get; set; } = 1;
    public string Title { get; set; }
    public string Description { get; set; }
    public string FriendlyName { get; set; }
    public string Price { get; set; }
    public int ImageId { get; set; } = 21279273;
    public string Image { get; set; } = "21279273";
    public int CurrencyId { get; set; } = 1;
    public int RefundDays { get; set; }
    public string SupportEmail { get; set; }
    public bool AllowsPix { get; set; } = true;
    public bool AllowsCard { get; set; } = true;
    public bool AllowsBoleto { get; set; } = true;
    public List<int> Categories { get; set; } = new List<int> { 163 };
    public List<string> NullableFields { get; set; } = new List<string>
    {
        "url_thankyou_card", "url_thankyou_boleto", "alternative_url",
        "affiliate_instructions", "affiliation_contract"
    };
}

