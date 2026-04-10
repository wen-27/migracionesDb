using NetTopologySuite.Geometries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;

public sealed class CitiesormunicipalitiesEntityConfiguration : IEntityTypeConfiguration<CitiesormunicipalitiesEntity>
{
    public void Configure(EntityTypeBuilder<CitiesormunicipalitiesEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).HasMaxLength(60);
        builder.Property(x => x.Code).HasMaxLength(10);
        builder.Property(x => x.Coordinates)
        .HasColumnType("point")
        .IsRequired(false);

        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.Stateorregion)
            .WithMany()
            .HasForeignKey(x => x.StateorregionId)      
            .OnDelete(DeleteBehavior.Cascade);
    }
}