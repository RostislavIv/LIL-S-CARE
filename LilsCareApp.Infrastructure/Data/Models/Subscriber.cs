using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Email { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        public string? AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }
    }
}
