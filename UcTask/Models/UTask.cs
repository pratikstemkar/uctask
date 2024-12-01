using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcTask.Models
{
    [Table("tasks")]
    public class UTask
    {
        [Column("id", TypeName = "int")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title", TypeName = "varchar")]
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }  // Removed `required` as it's a C# keyword

        [Column("description", TypeName = "text")]
        public string? Description { get; set; }

        [Column("user_id", TypeName = "int")]  // Added column name explicitly (for clarity)
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Column("is_deleted", TypeName = "boolean")]
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
