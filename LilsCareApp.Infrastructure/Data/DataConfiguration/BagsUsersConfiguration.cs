﻿using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class BagsUsersConfiguration : IEntityTypeConfiguration<BagUser>
    {
        private readonly IEnumerable<BagUser> bagsUsers = new List<BagUser>
            {
                new BagUser
                {
                    AppUserId = ConfigurationHelper.AppUser.Id,
                    ProductId = 1,
                },
                new BagUser
                {
                    AppUserId = ConfigurationHelper.AppUser.Id,
                    ProductId = 2,
                },
                new BagUser
                {
                    AppUserId = ConfigurationHelper.AppUser.Id,
                    ProductId = 3,
                },

            };
        public void Configure(EntityTypeBuilder<BagUser> builder)
        {
            builder.HasData(bagsUsers);
        }
    }
}