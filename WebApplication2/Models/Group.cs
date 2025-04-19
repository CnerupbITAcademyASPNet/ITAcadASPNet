using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(250)]
        public string? Description { get; set; } = null!;

        public List<Permission> Permissions { get; set; } = new();
    }
}
