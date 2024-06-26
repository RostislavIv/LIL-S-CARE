﻿using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        private readonly IEnumerable<PromoCode> promoCodes = new List<PromoCode>
        {
            new PromoCode
            {
                Id = 1,
                CodeId = 1,
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new PromoCode
            {
                Id = 2,
                CodeId = 2,
                Discount = 0.2m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
        };

        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.HasData(promoCodes);
        }
    }
}

