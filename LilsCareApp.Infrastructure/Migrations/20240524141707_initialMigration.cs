using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FreeShipping = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The price at which the shipping is free."),
                    AddressDeliveryPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The price at which the delivery to an address is paid."),
                    ExchangeRateEUR = table.Column<decimal>(type: "numeric(18,4)", nullable: false, comment: "The exchange rate of the euro."),
                    ExchangeRateBGN = table.Column<decimal>(type: "numeric(18,4)", nullable: false, comment: "The exchange rate of the leva."),
                    ExchangeRateRON = table.Column<decimal>(type: "numeric(18,4)", nullable: false, comment: "The exchange rate of the lei.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "First Name"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "Last Name"),
                    ImagePath = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true, comment: "The image of user"),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "App User");

            migrationBuilder.CreateTable(
                name: "CategoryNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The category's name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The category's name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The category's name in Romanian"),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The delivery name Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The delivery name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The delivery name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The delivery name in Romanian"),
                    DeliveryMethodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Payment name id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The payment name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The payment name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The payment name in Romanian"),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The product's name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The product's name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The product's name in Romanian"),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionalEN = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The product's optional in English"),
                    OptionalBG = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The product's optional in Bulgarian"),
                    OptionalRO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The product's optional in Romanian"),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Promo code name id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The promo code name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The promo code name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The promo code name in Romanian"),
                    PromoCodeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionEN = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false, comment: "The section's description in English"),
                    DescriptionBG = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false, comment: "The section's description in Bulgarian"),
                    DescriptionRO = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false, comment: "The section's description in Romanian"),
                    SectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleEN = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The section's title in English"),
                    TitleBG = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The section's title in Bulgarian"),
                    TitleRO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The section's title in Romanian"),
                    SectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Unique identifier of shipping provider")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Name of shipping provider")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingProviders", x => x.Id);
                },
                comment: "Shipping providers");

            migrationBuilder.CreateTable(
                name: "StatusOrderNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Status order name id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameEN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The status order name in English"),
                    NameBG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The status order name in Bulgarian"),
                    NameRO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The status order name in Romanian"),
                    StatusOrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrderNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessagesFromClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    EmailForResponse = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    DateSent = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesFromClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesFromClients_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The category's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(type: "integer", nullable: false, comment: "The category's name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryNames_NameId",
                        column: x => x.NameId,
                        principalTable: "CategoryNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The category of the product");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Delivery method id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(type: "integer", nullable: false, comment: "Delivery method name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryMethods_DeliveryNames_NameId",
                        column: x => x.NameId,
                        principalTable: "DeliveryNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Payment method id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(type: "integer", nullable: false, comment: "Payment method name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_PaymentNames_NameId",
                        column: x => x.NameId,
                        principalTable: "PaymentNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Payment methods");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The product's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(type: "integer", nullable: false, comment: "The product's name Id"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The product's price"),
                    Quantity = table.Column<int>(type: "integer", nullable: false, comment: "The product's quantity"),
                    OptionalId = table.Column<int>(type: "integer", nullable: false, comment: "The product's optional Id"),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false, comment: "Is the product show on online store")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductNames_NameId",
                        column: x => x.NameId,
                        principalTable: "ProductNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionals_OptionalId",
                        column: x => x.OptionalId,
                        principalTable: "ProductOptionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The product model");

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Promo Code Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeId = table.Column<int>(type: "integer", nullable: false, comment: "Promo Code Id"),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Discount of Total Price Order"),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Expiration Date of Promo Code"),
                    AppliedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: false, comment: "Owner of Promo Code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoCodes_PromoCodeNames_CodeId",
                        column: x => x.CodeId,
                        principalTable: "PromoCodeNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Promo Code for one User");

            migrationBuilder.CreateTable(
                name: "ShippingOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    OfficeAddressId = table.Column<int>(type: "integer", nullable: false),
                    OfficeAddress = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Price of shipping"),
                    ShippingDuration = table.Column<int>(type: "integer", nullable: false, comment: "Duration of shipping"),
                    ShippingProviderId = table.Column<int>(type: "integer", nullable: false, comment: "Shipping Provider Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingOffices_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(type: "integer", nullable: false, comment: "Name of the status Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusOrders_StatusOrderNames_NameId",
                        column: x => x.NameId,
                        principalTable: "StatusOrderNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Status of the order");

            migrationBuilder.CreateTable(
                name: "BagsUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "text", nullable: false, comment: "The user id"),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product id"),
                    Quantity = table.Column<int>(type: "integer", nullable: false, comment: "The quantity of the product that the user has added to his bag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagsUsers", x => new { x.AppUserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagsUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagsUsers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This table contains the products that the user has added to his bag");

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The image id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false, comment: "The path of the image"),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ImageOrder = table.Column<int>(type: "integer", nullable: false, comment: "The order of the image in the product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The image of the product");

            migrationBuilder.CreateTable(
                name: "ProductsCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product id"),
                    CategoryId = table.Column<int>(type: "integer", nullable: false, comment: "The category id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and categories");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The identifier of the product."),
                    AuthorId = table.Column<string>(type: "text", nullable: false, comment: "The identifier of the user that created the review."),
                    Rating = table.Column<int>(type: "integer", nullable: false, comment: "The rating of the review."),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "The title of the review."),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true, comment: "The comment of the review."),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "The date when the review was created.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.ProductId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This class represents a review of a product.");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The section's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleId = table.Column<int>(type: "integer", nullable: false, comment: "The section's title Id"),
                    DescriptionId = table.Column<int>(type: "integer", nullable: false, comment: "The section's description Id"),
                    SectionOrder = table.Column<int>(type: "integer", nullable: false, comment: "The section's order in page"),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product's primary key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_SectionDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "SectionDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_SectionTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SectionTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The section model. Keeping descriptions of product");

            migrationBuilder.CreateTable(
                name: "WishesUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "text", nullable: false, comment: "The user id"),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishesUsers", x => new { x.AppUserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WishesUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishesUsers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This table contains the products that the user has added to his wish list");

            migrationBuilder.CreateTable(
                name: "AddressDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Address Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "First Name Recipient"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Last Name Recipient"),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Phone Number Recipient"),
                    PostCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "Post Code"),
                    Address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true, comment: "Address"),
                    Town = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "Town"),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "District"),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "Country"),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "Email"),
                    IsShippingToOffice = table.Column<bool>(type: "boolean", nullable: false),
                    ShippingOfficeId = table.Column<int>(type: "integer", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: false, comment: "App User Id"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDeliveries_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                        column: x => x.ShippingOfficeId,
                        principalTable: "ShippingOffices",
                        principalColumn: "Id");
                },
                comment: "Address Delivery");

            migrationBuilder.CreateTable(
                name: "ImageReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The image id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false, comment: "The path of the image"),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The identifier of the product."),
                    AuthorId = table.Column<string>(type: "text", nullable: true, comment: "The identifier of the author.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageReviews_Reviews_ProductId_AuthorId",
                        columns: x => new { x.ProductId, x.AuthorId },
                        principalTable: "Reviews",
                        principalColumns: new[] { "ProductId", "AuthorId" });
                },
                comment: "The image of the review");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Order Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<string>(type: "text", nullable: true, comment: "Order Number"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Date of Order Creating"),
                    StatusOrderId = table.Column<int>(type: "integer", nullable: false, comment: "Status of Order"),
                    DeliveryMethodId = table.Column<int>(type: "integer", nullable: false, comment: "Method of Delivery"),
                    AddressDeliveryId = table.Column<int>(type: "integer", nullable: true, comment: "Address Delivery Id"),
                    AppUserId = table.Column<string>(type: "text", nullable: true, comment: "App User Id"),
                    DateShipping = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Date of Shipping Creating"),
                    TrackingNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true, comment: "Tracking Number of Order"),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: false, comment: "Payment Method Id"),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false, comment: "Is Paid Order"),
                    NoteForDelivery = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Note for Delivery"),
                    ExchangeRate = table.Column<decimal>(type: "numeric(18,4)", nullable: false, comment: "Exchange Rate of the Prices"),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Language of Order, determinate the currency of the prices"),
                    ShippingPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Shipping Price"),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Absolute Discount value"),
                    PromoCodeId = table.Column<int>(type: "integer", nullable: true, comment: "Promo Code Id"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "First Name Recipient"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Last Name Recipient"),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Phone Number Recipient"),
                    PostCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "Post Code"),
                    Address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true, comment: "Address"),
                    Town = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "Town"),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "District"),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "Country"),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "Email"),
                    ShippingOfficeId = table.Column<int>(type: "integer", nullable: true),
                    ShippingProviderName = table.Column<string>(type: "text", nullable: true),
                    ShippingOfficeCity = table.Column<string>(type: "text", nullable: true),
                    ShippingOfficeAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressDeliveries_AddressDeliveryId",
                        column: x => x.AddressDeliveryId,
                        principalTable: "AddressDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PromoCodes_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingOffices_ShippingOfficeId",
                        column: x => x.ShippingOfficeId,
                        principalTable: "ShippingOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "ProductsOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false, comment: "The quantity of the product in the order"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The price of the product at the time of the order"),
                    ImagePath = table.Column<string>(type: "text", nullable: true, comment: "The image path of the product at the time of the order")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and orders");

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Id", "AddressDeliveryPrice", "ExchangeRateBGN", "ExchangeRateEUR", "ExchangeRateRON", "FreeShipping" },
                values: new object[] { 1, 8.00m, 1m, 1.9558m, 0.3930m, 35.00m });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "df56c051-24a9-4225-ac8d-6fa4e5aa1e4c", "admin@mail.com", true, "Admin", null, "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEPqqeRgjJmHKOTNwLZVxl0rGRe7hHdghLKWoNm76n14fkjtiY/xw70q2Ena+kgpm4g==", null, false, "90879803-14ca-4aea-8c5b-29274b3af080", false, "admin@mail.com" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "203619d0-e32a-490d-8b64-743b51794f75", "test@softuni.bg", true, "Test", null, "Testov", false, null, "TEST@SOFTUNI.BG", "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEIKadnacdhx8PG/498V7G0K5E5YnPA2vpOvyZ94y56TlWAW98NUm/kQn5uFGnUfZ+Q==", null, false, "1d66dece-1154-4091-a03f-4a50c5bb49ee", false, "test@softuni.bg" }
                });

            migrationBuilder.InsertData(
                table: "CategoryNames",
                columns: new[] { "Id", "CategoryId", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, 1, "всички", "all", "toate" },
                    { 2, 2, "за тяло", "body", "pentru corp" },
                    { 3, 3, "за суха кожа", "dry skin", "pentru piele uscata" },
                    { 4, 4, "за мазна кожа", "oily skin", "pentru piele grasa" },
                    { 5, 5, "за лице", "face", "pentru fata" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryNames",
                columns: new[] { "Id", "DeliveryMethodId", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, 1, "Доставка до офис на куриер", "Office delivery", "Livrare la birou" },
                    { 2, 2, "Доставка до адрес на клиент", "Home delivery", "Livrare la domiciliu" }
                });

            migrationBuilder.InsertData(
                table: "PaymentNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO", "PaymentMethodId" },
                values: new object[,]
                {
                    { 1, "Плащане при доставка", "Cash on delivery", "Plata la livrare", 1 },
                    { 2, "С карта", "With card", "Cu cardul", 2 },
                    { 3, "Банков превод", "Bank transfer", "Transfer bancar", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO", "ProductId" },
                values: new object[,]
                {
                    { 1, "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ", "NATURAL DRY DEODORANT", "DEODORANT NATURAL USCAT", 1 },
                    { 2, "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", "LIP BALM WITH JOJOBA, COCOA AND BEESWAX", "BALSAM DE BUZE CU JOJOBA, CACAO SI CEARA DE ALBINE", 2 },
                    { 3, "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД", "MOISTURIZING CREAM WITH ROSE BODY AND NIACINAMIDE", "CREMA HIDRATANTE CU CORP DE TRANDAFIRI SI NIACINAMIDA", 3 },
                    { 4, "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА", "TWO PHASE GREEN TEA AND JOJOBA MICELLAR WATER", "CEAI VERDE BIFAZICAL ȘI APA MICELARĂ DE JOJOBA", 4 },
                    { 5, "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", "NATURAL CREAM DEODORANT", "DEODORANT CREMA NATURAL", 5 },
                    { 6, "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ", "SERUM OIL WITH ROSE BODY, JOJOBA, ARGAN AND STRAWBERRY SEEDS", "ULEI DE SER CU CORP DE TRANDAFIRI, SEMINTE DE JOJOBA, ARGAN SI CAPSUNI", 6 },
                    { 7, "", "", "", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductOptionals",
                columns: new[] { "Id", "OptionalBG", "OptionalEN", "OptionalRO", "ProductId" },
                values: new object[,]
                {
                    { 1, "Тегло:  25 г.", "Weight:  25 g.", "Greutate:  25 g.", 1 },
                    { 2, "Тегло:  5 г.", "Weight:  5 g.", "Greutate:  5 g.", 2 },
                    { 3, "Тегло:  50 г.", "Weight:  50 g.", "Greutate:  50 g.", 3 },
                    { 4, "Тегло:  100 мл.", "Weight:  100 ml.", "Greutate:  100 ml.", 4 },
                    { 5, "Тегло:  50 г.", "Weight:  50 g.", "Greutate:  50 g.", 5 },
                    { 6, "Тегло:  20 мл.", "Weight:  20 ml.", "Greutate:  20 ml.", 6 },
                    { 7, "", "", "", 7 }
                });

            migrationBuilder.InsertData(
                table: "PromoCodeNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO", "PromoCodeId" },
                values: new object[,]
                {
                    { 1, "-10 % за регистрация", "-10 % for registration", "-10 % pentru inregistrare", 1 },
                    { 2, "-20 % отстъпка", "-20 % discount", "-20 % reducere", 2 }
                });

            migrationBuilder.InsertData(
                table: "SectionDescriptions",
                columns: new[] { "Id", "DescriptionBG", "DescriptionEN", "DescriptionRO", "SectionId" },
                values: new object[,]
                {
                    { 1, "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био", "Gentle, all-natural and handmade dry deodorant. Suitable for daily use.\r\n \r\nNo perfume and no essential oils.\r\n \r\nIn a new hard version for easier application and direct application.\r\n \r\nOr you can use an old deodorant stick pack to melt the bar for convenient daily use.\r\n \r\nCut the bar into pieces and put them in a stick pack. And microwave on low and for short intervals until the block melts. Let it cool and harden and it's done!\r\n \r\nIf you don't have a microwave, you can melt it in a water bath in a stick. Wrap the stick fitting tightly with stretch film to prevent water from entering the fitting and the product.\r\n \r\n100% natural\r\n10% from Bulgaria\r\n78.4% organic", "Deodorant uscat blând, natural și realizat manual. Potrivit pentru utilizarea zilnică.\r\n \r\nFără parfum și fără uleiuri esențiale.\r\n \r\nÎntr-o nouă versiune hard pentru aplicare mai ușoară și aplicare directă.\r\n \r\nSau puteți utiliza un pachet vechi de deodorant pentru a topi batonul pentru o utilizare zilnică convenabilă.\r\n \r\nTăiați batonul în bucăți și puneți-le într-un pachet de bețișoare. Și puneți la microunde la foc mic și pentru intervale scurte până când blocul se topește. Se lasa sa se raceasca si sa se intareasca si gata!\r\n \r\nDaca nu ai cuptor cu microunde il poti topi in baie de apa intr-un bat. Înveliți strâns garnitura cu folie extensibilă pentru a preveni intrarea apei în fiting și în produs.\r\n \r\n100% natural\r\n10% din Bulgaria\r\n78,4% organic", 1 },
                    { 2, "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.", "Dry ingredients such as organic tapioca keep the underarms dry during the day.\r\nVitamin E has an antioxidant effect.\r\nCoconut oil, shea butter and beeswax.", "Ingredientele uscate precum tapioca organică mențin axile uscate în timpul zilei.\r\nVitamina E are efect antioxidant.\r\nUleiul de cocos, untul de shea și ceara de albine.", 2 },
                    { 3, "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "Take the stick out of the box and apply to your underarms.\r\n \r\nOr gently melt it into a deodorant stick pack for easier and more convenient daily use.\r\n \r\nYou can reuse an old pack from a previous deodorant.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.", "Scoateți batonul din cutie și aplicați-l pe axile.\r\n \r\nSau topește-l ușor într-un pachet de deodorant pentru o utilizare zilnică mai ușoară și mai convenabilă.\r\n \r\nPuteți reutiliza un pachet vechi. dintr-un deodorant anterior.\r\n r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui.", 3 },
                    { 4, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 4 },
                    { 5, "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", 5 },
                    { 6, "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био", "An all-natural and hand-crafted lip balm that feels cozy and soft. Designed to be gentle and protective.\r\n \r\nOrganic Cocoa Butter\r\nNatural what a fragrance\r\nCombined with natural vanilla butter\r\nBeeswax\r\n \r\nIn two variants:\r \nLight and shiny transparent color\r\nCompletely colorless\r\n \r\nEnriched with vitamin E and organic jojoba oil.\r\n \r\n100% natural\r\n49% from Bulgaria\r\n41% bio", "Un balsam de buze natural și realizat manual, care se simte confortabil și moale. Conceput să fie blând și protector.\r\n \r\nUnt de cacao organic\r\nNatural ce parfum\r\nCombinat cu unt natural de vanilie\r\nCeară de albine\r\n \r\nÎn două variante:\r\nCuloare transparentă deschisă și strălucitoare\r\nComplet incolor\r\n \r\nÎmbogățit cu vitamina E și ulei organic de jojoba.\r\n \r\n100% natural\r\n49% din Bulgaria\r\n41% bio", 6 },
                    { 7, "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава", "Cocoa butter* gives a light and natural chocolate aroma and protects the lips.\r\n \r\nJojoba oil* nourishes them.\r\n \r\nBeeswax* protects the lips, makes the balm last both on the lips and in the tube not to end quickly. Gives a feeling of cushion and softness on the lips.\r\n \r\nVitamin E - a natural antioxidant that protects against harmful environmental influences.\r\n \r\n*Bio 41% of the composition", "Untul de cacao* confera o aroma usoara si naturala de ciocolata si protejeaza buzele.\r\n \r\nUleiul de jojoba* le hraneste.\r\n \r\nCera de albine* protejeaza buzele, face ca balsamul sa reziste atat pe buze cat si în tub să nu se termine repede. Oferă o senzație de perniță și catifelare pe buze.\r\n \r\nVitamina E - un antioxidant natural care protejează împotriva influențelor nocive ale mediului.\r\n \r\n*Bio 41% din compoziție", 7 },
                    { 8, "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.", "All natural, you can use it whenever you want to nourish and protect your lips or just give them a slight shine to complete your look.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store with the cap closed, in a dry place and protected from direct sunlight.", "În totalitate naturală, îl poți folosi oricând vrei să-ți hrănești și să-ți protejezi buzele sau doar să le dai o ușoară strălucire pentru a-ți completa aspectul.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra cu capacul inchis, la loc uscat si ferit de lumina directa a soarelui.", 8 },
                    { 9, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 9 },
                    { 10, "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", 10 },
                    { 11, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE", 11 },
                    { 12, "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био", "Bulgarian cold-pressed rosehip oil* - a natural source of vitamin A, nourishes and stimulates skin regeneration.\r\n \r\nRosehip extract - botanical glycerine extract, which in this cream is a wonderful combination with rosehip oil.\r \n \r\nShea Butter* - The lightest and lowest comedogenic rating (0-2) of all solid oils. This means it has a low chance of clogging pores on a scale of 0 to 5.\r\n \r\nVitamin B3 - Niacinamide - An antioxidant that evens out the complexion, regulates sebum, aids hydration and smoothes fine lines. Naistirna sounds incredible, a is doaxrno.\r\n \r\nVitamin E - has an effective and natural antioxidant effect: it forgets aging by helping to restore the skin and protects it from free radicals and environmental damage.\r\n \r\nVegetable glycerin and hyaluronic - humectants - attract water and hydrate the skin. Concentration is key! Too much of these can dry out the skin by starting to pull moisture from the deeper layers of the skin when the air is dry. The balance between water and humectants in the product is important.\r\n \r\n*Bio", "Uleiul bulgar de macese presat la rece* - o sursa naturala de vitamina A, hraneste si stimuleaza regenerarea pielii.\r\n \r\nExtract de macese - extract de glicerina botanica, care in aceasta crema este o combinatie minunata cu uleiul de macese.\r\n \r\nUnt de Shea* - Cel mai ușor și cel mai scăzut rating comedogen (0-2) dintre toate uleiurile solide. Aceasta înseamnă că are o șansă scăzută de a înfunda porii pe o scară de la 0 la 5.\r\n \r\nVitamina B3 - Niacinamidă - Un antioxidant care uniformizează tenul, reglează sebumul, ajută la hidratare și netezește liniile fine. Naistirna sună incredibil, a is doaxrno.\r\n \r\nVitamina E - are un efect antioxidant eficient și natural: uită de îmbătrânire ajutând la refacerea pielii și o protejează de radicalii liberi și daunele mediului.\r\n \r\nGlicerina vegetală și hialuronicul - umectanți - atrag apa și hidratează pielea. Concentrarea este cheia! Prea multe dintre acestea pot usca pielea, pornind să atragă umezeala din straturile mai profunde ale pielii atunci când aerul este uscat. Echilibrul dintre apă și umectanți din produs este important.\r\n \r\n*Bio", 12 },
                    { 13, "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "Apply to dry or damp skin. A small amount is enough for the whole face and neck. Use 1-2 times daily as needed and skin dryness.\r\n \r\nCan be applied to damp skin, such as after shower and gel wash to lock in hydration.\r\n \r\nOr to dry skin , to protect it.\r\n \r\nApply to well-cleansed skin with clean hands. For external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed, in a dry place, protected from direct sunlight.", "Aplicați pe pielea uscată sau umedă. O cantitate mică este suficientă pentru toată fața și gâtul. Utilizați de 1-2 ori pe zi după cum este necesar și pielea uscată.\r\n \r\nPoate fi aplicat pe pielea umedă, cum ar fi după duș și spălare cu gel pentru a menține hidratarea.\r\n \r\nSau pe pielea uscată , pentru a-l proteja.\r\n \r\nAplicați pe pielea bine curățată cu mâinile curate. Doar pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui.", 13 },
                    { 14, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 14 },
                    { 15, "Aqua (apă), ulei de semințe de Rosa Canina* (ulei de măceș, 10%), unt de Butyrospermum Parkii* (unt de shea), glicerină (glicerină), extract de fructe Rosa Canina (extract de măceș), niacinamidă (vitamina B3), olivat de cetearil, Olivat de sorbitan (emulgatori), hialuronat de sodiu (acid hialuronic), tocoferol (vitamina E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, benzoat de sodiu, sorbat de potasiu (conservanți), acid lactic (acid lactic, AHA, reglează pH-ul) produs).\r\n*Bio", "Aqua (Water), Rosa Canina Seed Oil* (rosehip oil, 10%), Butyrospermum Parkii Butter* (shea butter), Glycerin (glycerin), Rosa Canina Fruit Extract (rosehip extract), Niacinamide (vitamin B3 ), Cetearyl Olivate, Sorbitan Olivate (emulsifiers), Sodium Hyaluronate (hyaluronic acid), Tocopherol (vitamin E), Helianthus Annuus (Sunflower) Seed Oil*, Sodium Benzoate, Potassium Sorbate (preservatives), Lactic Acid (lactic acid, AHA, adjusts the pH of the product).\r\n*Bio", "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio", 15 },
                    { 16, "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България", "Natural micellar water with two components. Shake before use to mix the two phases. It is ideal for the gentle removal of make-up at the end of the day.\r\n \r\nIt has a double action as a facial toner with green tea extract and vitamin E.\r\n \r\nPhase 1 is extremely gentle. It has a soothing and antioxidant effect thanks to green tea extract, squalene and panthenol (provitamin B3).\r\n \r\nPhase 2 is with organic jojoba oil and helps to dissolve makeup. Leaves the skin soft, nourished and protected.\r\n \r\nIn a convenient bottle with a popma for easy use.\r\n \r\n100% natural\r\n94% from Bulgaria", "Apa micelara naturala cu doua componente. Agitați înainte de utilizare pentru a amesteca cele două faze. Este ideal pentru demachierea blândă la sfârșitul zilei.\r\n \r\nAre dublă acțiune ca tonic facial cu extract de ceai verde și vitamina E.\r\n \r\nFază 1 este extrem de blând. Are un efect calmant si antioxidant datorita extractului de ceai verde, squalenului si pantenolului (provitamina B3).\r\n \r\nFaza 2 este cu ulei de jojoba organic si ajuta la dizolvarea machiajului. Lasă pielea moale, hrănită și protejată.\r\n \r\nÎntr-o sticlă convenabilă cu popma pentru utilizare ușoară.\r\n \r\n100% natural\r\n94% din Bulgaria", 16 },
                    { 17, "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат", "Green tea extract - antioxidant and soothing action, helps against the appearance of acne\r\n \r\nBio Jojoba oil - helps to gently dissolve make-up and nourishes the skin\r\n \r\nVitamin E - antioxidant, soothes irritations , fights free radicals and slows skin aging\r\n \r\nPanthenol - provitamin B5 - with plant origin. Hydrates and nourishes\r\n \r\nGrapefruit essential oil - light citrus scent", "Extract de ceai verde - actiune antioxidanta si calmanta, ajuta impotriva aparitiei acneei\r\n \r\nUlei de jojoba Bio - ajuta la dizolvarea delicata a machiajului si hraneste pielea\r\n \r\nVitamina E - antioxidant, calmeaza iritatii, combate radicalii liberi si incetineste imbatranirea pielii\r\n \r\nPantenol - provitamina B5 - cu origine vegetala. Hidratează și hrănește\r\n \r\nUlei esențial de grapefruit - parfum ușor de citrice", 17 },
                    { 18, "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.", "Shake before use.\r\n \r\nCan be used whenever you want to gently remove makeup. Shake before use and soak a cotton pad. Gently press into skin to wet and begin to dissolve makeup. Then remove the makeup with light movements from the center of the face to the sides.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store in a dry place away from direct sunlight.", "Agitați înainte de utilizare.\r\n \r\nPoate fi folosit oricând doriți să îndepărtați ușor machiajul. Agitați înainte de utilizare și înmuiați un tampon de bumbac. Apăsați ușor pielea pentru a uda și începe să dizolveți machiajul. Apoi indeparteaza machiajul cu miscari usoare din centrul fetei spre laterale.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra intr-un loc uscat ferit de lumina directa a soarelui.", 18 },
                    { 19, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 19 },
                    { 20, "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био", "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract, Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based ), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool .\r\n*Bio", "Aqua, ulei de semințe de Vitis Vinifera (struguri), extract de frunze de Camellia Sinensis (ceai verde), glicerină, trigliceride caprilice/caprice (ulei de cocos fracționat), ulei de semințe de Simmondsia Chinensis (jojoba)*, D-pantenol (provitamina B5, pe bază de plante) ), glucozid de coco, squalan, surfactin de sodiu, tocoferol (Vit E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, sorbat de potasiu, benzoat de sodiu, alcool benzilic, acid citric, ulei de coajă de Citrus Paradisi (grapefruit), limonen, citral, .\r\n*Bio", 20 },
                    { 21, "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био", "Gentle, all-natural and handmade deodorant. Suitable for daily use. The essential oils of sweet orange and eucalyptus impart a light citrus aroma.\r\n \r\nWe chose these essential oils not only for their pleasant aroma. They also have a better antibacterial effect than most essential oils. They even prevent the development of different types of fungi. This means it can naturally reduce the bad smell of sweat caused by underarm bacteria.\r\n \r\n100% natural\r\n45.7% from Bulgaria\r\n44.5% organic", "Deodorant blând, natural și realizat manual. Potrivit pentru uz zilnic. Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă ușoară de citrice.\r\n \r\nAm ales aceste uleiuri esențiale nu numai pentru aroma lor plăcută. De asemenea, au un efect antibacterian mai bun decât majoritatea uleiurilor esențiale. Ele previn chiar și dezvoltarea diferitelor tipuri de ciuperci. Aceasta înseamnă că poate reduce în mod natural mirosul urât al transpirației cauzat de bacteriile de la subrat.\r\n \r\n100% natural\r\n45,7% din Bulgaria\r\n44,5% organic", 21 },
                    { 22, "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.", "The essential oils of sweet orange and eucalyptus give a fresh, slightly minty citrus aroma and have an antibacterial effect.\r\n \r\nDry ingredients such as organic tapioca keep the underarms dry during the day.\r\n \r\nVitamin E has an antioxidant effect. \r\n \r\nAnd the whole combination of ingredients keeps unpleasant odors away.", "Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă de citrice proaspătă, ușor mentată și au efect antibacterian.\r\n \r\nIngredientele uscate precum tapioca organică mențin axilele uscate în timpul zilei.\r\n \r\nVitamina E are efect antioxidant \r\n \r\nIar intreaga combinatie de ingrediente tine la distanta mirosurile neplacute.", 22 },
                    { 23, "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "Take a very small amount (smaller than a pea) on the fingertips, warm it slightly between the fingers and spread it well under the armpits.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.", "Luați o cantitate foarte mică (mai mică decât un bob de mazăre) pe vârful degetelor, încălziți-o ușor între degete și întindeți-o bine sub axile.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui.", 23 },
                    { 24, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 24 },
                    { 25, "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла", "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil* , Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Essential Oil Components", "Ulei de semințe de Vitis Vinifera (struguri), amidon de tapioca*, unt de semințe de cacao (cacao) de Theobroma*, Copernicia Cerifera Cera (ceară de carnauba)*, bicarbonat de sodiu, stearat de gliceril, ulei de coajă de Citrus Sinensis (portocale)*, globul de eucalipt* , Limonene**, Linalool**, Citral**, Tocoferol (Vit E), Ulei de semințe de Helianthus Annuus (floarea-soarelui)*\r\n*Bio\r\n**Componente ale uleiului esențial", 25 },
                    { 26, "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био", "Created to pamper yourself - with organic oils from: rosehip, strawberry seeds, argan and jojoba. Nourishes and protects the skin. Preserves hydration by protecting the skin from water loss and leaving it soft and smooth.\r\n \r\nEnriched with vitamin E for a good antioxidant effect that protects cells from the harmful effects of the environment, free radicals and oxidative processes. In this way, it keeps the skin young and elastic.\r\n \r\nRosehip oil is a natural source of vitamin A. Argan oil and strawberry seed oil nourish the skin, and jojoba oil contains natural ceramides, strengthen the skin barrier and strengthen bonds between cells.\r\n\r\nNon-comedogenic.\r\nBest for dry skin.\r\nOr as protection after a more exhausting routine, e.g. after a chemical peel.\r\nNourishes, strengthens and protects the skin barrier.\r\n \r\nUse a few drops on dry or damp skin (for example after a shower) or after a moisturizing lotion to 'lock in' hydration and protect the skin. \r\n \r\n100% natural\r\n80% from Bulgaria\r\n31% organic", "Creat pentru a te rasfata - cu uleiuri organice din: macese, seminte de capsuni, argan si jojoba. Hraneste si protejeaza pielea. Păstrează hidratarea protejând pielea de pierderea apei și lăsând-o moale și netedă.\r\n \r\nÎmbogățit cu vitamina E pentru un bun efect antioxidant care protejează celulele de efectele nocive ale mediului, radicalilor liberi și proceselor oxidative. În acest fel, menține pielea tânără și elastică.\r\n \r\nUleiul de măceș este o sursă naturală de vitamina A. Uleiul de argan și uleiul de semințe de căpșuni hrănesc pielea, iar uleiul de jojoba conține ceramide naturale, întăresc bariera pielii și întărește legăturile dintre celule.\r\n\r\nNon-comedogenic.\r\nCel mai bun pentru pielea uscată.\r\nSau ca protecție după o rutină mai obositoare, de ex. după un peeling chimic.\r\nHrănește, întărește și protejează bariera cutanată.\r\n \r\nFolosește câteva picături pe pielea uscată sau umedă (de exemplu după un duș) sau după o loțiune hidratantă pentru a „bloca” hidratează și protejează pielea. \r\n \r\n100% natural\r\n80% din Bulgaria\r\n31% organic", 26 },
                    { 27, "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био", "Rosehip oil - helps revitalize the skin \r\nStrawberry seed oil - deeply hydrates and has an anti-inflammatory effect\r\nJojoba oil* - naturally contains over 95% ceramides, nourishes the skin and strengthens the skin barrier\r\nArgan oil* - nourishes, protects and improves the hydration and elasticity of the skin\r\nTangerine and ylang-ylang oils* - give a light, fresh and relaxing aroma to make the most of the skin care moment\r\nVitamin E* - antioxidant - soothes irritated skin and slows aging by fighting free radicals, UV damage and oxidation processes\r\n*Bio", "Ulei de măceș - ajută la revitalizarea pielii \r\nUlei din semințe de căpșuni - hidratează profund și are efect antiinflamator\r\nUlei de jojoba* - conține în mod natural peste 95% ceramide, hrănește pielea și întărește bariera pielii\r\nUlei de argan * - hrănește, protejează și îmbunătățește hidratarea și elasticitatea pielii\r\nUleiuri de mandarine și ylang-ylang* - oferă o aromă ușoară, proaspătă și relaxantă pentru a profita la maximum de momentul de îngrijire a pielii\r\nVitamina E* - antioxidant - calmează pielea iritată și încetinește îmbătrânirea prin combaterea radicalilor liberi, a daunelor UV și a proceselor de oxidare\r\n*Bio", 27 },
                    { 28, "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "For example, after a light moisturizing lotion to lock in hydration and beneficial ingredients.\r\nDirectly on damp skin for better absorption and protection.\r\nOr on dry skin to prevent transepidermal water loss from the skin.\r\n \r\nSuitable for skin protection at the end of the routine. Blends well after exfoliating and/or hydrating products.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Use with clean hands and skin. Store tightly closed, in a dry place, protected from direct sunlight.", "De exemplu, după o loțiune ușoară hidratantă pentru a bloca hidratarea și ingredientele benefice.\r\nDirect pe pielea umedă pentru o mai bună absorbție și protecție.\r\nSau pe pielea uscată pentru a preveni pierderea transepidermică de apă din piele.\r\n \r\nPotrivit pentru protecția pielii la sfârșitul rutinei. Se amestecă bine după produsele de exfoliere și/sau hidratare.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. Utilizați cu mâinile și pielea curate. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui.", 28 },
                    { 29, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată.", 29 },
                    { 30, "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла", "Vitis Vinifera Seed Oil, Rosa Canina Seed Oil, Fragaria Ananassa Seed Oil, Argania Spinosa Kernel Oil, Simmondsia Chinensis Seed Oil (Jojoba Oil)*, Tocopherol (Vitamin E), Helianthus Annuus Seed Oil (Sunflower Oil <0.2%) *, Citrus Reticulata Oil (Mandarin Essential Oil), Limonene**, Linalool**, Cananga Odorata flower Oil (Ylang Ylanf essential oil) *.\r\n*Bio, 31%\r\n**Essential oil components", "Ulei de semințe de Vitis Vinifera, ulei de semințe de Rosa Canina, ulei de semințe de Fragaria Ananassa, ulei de semințe de Argania Spinosa, ulei de semințe de Simmondsia Chinensis (ulei de jojoba)*, tocoferol (vitamina E), ulei de semințe de Helianthus annuus (ulei de floarea soarelui <0,2%) *, citrice Ulei de reticulata (ulei esential de mandarina), limonene**, linalool**, ulei de flori de cananga odorata (ulei esential de Ylang Ylanf) *.\r\n*Bio, 31%\r\n**Componente ale uleiului esential", 30 },
                    { 31, "", "", "", 31 },
                    { 32, "", "", "", 32 },
                    { 33, "", "", "", 33 },
                    { 34, "", "", "", 34 },
                    { 35, "", "", "", 35 }
                });

            migrationBuilder.InsertData(
                table: "SectionTitles",
                columns: new[] { "Id", "SectionId", "TitleBG", "TitleEN", "TitleRO" },
                values: new object[,]
                {
                    { 1, 1, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 2, 2, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 3, 3, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 4, 4, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 5, 5, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 6, 6, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 7, 7, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 8, 8, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 9, 9, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 10, 10, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 11, 11, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 12, 12, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 13, 13, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 14, 14, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 15, 15, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 16, 16, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 17, 17, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 18, 18, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 19, 19, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 20, 20, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 21, 21, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 22, 22, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 23, 23, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 24, 24, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 25, 25, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 26, 26, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 27, 27, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 28, 28, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 29, 29, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 30, 30, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 31, 31, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 32, 32, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 33, 33, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 34, 34, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 35, 35, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" }
                });

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Еконт" },
                    { 2, "Спиди" }
                });

            migrationBuilder.InsertData(
                table: "StatusOrderNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO", "StatusOrderId" },
                values: new object[,]
                {
                    { 1, "Неизпълнена", "Unfulfilled", "Neîndeplinită", 1 },
                    { 2, "Отменена", "Canceled", "Anulat", 2 },
                    { 3, "Изпълнена", "Fulfilled", "Îndeplinit", 3 },
                    { 4, "Получена", "Received", "Primit", 4 },
                    { 5, "Върната", "Returned", "Returnat", 5 }
                });

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "Email", "FirstName", "IsDefault", "IsDeleted", "IsShippingToOffice", "LastName", "PhoneNumber", "PostCode", "ShippingOfficeId", "Town" },
                values: new object[] { 2, "bul. Vitosha", "85fbe739-6be0-429d-b44b-1ce6cf7eeef", "Bulgaria", "Sofia", null, "Petar", false, false, false, "Petrov", "0888888888", "1000", null, "Sofia" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "NameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "NameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "NameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsShow", "NameId", "OptionalId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, true, 1, 1, 5.50m, 10 },
                    { 2, true, 2, 2, 4.00m, 20 },
                    { 3, true, 3, 3, 12.00m, 30 },
                    { 4, true, 4, 4, 10.00m, 0 },
                    { 5, true, 5, 5, 8.50m, 10 },
                    { 6, true, 6, 6, 10.00m, 20 },
                    { 7, true, 7, 7, 10.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "AppUserId", "AppliedDate", "CodeId", "Discount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, 1, 0.1m, new DateTimeOffset(new DateTime(2025, 5, 24, 14, 17, 6, 585, DateTimeKind.Unspecified).AddTicks(1570), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, 2, 0.2m, new DateTimeOffset(new DateTime(2025, 5, 24, 14, 17, 6, 585, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ShippingOffices",
                columns: new[] { "Id", "City", "OfficeAddress", "OfficeAddressId", "Price", "ShippingDuration", "ShippingProviderId" },
                values: new object[,]
                {
                    { 1, "Sofia", "bul. Vitosha 100", 0, 5.00m, 2, 1 },
                    { 2, "Sofia", "bul. Hristo Botev 20", 0, 5.00m, 2, 1 },
                    { 3, "Varna", "bul. Vitosha 100", 0, 5.00m, 2, 1 },
                    { 4, "Burgas", "bul. Vitosha 100", 0, 5.00m, 2, 1 },
                    { 5, "Ruse", "bul. Vitosha 100", 0, 5.00m, 2, 1 },
                    { 6, "Sofia", "bul. Vitosha 200", 0, 5.00m, 2, 2 },
                    { 7, "Sofia", "bul. Hristo Botev 30", 0, 5.00m, 2, 2 },
                    { 8, "Sofia", "bul. Bozveli 200", 0, 5.00m, 2, 2 },
                    { 9, "Burgas", "bul. Vitosha 200", 0, 5.00m, 2, 2 },
                    { 10, "Ruse", "bul. Vitosha 200", 0, 5.00m, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "StatusOrders",
                columns: new[] { "Id", "NameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "Email", "FirstName", "IsDefault", "IsDeleted", "IsShippingToOffice", "LastName", "PhoneNumber", "PostCode", "ShippingOfficeId", "Town" },
                values: new object[] { 1, null, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, null, null, "Ivan", false, false, true, "Ivanov", "0888888888", null, 1, null });

            migrationBuilder.InsertData(
                table: "BagsUsers",
                columns: new[] { "AppUserId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1, 2 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, 3 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ImageProducts",
                columns: new[] { "Id", "ImageOrder", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "/files/products/product-01-image-01.webp", 1 },
                    { 2, 2, "/files/products/product-01-image-02.webp", 1 },
                    { 3, 3, "/files/products/product-01-image-03.webp", 1 },
                    { 4, 4, "/files/products/product-01-image-04.webp", 1 },
                    { 5, 1, "/files/products/product-02-image-01.webp", 2 },
                    { 6, 2, "/files/products/product-02-image-02.webp", 2 },
                    { 7, 3, "/files/products/product-02-image-03.webp", 2 },
                    { 8, 4, "/files/products/product-02-image-04.webp", 2 },
                    { 9, 5, "/files/products/product-02-image-05.webp", 2 },
                    { 10, 1, "/files/products/product-03-image-01.webp", 3 },
                    { 11, 2, "/files/products/product-03-image-02.webp", 3 },
                    { 12, 3, "/files/products/product-03-image-03.webp", 3 },
                    { 13, 4, "/files/products/product-03-image-04.webp", 3 },
                    { 14, 5, "/files/products/product-03-image-05.webp", 3 },
                    { 15, 1, "/files/products/product-04-image-01.webp", 4 },
                    { 16, 2, "/files/products/product-04-image-02.webp", 4 },
                    { 17, 3, "/files/products/product-04-image-03.webp", 4 },
                    { 18, 4, "/files/products/product-04-image-04.webp", 4 },
                    { 19, 1, "/files/products/product-05-image-01.webp", 5 },
                    { 20, 2, "/files/products/product-05-image-02.webp", 5 },
                    { 21, 3, "/files/products/product-05-image-03.webp", 5 },
                    { 22, 4, "/files/products/product-05-image-04.webp", 5 },
                    { 23, 1, "/files/products/product-06-image-01.webp", 6 },
                    { 24, 2, "/files/products/product-06-image-02.webp", 6 },
                    { 25, 3, "/files/products/product-06-image-03.webp", 6 },
                    { 26, 4, "/files/products/product-06-image-04.webp", 6 },
                    { 27, 5, "/files/products/product-06-image-05.webp", 6 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "AddressDeliveryId", "AppUserId", "Country", "CreatedOn", "Currency", "DateShipping", "DeliveryMethodId", "Discount", "District", "Email", "ExchangeRate", "FirstName", "IsPaid", "LastName", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PhoneNumber", "PostCode", "PromoCodeId", "ShippingOfficeAddress", "ShippingOfficeCity", "ShippingOfficeId", "ShippingPrice", "ShippingProviderName", "StatusOrderId", "Town", "TrackingNumber" },
                values: new object[] { 2, null, 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, new DateTimeOffset(new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "€", null, 2, 0.00m, null, null, 1.95m, "Jane", false, "Doe", null, "123456x", 2, "1234567890x", null, null, null, null, null, 5.00m, null, 2, null, null });

            migrationBuilder.InsertData(
                table: "ProductsCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 5, 5 },
                    { 1, 6 },
                    { 3, 6 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, "Great product, I love it!", new DateTimeOffset(new DateTime(2024, 5, 24, 17, 17, 6, 585, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 3, 0, 0, 0)), 4, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, "Great product, I love it!", new DateTimeOffset(new DateTime(2024, 5, 24, 17, 17, 6, 585, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 3, 0, 0, 0)), 3, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4, "Great product, I love it!", new DateTimeOffset(new DateTime(2024, 5, 24, 17, 17, 6, 585, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 3, 0, 0, 0)), 3, "Great product" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "DescriptionId", "ProductId", "SectionOrder", "TitleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 1, 2, 2 },
                    { 3, 3, 1, 3, 3 },
                    { 4, 4, 1, 4, 4 },
                    { 5, 5, 1, 5, 5 },
                    { 6, 6, 2, 1, 6 },
                    { 7, 7, 2, 2, 7 },
                    { 8, 8, 2, 3, 8 },
                    { 9, 9, 2, 4, 9 },
                    { 10, 10, 2, 5, 10 },
                    { 11, 11, 3, 1, 11 },
                    { 12, 12, 3, 2, 12 },
                    { 13, 13, 3, 3, 13 },
                    { 14, 14, 3, 4, 14 },
                    { 15, 15, 3, 5, 15 },
                    { 16, 16, 4, 1, 16 },
                    { 17, 17, 4, 2, 17 },
                    { 18, 18, 4, 3, 18 },
                    { 19, 19, 4, 4, 19 },
                    { 20, 20, 4, 5, 20 },
                    { 21, 21, 5, 1, 21 },
                    { 22, 22, 5, 2, 22 },
                    { 23, 23, 5, 3, 23 },
                    { 24, 24, 5, 4, 24 },
                    { 25, 25, 5, 5, 25 },
                    { 26, 26, 6, 1, 26 },
                    { 27, 27, 6, 2, 27 },
                    { 28, 28, 6, 3, 28 },
                    { 29, 29, 6, 4, 29 },
                    { 30, 30, 6, 5, 30 },
                    { 31, 31, 7, 1, 31 },
                    { 32, 32, 7, 2, 32 },
                    { 33, 33, 7, 3, 33 },
                    { 34, 34, 7, 4, 34 },
                    { 35, 35, 7, 5, 35 }
                });

            migrationBuilder.InsertData(
                table: "WishesUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "AddressDeliveryId", "AppUserId", "Country", "CreatedOn", "Currency", "DateShipping", "DeliveryMethodId", "Discount", "District", "Email", "ExchangeRate", "FirstName", "IsPaid", "LastName", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PhoneNumber", "PostCode", "PromoCodeId", "ShippingOfficeAddress", "ShippingOfficeCity", "ShippingOfficeId", "ShippingPrice", "ShippingProviderName", "StatusOrderId", "Town", "TrackingNumber" },
                values: new object[] { 1, null, 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, new DateTimeOffset(new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "лв.", new DateTimeOffset(new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 10.00m, null, null, 1.00m, "John", false, "Doe", null, "123456", 1, "1234567890", null, null, null, null, null, 5.00m, null, 1, null, "1234567890" });

            migrationBuilder.InsertData(
                table: "ProductsOrders",
                columns: new[] { "OrderId", "ProductId", "ImagePath", "Price", "Quantity" },
                values: new object[,]
                {
                    { 2, 1, "/files/products/product-01-image-01.webp", 5.50m, 3 },
                    { 1, 1, "/files/products/product-01-image-01.webp", 5.00m, 2 },
                    { 1, 2, "/files/products/product-02-image-01.webp", 6.50m, 4 },
                    { 1, 3, "/files/products/product-03-image-01.webp", 5.50m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDeliveries_AppUserId",
                table: "AddressDeliveries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDeliveries_ShippingOfficeId",
                table: "AddressDeliveries",
                column: "ShippingOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BagsUsers_ProductId",
                table: "BagsUsers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameId",
                table: "Categories",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethods_NameId",
                table: "DeliveryMethods",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageProducts_ProductId",
                table: "ImageProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageReviews_ProductId_AuthorId",
                table: "ImageReviews",
                columns: new[] { "ProductId", "AuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_MessagesFromClients_AppUserId",
                table: "MessagesFromClients",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressDeliveryId",
                table: "Orders",
                column: "AddressDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromoCodeId",
                table: "Orders",
                column: "PromoCodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingOfficeId",
                table: "Orders",
                column: "ShippingOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_NameId",
                table: "PaymentMethods",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameId",
                table: "Products",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OptionalId",
                table: "Products",
                column: "OptionalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_AppUserId",
                table: "PromoCodes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_CodeId",
                table: "PromoCodes",
                column: "CodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DescriptionId",
                table: "Sections",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProductId",
                table: "Sections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TitleId",
                table: "Sections",
                column: "TitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOffices_ShippingProviderId",
                table: "ShippingOffices",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrders_NameId",
                table: "StatusOrders",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_AppUserId",
                table: "Subscribers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishesUsers_ProductId",
                table: "WishesUsers",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BagsUsers");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ImageReviews");

            migrationBuilder.DropTable(
                name: "MessagesFromClients");

            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "WishesUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SectionDescriptions");

            migrationBuilder.DropTable(
                name: "SectionTitles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CategoryNames");

            migrationBuilder.DropTable(
                name: "AddressDeliveries");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "ProductNames");

            migrationBuilder.DropTable(
                name: "ProductOptionals");

            migrationBuilder.DropTable(
                name: "ShippingOffices");

            migrationBuilder.DropTable(
                name: "DeliveryNames");

            migrationBuilder.DropTable(
                name: "PaymentNames");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PromoCodeNames");

            migrationBuilder.DropTable(
                name: "StatusOrderNames");

            migrationBuilder.DropTable(
                name: "ShippingProviders");
        }
    }
}
