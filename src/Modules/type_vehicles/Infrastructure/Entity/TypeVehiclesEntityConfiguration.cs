using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TypeVehicles.Infrastructure.Entity;

public sealed class TypeVehiclesEntityConfiguration : IEntityTypeConfiguration<TypeVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<TypeVehiclesEntity> builder)
    {
        builder.ToTable("type_vehicles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.CapacityKg).HasColumnType("decimal(10,2)");
        builder.Property(x => x.Axles).HasColumnType("int(11)");
        builder.Property(x => x.CapacityM3).HasColumnType("decimal(10,2)");
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}