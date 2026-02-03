namespace PHE.Domain.Domain
{
    public class HotmartProduct
    {
        public ProductDetail ProductDetails { get; set; }
        public OfferPayment OfferPayments { get; set; }

        public class ProductDetail
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public CoverPhoto CoverPhoto { get; set; } = new CoverPhoto();
            public Format Format { get; set; } = new Format { Id = "1" };
        }

        public class CoverPhoto
        {
            public int Id { get; set; } = 6238587;
        }

        public class Format { public string Id { get; set; } }

        public class OfferPayment
        {
            public int Warranty { get; set; }
            public string PaymentMode { get; set; } = "PAY_IN_FULL";
            public PaymentDetail Detail { get; set; }
        }

        public class PaymentDetail
        {
            public PriceValue Value { get; set; }
        }

        public class PriceValue
        {
            public string CurrencyCode { get; set; } = "BRL";
            public decimal Value { get; set; }
        }
    }
}
