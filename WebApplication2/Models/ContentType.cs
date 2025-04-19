using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class ContentType
    {
        [Key]
        public int ContentTypeId { get; set; }

        public int PermissionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; } = null!;
    }
}
