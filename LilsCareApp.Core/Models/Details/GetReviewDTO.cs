namespace LilsCareApp.Core.Models.Details
{
    public class GetReviewDTO
    {
        public int ProductId { get; set; }

        public required string AuthorName { get; set; }

        public string? AuthorEmail { get; set; }

        public string? AuthorImage { get; set; }

        public int Rating { get; set; }

        public string? Title { get; set; }

        public string? Comment { get; set; }

        public ImageDTO[] Images { get; set; } = new ImageDTO[3];

        public DateTimeOffset CreatedOn { get; set; }

    }
}