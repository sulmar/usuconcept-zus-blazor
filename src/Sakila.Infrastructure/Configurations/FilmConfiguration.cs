using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakila.Model;

namespace Sakila.Infrastructure.Configurations;

internal class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder
            .ToTable("film");

        builder
            .HasKey(e => e.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("film_id");

        builder
            .Property(p => p.ReleaseYear)
            .HasColumnName("release_year");

        builder
            .Property(p => p.RentalDuration)
            .HasColumnName("rental_duration")
            .HasColumnType("tinyint");

        builder
            .Property(p => p.RentalRate)
            .HasColumnName("rental_rate");
    }
}
