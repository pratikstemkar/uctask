using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UcTask.Models
{
    [Table("users")]
    public class User
    {
        [Column("id", TypeName = "int")]
        [Key]
        public int Id { get; set; }

        [Column("username", TypeName = "varchar")]
        [StringLength(30)]
        public string? Username { get; set; }

        [Column("email", TypeName = "varchar")]
        [MaxLength(255)]
        [Required]
        public required string Email { get; set; }

        [Column("password", TypeName = "varchar")]
        [MaxLength(255)]
        [Required]
        public required string Password { get; set; }

        [Column("is_active", TypeName = "boolean")]
        [Required]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public ICollection<UTask> Tasks { get; set; } = new List<UTask>();
    }
}
