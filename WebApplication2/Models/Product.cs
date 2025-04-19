using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
