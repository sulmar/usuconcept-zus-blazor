using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakila.Model;

namespace Sakila.Infrastructure.Configurations;

internal class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder
            .ToTable("rental");

        builder
        .HasKey(e => e.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("rental_id");

        builder
            .Property(p => p.RentalDate)
            .HasColumnName("rental_date");

        builder
            .Property(p => p.ReturnDate)
            .HasColumnName("return_date");

        builder
            .Property(p => p.CustomerId)
            .HasColumnName("customer_id");
    }
}
