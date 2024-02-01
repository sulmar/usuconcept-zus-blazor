using Sakila.Model;
using Microsoft.EntityFrameworkCore;

namespace Sakila.Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
public class SakilaContext : DbContext
{
    public SakilaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>()
            .ToTable("film");

        modelBuilder.Entity<Film>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Film>()
            .Property(p => p.Id)
            .HasColumnName("film_id");

        modelBuilder.Entity<Film>()
            .Property(p => p.ReleaseYear)
            .HasColumnName("release_year");

        modelBuilder.Entity<Film>()
            .Property(p => p.RentalDuration)
            .HasColumnName("rental_duration")
            .HasColumnType("tinyint");

        modelBuilder.Entity<Film>()
            .Property(p => p.RentalRate)
            .HasColumnName("rental_rate");

        base.OnModelCreating(modelBuilder);
    }
}
