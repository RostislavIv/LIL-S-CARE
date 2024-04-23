﻿using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PaymentTypesConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        private readonly IEnumerable<PaymentType> paymentTypes =
        [
            new ()
            {
                Id = 1,
                NameEN = "Cash on delivery",
                NameBG = "Плащане при доставка",
                NameRO = "Plata la livrare",
            },
            new ()
            {
                Id = 2,
                NameEN = "With card",
                NameBG = "С карта",
                NameRO = "Cu cardul",
            },
            new ()
            {
                Id = 3,
                NameEN = "Bank transfer",
                NameBG = "Банков превод",
                NameRO = "Transfer bancar",
            }
        ];

        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasData(paymentTypes);
        }
    }
}


