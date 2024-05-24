using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class MessageFromClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string EmailForResponse { get; set; }

        [Required]
        public required string Message { get; set; }

        public DateTimeOffset DateSent { get; set; }

        public string? AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }
    }
}
