﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.AdminOrderDetails;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class AdminOrderDetailsService : IAdminOrderDetailsService
    {
        private readonly ApplicationDbContext _context;

        public AdminOrderDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminOrderDetailsDTO> GetOrderDetailsAsync(int id)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new AdminOrderDetailsDTO
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    CreatedOn = o.CreatedOn,
                    StatusOrderId = o.StatusOrder.Id,
                    AddressDelivery = new DeliveryAddressDTO
                    {
                        AddressId = o.AddressDelivery.Id,
                        FirstName = o.AddressDelivery.FirstName,
                        LastName = o.AddressDelivery.LastName,
                        Country = o.AddressDelivery.Country,
                        PostCode = o.AddressDelivery.PostCode,
                        Town = o.AddressDelivery.Town,
                        Address = o.AddressDelivery.Address,
                        District = o.AddressDelivery.District,
                        Email = o.AddressDelivery.Email,
                        PhoneNumber = o.AddressDelivery.PhoneNumber,
                        ShippingProvider = o.AddressDelivery.ShippingOffice.ShippingProvider.Name,
                        OfficeCity = o.AddressDelivery.ShippingOffice.City,
                        OfficeAddress = o.AddressDelivery.ShippingOffice.OfficeAddress,
                        IsOffice = o.AddressDelivery.IsShippingToOffice
                    },
                    AppUserId = o.AppUserId,
                    DateShipping = o.DateShipping,
                    TrackingNumber = o.TrackingNumber,
                    PaymentMethod = o.PaymentMethod.Type,
                    IsPaid = o.IsPaid,
                    ProductsOrders = o.ProductsOrders
                        .Select(po => new ProductsOrdersDTO
                        {
                            Id = po.Product.Id,
                            Name = po.Product.Name,
                            Quantity = po.Quantity,
                            Price = po.Price,
                            ImageUrl = po.ImagePath,
                            Optional = po.Product.Optional
                        })
                        .ToList(),
                    ShippingPrice = o.ShippingPrice,
                    Discount = o.Discount
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<IEnumerable<ProductsNamesDTO>> GetProductsNameAsync()
        {
            return await _context.Products
                .Select(p => new ProductsNamesDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddTrackingCodeAsync(int id, string trackingNumber)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null || string.IsNullOrEmpty(trackingNumber))
            {
                return;
            }

            order.TrackingNumber = trackingNumber;
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(int id, int statusId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            var status = await _context.StatusOrders
                .Where(s => s.Id == statusId)
                .FirstOrDefaultAsync();

            if (order == null || status == null)
            {
                return;
            }

            order.StatusOrder = status;

            await _context.SaveChangesAsync();
        }

        public async Task ChangePaymentAsync(int id, bool? isPaid)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null || isPaid == null || order.IsPaid == isPaid.Value)
            {
                return;
            }

            order.IsPaid = isPaid.Value;

            await _context.SaveChangesAsync();
        }

        public async Task AddProductToOrderAsync(int id, int productId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            var product = await _context.Products
                .Include(p => p.Images)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            if (order == null || product == null)
            {
                return;
            }

            var productOrder = await _context.ProductsOrders
                .Where(po => po.ProductId == productId && po.OrderId == id)
                .FirstOrDefaultAsync();

            if (productOrder != null)
            {
                productOrder.Quantity++;
            }
            else
            {
                order.ProductsOrders.Add(new ProductOrder
                {
                    Product = product,
                    Quantity = 1,
                    Price = product.Price,
                    ImagePath = product.Images.OrderBy(im => im.ImageOrder).FirstOrDefault().ImagePath
                });
            }

            await _context.SaveChangesAsync();
        }


    }
}
