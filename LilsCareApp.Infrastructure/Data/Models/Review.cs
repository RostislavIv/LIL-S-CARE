using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Review;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("This class represents a review of a product.")]
    [PrimaryKey(nameof(ProductId), nameof(AuthorId))]
    public class Review
    {

        [Comment("The identifier of the product.")]
        [Required]
        public int ProductId { get; set; }

        [Comment("The product that the review is for.")]
        public Product Product { get; set; } = null!;

        [Comment("The identifier of the user that created the review.")]
        [Required]
        public required string AuthorId { get; set; }

        [Comment("The user that created the review.")]
        [ForeignKey(nameof(AuthorId))]
        public AppUser Author { get; set; } = null!;

        [Comment("The rating of the review.")]
        [Required]
        public int Rating { get; set; }

        [Comment("The title of the review.")]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [Comment("The comment of the review.")]
        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; }

        [Comment("The images of the review.")]
        public List<ImageReview>? Images { get; set; }

        [Comment("The date when the review was created.")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
