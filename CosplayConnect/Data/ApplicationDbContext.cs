// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Role).IsRequired();

            entity.Property(e => e.Tags)
                .HasColumnType("jsonb");

            entity.Property(e => e.Events)
                .HasColumnType("jsonb");

            entity.Property(e => e.Photos)
                .HasColumnType("jsonb");

            entity.Property(e => e.SocialLinks)
                .HasColumnType("jsonb");
        });
    }
}