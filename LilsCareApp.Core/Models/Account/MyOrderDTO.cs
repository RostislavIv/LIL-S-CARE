namespace LilsCareApp.Core.Models.Account
{
    public class MyOrderDTO
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string StatusOrder { get; set; } = string.Empty;

        public IEnumerable<MyProductOrderDTO> Products { get; set; } = [];

        public DateTimeOffset? DateShipping { get; set; }

        public string? TrackingNumber { get; set; }

        public string Currency { get; set; } = string.Empty;

        public decimal Discount { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }


    }
}
