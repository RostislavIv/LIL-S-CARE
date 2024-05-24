using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Promo Code for one User")]
    public class PromoCode
    {
        [Comment("Promo Code Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Promo Code Id")]
        public int CodeId { get; set; }

        [ForeignKey(nameof(CodeId))]
        public PromoCodeName Code { get; set; } = null!;

        [Comment("Discount of Total Price Order")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Comment("Expiration Date of Promo Code")]
        public DateTimeOffset ExpirationDate { get; set; }

        public DateTimeOffset? AppliedDate { get; set; }

        [Comment("Owner of Promo Code")]
        public required string AppUserId { get; set; }

        [Comment("Navigation Property to AppUser")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;


        [Comment("Navigation Property to Order")]
        public Order? Order { get; set; }
    }
}