﻿using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    public class ProductNamesConfiguration : IEntityTypeConfiguration<ProductName>
    {
        private readonly IEnumerable<ProductName> productNames =
        [
            new ()
            {
                Id = 1,
                NameEN = "NATURAL DRY DEODORANT",
                NameBG = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                NameRO = "DEODORANT NATURAL USCAT",
            },
            new ()
            {
                Id = 2,
                NameEN = "LIP BALM WITH JOJOBA, COCOA AND BEESWAX",
                NameBG = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                NameRO = "BALSAM DE BUZE CU JOJOBA, CACAO SI CEARA DE ALBINE",
            },
            new ()
            {
                Id = 3,
                NameEN = "MOISTURIZING CREAM WITH ROSE BODY AND NIACINAMIDE",
                NameBG = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                NameRO = "CREMA HIDRATANTE CU CORP DE TRANDAFIRI SI NIACINAMIDA",
            },
            new ()
            {
                Id = 4,
                NameEN = "TWO PHASE GREEN TEA AND JOJOBA MICELLAR WATER",
                NameBG = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                NameRO = "CEAI VERDE BIFAZICAL ȘI APA MICELARĂ DE JOJOBA",
            },
            new ()
            {
                Id = 5,
                NameEN = "NATURAL CREAM DEODORANT",
                NameBG = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                NameRO = "DEODORANT CREMA NATURAL",
            },
            new ()
            {
                Id = 6,
                NameEN = "SERUM OIL WITH ROSE BODY, JOJOBA, ARGAN AND STRAWBERRY SEEDS",
                NameBG = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                NameRO = "ULEI DE SER CU CORP DE TRANDAFIRI, SEMINTE DE JOJOBA, ARGAN SI CAPSUNI",
            },
            new ()
            {
                Id = 7,
                NameEN = "",
                NameBG = "",
                NameRO = "",
            },
         ];

        public void Configure(EntityTypeBuilder<ProductName> builder)
        {
            builder.HasData(productNames);
        }
    }
}