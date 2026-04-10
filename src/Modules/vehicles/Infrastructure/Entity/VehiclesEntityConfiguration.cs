using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Vehicles.Infrastructure.Entity;

public sealed class VehiclesEntityConfiguration : IEntityTypeConfiguration<VehiclesEntity>
{
    public void Configure(EntityTypeBuilder<VehiclesEntity> builder)
    {
        builder.ToTable("vehicles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Plate).IsRequired().HasMaxLength(10);
        builder.HasIndex(x => x.Plate).IsUnique();

        builder.Property(x => x.Brand).HasMaxLength(50);
        builder.Property(x => x.Model).HasMaxLength(50);
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(30);
        builder.Property(x => x.ChassisNumber).HasMaxLength(50);
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        // FK → type_vehicles
        builder.HasOne(x => x.TypeVehicule)
               .WithMany()
               .HasForeignKey(x => x.TypeVehicleId) // ← corregido
               .OnDelete(DeleteBehavior.Restrict);

        // FK → persons (owner)
        builder.HasOne(x => x.Owner)
               .WithMany()
               .HasForeignKey(x => x.OwnerId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → vehicules_status
        builder.HasOne(x => x.Status)
               .WithMany()
               .HasForeignKey(x => x.StatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}