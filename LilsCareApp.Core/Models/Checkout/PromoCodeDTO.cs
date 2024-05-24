namespace LilsCareApp.Core.Models.Checkout
{
    public class PromoCodeDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
    }
}