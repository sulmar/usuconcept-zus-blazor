using BlazorSSRSakilaApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorSSRSakilaApp.Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
public class SakilaContext : DbContext
{
    public DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
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

        base.OnModelCreating(modelBuilder);
    }
}
