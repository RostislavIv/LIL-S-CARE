using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Statistic;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethodsAsync();
        Task<IEnumerable<DeliveryMethodDTO>> GetDeliveryMethodsAsync();
        Task<IEnumerable<PromoCodeDTO>> GetPromoCodesAsync(string userId);
        Task<AddressOrderDTO?> GetDefaultAddressAsync(string userId);
        Task<string> CheckoutSaveAsync(OrderDTO checkout, string userId);
        Task<OrderSummaryDTO> OrderSummaryAsync(string orderSNumber);
        Task<OrderDTO> GetOrderAsync(string? userId);
        Task<OrderDTO> CalculateCheckout(OrderDTO order);

        Task<StatisticsModel> GetStatisticsAsync();
    }
}