﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ApplicationDbContext _context;

        public CheckoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddressDeliveryDTO?> GetAddressDeliveryAsync(string userId)
        {

            var addressDelivery = await _context.Users
                .Where(u => u.Id == userId && u.DefaultAddressDeliveryId != null)
                .Select(ad => new AddressDeliveryDTO()
                {
                    Id = ad.DefaultAddressDelivery.Id,
                    FirstName = ad.DefaultAddressDelivery.FirstName,
                    LastName = ad.DefaultAddressDelivery.LastName,
                    Country = ad.DefaultAddressDelivery.Country,
                    PostCode = ad.DefaultAddressDelivery.PostCode,
                    Town = ad.DefaultAddressDelivery.Town,
                    Address = ad.DefaultAddressDelivery.Address,
                    District = ad.DefaultAddressDelivery.District,
                    PhoneNumber = ad.DefaultAddressDelivery.PhoneNumber,
                    IsShippingToOffice = ad.DefaultAddressDelivery.IsShippingToOffice,
                    ShippingOfficeId = ad.DefaultAddressDelivery.ShippingOfficeId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (addressDelivery != null)
            {
                if (addressDelivery.IsShippingToOffice)
                {
                    addressDelivery.ShippingOffice = await _context.ShippingOffices
                        .Where(so => so.Id == addressDelivery.ShippingOfficeId)
                        .Select(so => new ShippingOfficeDTO()
                        {
                            Id = so.Id,
                            City = so.City,
                            OfficeAddress = so.OfficeAddress,
                            Price = so.Price,
                            ShippingDuration = so.ShippingDuration,
                        })
                        .AsNoTracking()
                        .FirstOrDefaultAsync();


                    addressDelivery.ShippingOffice.ShippingProviderId = await _context.ShippingProviders
                                .Where(sp => sp.ShippingOffices.Any(so => so.Id == addressDelivery.ShippingOfficeId))
                                .Select(sp => sp.Id)
                                .FirstOrDefaultAsync();

                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.PhoneNumber != null
                                         && addressDelivery.ShippingOffice != null;
                }
                else
                {
                    addressDelivery.IsValid = addressDelivery.FirstName != null
                                         && addressDelivery.LastName != null
                                         && addressDelivery.Country != null
                                         && addressDelivery.PostCode != null
                                         && addressDelivery.Town != null
                                         && addressDelivery.Address != null;
                }

            }
            return addressDelivery;
        }

        public async Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync()
        {
            var shippingProviders = await _context.ShippingProviders
                .Select(sp => new ShippingProviderDTO()
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Description = "доставка до офис на " + sp.Name
                })
                .AsNoTracking()
                .ToListAsync();
            shippingProviders.Add(new ShippingProviderDTO()
            {
                Id = 0,
                Name = "доставка до адрес на клиент",
                Description = "доставка до адрес на клиент"
            });
            return shippingProviders.OrderBy(sp => sp.Id);
        }

        public async Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId)
        {
            return await _context.ShippingOffices
                .Where(so => so.ShippingProviderId == shippingProvidersId)
                .Select(so => so.City)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId)
        {
            return await _context.ShippingOffices
                .Where(so => so.City == city && so.ShippingProviderId == shippingProviderId)
                .Select(so => new ShippingOfficeDTO()
                {
                    Id = so.Id,
                    City = so.City,
                    OfficeAddress = so.OfficeAddress,
                    Price = so.Price,
                    ShippingDuration = so.ShippingDuration,
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<string> CheckoutSaveAsync(OrderDTO checkout, string userId)
        {
            // get user
            AppUser appUser = await _context.Users.FirstAsync(u => u.Id == userId);

            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AppUser = appUser,
                PaymentMethodId = checkout.PaymentMethodId,
                NoteForDelivery = checkout.NoteForDelivery,
                ProductsOrders = new List<ProductOrder>(),
                PromoCodeId = checkout.PromoCodeId,
                ShippingPrice = checkout.ShippingPrice() ?? 0

            };

            // add products to order
            foreach (var product in checkout.ProductsInBag)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    ImagePath = await _context.ImageProducts
                        .Where(ip => ip.Id == product.Id)
                        .Select(ip => ip.ImagePath)
                        .AsNoTracking()
                        .FirstOrDefaultAsync()
                };
                order.ProductsOrders.Add(productOrder);
            }


            // check for existing address delivery
            AddressDelivery addressDelivery = await _context.AddressDeliveries.FirstOrDefaultAsync(ad => ad.Id == checkout.AddressDelivery.Id);

            if (addressDelivery is null) // if not existing address create new address delivery
            {
                addressDelivery = new AddressDelivery()
                {
                    FirstName = checkout.AddressDelivery.FirstName,
                    LastName = checkout.AddressDelivery.LastName,
                    PhoneNumber = checkout.AddressDelivery.PhoneNumber,
                    Country = checkout.AddressDelivery.Country,
                    PostCode = checkout.AddressDelivery.PostCode,
                    Town = checkout.AddressDelivery.Town,
                    Address = checkout.AddressDelivery.Address,
                    District = checkout.AddressDelivery.District,
                    IsShippingToOffice = checkout.AddressDelivery.IsShippingToOffice,
                    ShippingOfficeId = checkout.AddressDelivery.ShippingOffice?.Id,
                    AppUser = appUser

                };
            };

            // add address delivery to order
            order.AddressDelivery = addressDelivery;

            // add order to user
            await _context.Orders.AddAsync(order);

            // set new default address delivery to user
            appUser.DefaultAddressDelivery = addressDelivery;

            // remove products from user's bag
            IEnumerable<BagUser> bagUsers = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .ToListAsync();

            _context.RemoveRange(bagUsers);

            await _context.SaveChangesAsync();

            // return unique order number to user
            Random random = new Random();

            order.OrderNumber = random.Next(10, 99).ToString() + order.Id.ToString() + random.Next(10, 99).ToString();

            await _context.SaveChangesAsync();

            return order.OrderNumber;
        }

        public async Task<OrderSummaryDTO> OrderSummaryAsync(string orderSNumber)
        {
            OrderSummaryDTO? orderSummary = await _context.Orders
                .Where(o => o.OrderNumber == orderSNumber)
                .Select(o => new OrderSummaryDTO()
                {
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.CreatedOn,
                    FirstName = o.AddressDelivery.FirstName,
                    LastName = o.AddressDelivery.LastName,
                    PhoneNumber = o.AddressDelivery.PhoneNumber,
                    PostCode = o.AddressDelivery.PostCode,
                    Address = o.AddressDelivery.Address,
                    Town = o.AddressDelivery.Town,
                    District = o.AddressDelivery.District,
                    Country = o.AddressDelivery.Country,
                    IsShippingToOffice = o.AddressDelivery.IsShippingToOffice,
                    ShippingProviderName = o.AddressDelivery.ShippingOffice.ShippingProvider.Name,
                    ShippingOfficeCity = o.AddressDelivery.ShippingOffice.City,
                    ShippingOfficeAddress = o.AddressDelivery.ShippingOffice.OfficeAddress,
                    PaymentMethod = o.PaymentMethod.Type,
                    NoteForDelivery = o.NoteForDelivery,
                    Products = o.ProductsOrders
                        .Select(po => new ProductOrderDTO()
                        {
                            Id = po.Product.Id,
                            Name = po.Product.Name,
                            Description = po.Product.Description,
                            ImagePath = po.ImagePath,
                            Quantity = po.Quantity,
                            Price = po.Price,
                        }),
                    PromoCode = o.PromoCode == null ? null : o.PromoCode.Code,
                    Discount = o.PromoCode == null ? 0 : o.PromoCode.Discount,
                    ShippingPrice = o.ShippingPrice
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            orderSummary.SubTotal = orderSummary.Products.Sum(p => p.Quantity * p.Price);
            orderSummary.Total = orderSummary.SubTotal - (orderSummary.SubTotal * orderSummary.Discount) + orderSummary.ShippingPrice;

            return orderSummary;
        }
    }
}

