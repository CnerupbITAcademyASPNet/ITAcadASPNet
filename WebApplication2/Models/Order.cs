using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        [Required]
        public string Status { get; set; } = null!;
    }
}
