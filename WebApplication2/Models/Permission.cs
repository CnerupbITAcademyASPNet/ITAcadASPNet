using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(255)]
        public string? Description { get; set; }

        public List<User> Users { get; set; } = null!;

        public List<ContentType> ContentTypes { get; set; } = null!;

        public Group? Group { get; set; }
    }
}
