namespace LilsCareApp.Core.Models.Checkout
{
    public class OrderSummaryDTO
    {
        public string? OrderNumber { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? PostCode { get; set; }

        public string? Address { get; set; }

        public string? Town { get; set; }

        public string? District { get; set; }

        public string? Country { get; set; }

        public string? Email { get; set; }

        public bool IsShippingToOffice { get; set; }

        public string? ShippingOfficeCity { get; set; }

        public string? ShippingOfficeAddress { get; set; }

        public string? ShippingProviderName { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string? NoteForDelivery { get; set; }

        public IEnumerable<ProductOrderDTO> Products { get; set; } = [];

        public decimal SubTotal { get; set; }

        public string? PromoCode { get; set; }

        public decimal Discount { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Total { get; set; }

    }
}
