using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;
using static LilsCareApp.Infrastructure.DataConstants.Order;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Order")]
    public class Order
    {
        [Comment("Order Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Order Number")]
        public string? OrderNumber { get; set; }

        [Comment("Date of Order Creating")]
        public DateTimeOffset CreatedOn { get; set; }

        [Comment("Status of Order")]
        public int StatusOrderId { get; set; }

        [Comment("Navigation Property to StatusOrder")]
        [ForeignKey(nameof(StatusOrderId))]
        public StatusOrder StatusOrder { get; set; } = null!;

        [Comment("Method of Delivery")]
        public int DeliveryMethodId { get; set; }

        [Comment("Navigation Property to DeliveryMethod")]
        [ForeignKey(nameof(DeliveryMethodId))]
        public DeliveryMethod DeliveryMethod { get; set; } = null!;

        [Comment("Address Delivery Id")]
        public int? AddressDeliveryId { get; set; }

        [Comment("Navigation Property to AddressDelivery")]
        [ForeignKey(nameof(AddressDeliveryId))]
        public AddressDelivery AddressDelivery { get; set; } = null!;

        [Comment("App User Id")]
        public string? AppUserId { get; set; }

        [Comment("Navigation Property to AppUser")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser? AppUser { get; set; }

        [Comment("Date of Shipping Creating")]
        public DateTimeOffset? DateShipping { get; set; }

        [Comment("Tracking Number of Order")]
        [MaxLength(TrackingNumberMaxLength)]
        public string? TrackingNumber { get; set; }

        [Comment("Payment Method Id")]
        public int PaymentMethodId { get; set; }

        [Comment("Navigation Property to PaymentMethod")]
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [Comment("Is Paid Order")]
        public bool IsPaid { get; set; }

        [Comment("Navigation Property to Products")]
        public List<ProductOrder> ProductsOrders { get; set; } = [];

        [Comment("Note for Delivery")]
        [MaxLength(NoteForDeliveryMaxLength)]
        public string? NoteForDelivery { get; set; }

        [Comment("Exchange Rate of the Prices")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ExchangeRate { get; set; }

        [Comment("Language of Order, determinate the currency of the prices")]
        [MaxLength(LanguageMaxLength)]
        public required string Currency { get; set; }

        [Comment("Shipping Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingPrice { get; set; }

        [Comment("Absolute Discount value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Comment("Promo Code Id")]
        public int? PromoCodeId { get; set; }

        [Comment("Navigation Property to PromoCode")]
        [ForeignKey(nameof(PromoCodeId))]
        public PromoCode? PromoCode { get; set; }

        [MaxLength(FirstNameMaxLength)]
        [Comment("First Name Recipient")]
        public required string FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("Last Name Recipient")]
        public required string LastName { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Phone Number Recipient")]
        public required string PhoneNumber { get; set; }

        [MaxLength(PostCodeMaxLength)]
        [Comment("Post Code")]
        public string? PostCode { get; set; }

        [MaxLength(AddressMaxLength)]
        [Comment("Address")]
        public string? Address { get; set; }

        [MaxLength(TownMaxLength)]
        [Comment("Town")]
        public string? Town { get; set; }

        [MaxLength(DistrictMaxLength)]
        [Comment("District")]
        public string? District { get; set; }

        [MaxLength(CountryMaxLength)]
        [Comment("Country")]
        public string? Country { get; set; }

        [MaxLength(EmailMaxLength)]
        [Comment("Email")]
        public string? Email { get; set; }

        public int? ShippingOfficeId { get; set; }

        [ForeignKey(nameof(ShippingOfficeId))]
        [Comment("Navigation property to ShippingOffice")]
        public ShippingOffice? ShippingOffice { get; set; }

        public string? ShippingProviderName { get; set; }

        public string? ShippingOfficeCity { get; set; }

        public string? ShippingOfficeAddress { get; set; }
    }

}

