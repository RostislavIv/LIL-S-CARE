using LilsCareApp.Core.Models.AdminOrders;
using LilsCareApp.Core.Models.Checkout;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;
using static LilsCareApp.Infrastructure.DataConstants.Order;

namespace LilsCareApp.Core.Models.AdminOrderDetails
{
    public class AdminOrderDetailsDTO
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int StatusOrderId { get; set; }

        public IEnumerable<StatusOrderDTO> StatusesOrder { get; set; } = [];

        public int DeliveryMethodId { get; set; }

        public IEnumerable<DeliveryMethodDTO> DeliveryMethods { get; set; } = [];

        public string? AppUserId { get; set; }

        public string? AppUserName { get; set; }

        public DateTimeOffset? DateShipping { get; set; }


        [MaxLength(TrackingNumberMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(TrackingNumberPattern, ErrorMessage = InvalidField)]
        [Display(Name = "тракинг номер")]
        public string? TrackingNumber { get; set; }

        public int PaymentMethodId { get; set; }

        public IEnumerable<PaymentMethodDTO> PaymentMethods { get; set; } = [];

        public bool IsPaid { get; set; }

        public string? NoteForDelivery { get; set; }

        public decimal ExchangeRate { get; set; }

        public string Currency { get; set; } = string.Empty;

        public decimal ShippingPrice { get; set; }

        [Range(minimum: DiscountMinValue, maximum: DiscountMaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = InvalidField)]
        [Display(Name = "отстъпка")]
        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(FirstNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "име")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(LastNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "фамилия")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(PhoneNumberMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефон")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(CountryMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "държава")]
        public string? Country { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(PostCodeMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "пощенски код")]
        public string? PostCode { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(TownMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "град")]
        public string? Town { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(AddressMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "адрес")]
        public string? Address { get; set; }

        [MaxLength(DistrictMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "район")]
        public string? District { get; set; }

        [MaxLength(EmailMaxLength)]
        [RegularExpression(EmailPatternNotRequired, ErrorMessage = InvalidEmailAddress)]
        [Display(Name = "имейл")]
        public string? Email { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = "куриер")]
        public string? ShippingProviderName { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = "офис")]
        public string? OfficeCity { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = "адрес")]
        public string? OfficeAddress { get; set; }

        public IEnumerable<ProductsOrdersDTO> ProductsOrders { get; set; } = [];

        public IEnumerable<ProductsNamesDTO> Products { get; set; } = [];
    }
}
