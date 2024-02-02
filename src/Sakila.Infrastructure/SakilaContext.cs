using Sakila.Model;
using Microsoft.EntityFrameworkCore;
using Sakila.Infrastructure.Configurations;

namespace Sakila.Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
public class SakilaContext : DbContext
{
    public SakilaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new FilmConfiguration())
            .ApplyConfiguration(new RentalConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
