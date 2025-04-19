using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class AdminLog
    {
        [Key]
        public int AdminLogId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Action { get; set; } = null!;

        public DateTime Timestamp { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string? Details { get; set; }
    }
}
