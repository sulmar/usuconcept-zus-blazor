using Auth.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Infrastructure;

public class AppIdentityContext : DbContext
{
    public AppIdentityContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserIdentity> UserIdentities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserIdentity>()
            .ToTable("customer");

        modelBuilder.Entity<UserIdentity>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<UserIdentity>()
            .Property(p => p.Id)
            .HasColumnName("customer_id");

        modelBuilder.Entity<UserIdentity>()
            .Property(p => p.FirstName)
            .HasColumnName("first_name");

        modelBuilder.Entity<UserIdentity>()
            .Property(p => p.LastName)
            .HasColumnName("last_name");

        modelBuilder.Entity<UserIdentity>()
            .Ignore(p => p.HashedPassword);

        modelBuilder.Entity<UserIdentity>()
            .Property(p => p.StoreId)
            .HasColumnName("store_id");

        base.OnModelCreating(modelBuilder);
    }
}
