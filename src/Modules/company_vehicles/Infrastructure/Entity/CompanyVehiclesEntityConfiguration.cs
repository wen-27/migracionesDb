using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.CompanyVehicles.Infrastructure.Entity;

public sealed class CompanyVehiclesEntityConfiguration : IEntityTypeConfiguration<CompanyVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<CompanyVehiclesEntity> builder)
    {
        builder.ToTable("company_vehicles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        // FK → transport_companies
        builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → vehicles
        builder.HasOne(x => x.Vehicle)
               .WithMany()
               .HasForeignKey(x => x.VehicleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}