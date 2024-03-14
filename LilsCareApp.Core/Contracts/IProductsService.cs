﻿using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(string userId);
        Task<IEnumerable<ProductDTO>> GetByCategoryAsync(int id, string userId);
        Task<IList<CategoryDTO>> GetCategoriesAsync();
        Task AddToWishAsync(int productId, string userId);
        Task RemoveFromWishAsync(int productId, string userId);
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId);
        Task AddToCartAsync(int productId, string userId, int quantity);
        Task<int> GetCountInBagAsync(string userId);
        Task DeleteProductFromCartAsync(int id, string userId);
        Task<CartDTO> GetProductsInCartAsync(string userId);
        Task<CheckoutDTO> GetCheckout(string userId);
        Task<ShippingProviderDTO?> GetShippingProviderByIdAsync(int shippingProviderId);
        Task<IEnumerable<ShippingProviderDTO>> GetAllShippingProvidersAsync();
    }
}
