using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        
        public int UserId { get; set; }

        [Required]
        public required string Token { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
