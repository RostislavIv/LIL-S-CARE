using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Statistic;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppConfigService _appConfigService;
        private readonly IHttpContextManager _httpContextManager;
        private readonly IAccountService _accountService;
        public CheckoutService(
            ApplicationDbContext context,
            IAppConfigService appConfigService,
            IHttpContextManager httpContextManager,
            IAccountService accountService)
        {
            _context = context;
            _appConfigService = appConfigService;
            _httpContextManager = httpContextManager;
            _accountService = accountService;
        }

        public async Task<OrderDTO> GetOrderAsync(string? userId)
        {
            OrderDTO order = new OrderDTO()
            {
                AppUserId = userId ?? string.Empty,
                PaymentMethodId = 1,
                PaymentMethods = await GetPaymentMethodsAsync(),
                DeliveryMethodId = 0,
                DeliveryMethods = await GetDeliveryMethodsAsync(),
                PromoCodeId = 0,
                PromoCodes = userId != null ? await GetPromoCodesAsync(userId) : [],
                NoteForDelivery = string.Empty,
                IsSelectedAddress = false,
                Discount = 0,
                SubTotal = 0,
                Total = 0,
                ShippingPrice = 0,
                Address = new AddressOrderDTO()
            };

            if (userId != null)
            {
                var address = await GetDefaultAddressAsync(userId);

                if (address != null)
                {
                    order.DeliveryMethodId = address.DeliveryMethodId;
                    order.Address = address;
                    order.IsSelectedAddress = true;
                }
            }

            return order;
        }


        // get all payment methods 
        public async Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethodsAsync()
        {
            var language = _httpContextManager.GetLanguage();

            return await _context.PaymentMethods
                .Select(pm => new PaymentMethodDTO()
                {
                    Id = pm.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, pm.Name.NameBG },
                        { Romanian, pm.Name.NameRO },
                        { English, pm.Name.NameEN }
                    }[language]
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<DeliveryMethodDTO>> GetDeliveryMethodsAsync()
        {
            var language = _httpContextManager.GetLanguage();

            return await _context.DeliveryMethods
                .Select(dm => new DeliveryMethodDTO()
                {
                    Id = dm.Id,
                    Name = new Dictionary<string, string>
                    {
                        { Bulgarian, dm.Name.NameBG },
                        { Romanian, dm.Name.NameRO },
                        { English, dm.Name.NameEN }
                    }[language]
                })
                .AsNoTracking()
                .ToListAsync();
        }

        // get all promo codes for user witch are not expired and not already applied
        public async Task<IEnumerable<PromoCodeDTO>> GetPromoCodesAsync(string userId)
        {
            var language = _httpContextManager.GetLanguage();

            return await _context.PromoCodes
                .Where(pc => pc.AppUserId == userId
                    && pc.ExpirationDate >= DateTime.UtcNow
                    && pc.AppliedDate == null)
                .Select(pc => new PromoCodeDTO()
                {
                    Id = pc.Id,
                    Code = new Dictionary<string, string>
                    {
                        { Bulgarian, pc.Code.NameBG },
                        { Romanian, pc.Code.NameRO },
                        { English, pc.Code.NameEN }
                    }[language],
                    Discount = pc.Discount,
                    ExpirationDate = pc.ExpirationDate
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AddressOrderDTO?> GetDefaultAddressAsync(string userId)
        {
            var address = await _context.AddressDeliveries
                .Where(ad => ad.AppUserId == userId && !ad.IsDeleted && ad.IsDefault)
                .Select(ad => new AddressOrderDTO()
                {
                    Id = ad.Id,
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    PhoneNumber = ad.PhoneNumber,
                    PostCode = ad.PostCode ?? string.Empty,
                    Address = ad.Address ?? string.Empty,
                    Town = ad.Town ?? string.Empty,
                    District = ad.District ?? string.Empty,
                    Country = ad.Country ?? string.Empty,
                    Email = ad.Email ?? string.Empty,
                    DeliveryMethodId = ad.IsShippingToOffice ? 1 : 2,
                    ShippingOfficeId = ad.ShippingOfficeId,
                    ShippingOffice = ad.ShippingOffice != null ? new ShippingOfficeDTO()
                    {
                        Id = ad.ShippingOffice.Id,
                        ShippingProviderId = ad.ShippingOffice.ShippingProviderId,
                        ShippingProviderName = ad.ShippingOffice.ShippingProvider.Name,
                        City = ad.ShippingOffice.City,
                        OfficeAddress = ad.ShippingOffice.OfficeAddress,
                        Price = ad.ShippingOffice.Price,
                        ShippingDuration = ad.ShippingOffice.ShippingDuration,
                    } : null,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return address;
        }

        // Save order to database and return unique order number.
        // Set default address delivery to User.
        // Remove products from user's bag.
        // Remove ordered quantity from products store
        // Set the applied date to promo code if is applied.
        // Return unique order number to user.
        public async Task<string> CheckoutSaveAsync(OrderDTO orderDTO, string userId)
        {
            // get user
            AppUser appUser = await _context.Users.FirstAsync(u => u.Id == userId);

            Order order = new Order()
            {
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                DeliveryMethodId = orderDTO.DeliveryMethodId,
                AddressDeliveryId = orderDTO.Address.Id > 0 ? orderDTO.Address.Id : null,
                AppUserId = userId,
                PaymentMethodId = orderDTO.PaymentMethodId,
                IsPaid = false,
                NoteForDelivery = orderDTO.NoteForDelivery,
                ShippingPrice = orderDTO.ShippingPrice,
                Discount = orderDTO.Discount,
                PromoCodeId = orderDTO.PromoCodeId > 0 ? orderDTO.PromoCodeId : null,
                FirstName = orderDTO.Address.FirstName,
                LastName = orderDTO.Address.LastName,
                PhoneNumber = orderDTO.Address.PhoneNumber,
                PostCode = orderDTO.Address.PostCode,
                Address = orderDTO.Address.Address,
                Town = orderDTO.Address.Town,
                District = orderDTO.Address.District,
                Country = orderDTO.Address.Country,
                Email = orderDTO.Address.Email,
                ShippingOfficeId = orderDTO.Address.ShippingOfficeId,
                ShippingProviderName = orderDTO.Address.ShippingOffice?.ShippingProviderName,
                ShippingOfficeCity = orderDTO.Address.ShippingOffice?.City,
                ShippingOfficeAddress = orderDTO.Address.ShippingOffice?.OfficeAddress,
                ExchangeRate = orderDTO.ExchangeRate,
                Currency = new Dictionary<string, string>
                            {
                                { Bulgarian, "лв." },
                                { Romanian, "Lei" },
                                { English, "€" }
                            }[orderDTO.Language],
                ProductsOrders = [],
            };

            // add products to order
            foreach (var product in orderDTO.ProductsInBag)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    ImagePath = await _context.ImageProducts
                        .Where(ip => ip.ProductId == product.Id)
                        .Select(ip => ip.ImagePath)
                        .AsNoTracking()
                        .FirstOrDefaultAsync()
                };
                order.ProductsOrders.Add(productOrder);
            }


            // add order to user
            await _context.Orders.AddAsync(order);

            // set default address delivery to user
            if (appUser != null)
            {
                if (orderDTO.Address.Id > 0)
                {
                    var address = await _context.AddressDeliveries
                        .FirstOrDefaultAsync(ad => ad.Id == orderDTO.Address.Id);

                    if (address != null && address.AppUserId == userId)
                    {
                        address.FirstName = orderDTO.Address.FirstName;
                        address.LastName = orderDTO.Address.LastName;
                        address.PhoneNumber = orderDTO.Address.PhoneNumber;
                        address.PostCode = orderDTO.Address.PostCode;
                        address.Address = orderDTO.Address.Address;
                        address.Town = orderDTO.Address.Town;
                        address.District = orderDTO.Address.District;
                        address.Country = orderDTO.Address.Country;
                        address.Email = orderDTO.Address.Email ?? appUser.Email;
                        address.IsShippingToOffice = orderDTO.Address.DeliveryMethodId == 1;
                        address.ShippingOfficeId = orderDTO.Address.ShippingOfficeId;
                    }
                }
                else
                {
                    AddressDelivery address = new()
                    {
                        FirstName = orderDTO.Address.FirstName,
                        LastName = orderDTO.Address.LastName,
                        PhoneNumber = orderDTO.Address.PhoneNumber,
                        PostCode = orderDTO.Address.PostCode,
                        Address = orderDTO.Address.Address,
                        Town = orderDTO.Address.Town,
                        District = orderDTO.Address.District,
                        Country = orderDTO.Address.Country,
                        Email = orderDTO.Address.Email,
                        IsShippingToOffice = orderDTO.Address.DeliveryMethodId == 1,
                        ShippingOfficeId = orderDTO.Address.ShippingOfficeId,
                        AppUserId = userId,
                    };

                    await _context.AddressDeliveries.AddAsync(address);
                    await _context.SaveChangesAsync();
                    await _accountService.SetDefaultAddressAsync(userId, address.Id);
                }
            }


            // remove products from user's bag
            IEnumerable<BagUser> bagUsers = await _context.BagsUsers
                .Where(bu => bu.AppUserId == userId)
                .ToListAsync();

            _context.BagsUsers.RemoveRange(bagUsers);

            //remove ordered quantity from products store
            foreach (var bagUser in bagUsers)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == bagUser.ProductId);
                if (product != null)
                {
                    product.Quantity -= bagUser.Quantity;
                }
            }

            // set the applied date to promo code if is applied
            var promoCode = await _context.PromoCodes.FirstOrDefaultAsync(pc => pc.Id == order.PromoCodeId);

            if (promoCode != null)
            {
                promoCode.AppliedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            // return unique order number to user
            Random random = new Random();

            order.OrderNumber = random.Next(10, 99).ToString() + order.Id.ToString() + random.Next(10, 99).ToString();

            await _context.SaveChangesAsync();

            return order.OrderNumber;
        }



        // get order summary by order number
        public async Task<OrderSummaryDTO> OrderSummaryAsync(string orderNumber)
        {
            var language = _httpContextManager.GetLanguage();

            var orderSummary = await _context.Orders
                .Where(o => o.OrderNumber == orderNumber)
                .Select(o => new OrderSummaryDTO()
                {
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.CreatedOn,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    PhoneNumber = o.PhoneNumber,
                    PostCode = o.PostCode,
                    Address = o.Address,
                    Town = o.Town,
                    District = o.District,
                    Country = o.Country,
                    Email = o.Email,
                    IsShippingToOffice = o.DeliveryMethodId == 1,
                    ShippingProviderName = o.ShippingProviderName,
                    ShippingOfficeCity = o.ShippingOfficeCity,
                    ShippingOfficeAddress = o.ShippingOfficeAddress,
                    PaymentMethod = new Dictionary<string, string>
                    {
                        { Bulgarian, o.PaymentMethod.Name.NameBG },
                        { Romanian, o.PaymentMethod.Name.NameRO },
                        { English, o.PaymentMethod.Name.NameEN }
                    }[language],
                    NoteForDelivery = o.NoteForDelivery,
                    Products = o.ProductsOrders
                        .Select(po => new ProductOrderDTO()
                        {
                            Id = po.Product.Id,
                            Name = new Dictionary<string, string>
                            {
                                { Bulgarian, po.Product.Name.NameBG },
                                { Romanian, po.Product.Name.NameRO },
                                { English, po.Product.Name.NameEN }
                            }[language],
                            ImagePath = po.ImagePath,
                            Quantity = po.Quantity,
                            Price = po.Price,
                        }),
                    PromoCode = o.PromoCode != null ? new Dictionary<string, string>
                    {
                        { Bulgarian, o.PromoCode.Code.NameBG },
                        { Romanian, o.PromoCode.Code.NameRO },
                        { English, o.PromoCode.Code.NameEN }
                    }[language] : string.Empty,
                    Discount = o.Discount,
                    SubTotal = o.ProductsOrders.Sum(po => po.Quantity * po.Price) - o.Discount,
                    ShippingPrice = o.ShippingPrice,
                    Total = o.ProductsOrders.Sum(po => po.Quantity * po.Price) - o.Discount + o.ShippingPrice,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (orderSummary != null)
            {
                orderSummary.SubTotal = Math.Round(orderSummary.SubTotal, 2);
                orderSummary.Total = Math.Round(orderSummary.Total, 2);
            }

            return orderSummary;
        }

        public async Task<OrderDTO> CalculateCheckout(OrderDTO order)
        {
            order.Language = _httpContextManager.GetLanguage();
            order.ExchangeRate = await _appConfigService.GetExchangeRateAsync(order.Language);
            decimal freeShipping = await _appConfigService.GetFreeShippingAsync(order.Language);
            decimal subTotal = order.ProductsInBag.Sum(p => p.Price * p.Quantity);
            decimal discount = order.PromoCodes.FirstOrDefault(pc => pc.Id == order.PromoCodeId)?.Discount ?? 0;
            order.Discount = Math.Round((subTotal * discount), 2);
            order.SubTotal = Math.Round((subTotal - order.Discount), 2);

            if (order.IsSelectedAddress)
            {
                decimal shippingPrice = 0;
                if (order.DeliveryMethodId == 1)
                {
                    shippingPrice = Math.Round((order.Address.ShippingOffice!.Price / order.ExchangeRate), 2);
                }
                else if (order.DeliveryMethodId == 2)
                {
                    shippingPrice = await _appConfigService.GetAddressDeliveryPriceAsync(order.Language);
                }

                order.ShippingPrice = order.SubTotal >= freeShipping ? 0 : Math.Round(shippingPrice, 2);
            }


            order.Total = order.SubTotal + order.ShippingPrice;

            return order;
        }

        public async Task<StatisticsModel> GetStatisticsAsync()
        {
            return new StatisticsModel()
            {
                TotalIOrders = await _context.Orders.CountAsync(),
                TotalProducts = await _context.Products.CountAsync(),
            };
        }
    }
}

