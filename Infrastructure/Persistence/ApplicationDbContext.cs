using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>().ToTable("Events")
                .HasQueryFilter(e=>!e.IsDeleted);
            modelBuilder.Entity<EventEntity>().Property(e => e.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<EventEntity>().Property(e => e.Location).HasMaxLength(255);
            modelBuilder.Entity<EventEntity>().Property(e => e.Description).HasMaxLength(500);

            base.OnModelCreating(modelBuilder);
        }
    }
}
