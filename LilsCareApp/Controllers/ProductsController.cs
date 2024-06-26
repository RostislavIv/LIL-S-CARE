﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productService;
        private readonly IGuestService _guestService;
        public ProductsController(IProductsService productService, IGuestService guestService)
        {
            _productService = productService;
            _guestService = guestService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int productsPerPage = ProductsPerPages)
        {
            string userId = User.GetUserId();

            ProductsDTO products = await _productService.GetProductsQueryAsync(userId, categoryId, currentPage, productsPerPage);

            return View(products);
        }

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            string userId = User.GetUserId();

            await _productService.AddRemoveWishAsync(productId, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            if (User.GetUserId() != null)
            {
                await _productService.AddToCartAsync(productId, User.GetUserId(), quantity);
            }
            else
            {
                _guestService.AddToCart(productId, quantity);
            }

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            string userId = User.GetUserId();

            if (userId != null)
            {
                await _productService.DeleteProductFromCartAsync(id, userId);
            }
            else
            {
                _guestService.DeleteProductFromCart(id);
            }

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }


    }
}
