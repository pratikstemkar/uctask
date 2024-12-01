using Microsoft.EntityFrameworkCore;
using UcTask.Models;

namespace UcTask.Data
{
    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
