using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TravelScale.Infrastructure.Entity;

public class TravelScaleEntityConfiguration : IEntityTypeConfiguration<TravelScaleEntity>
{
    public void Configure(EntityTypeBuilder<TravelScaleEntity> builder)
    {
        builder.ToTable("travel_scale");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired();

        builder.Property(x => x.cityid)
            .HasColumnName("city_id")
            .IsRequired();

        builder.Property(x => x.sequence)
            .HasColumnName("sequence")
            .IsRequired();

        builder.Property(x => x.arrivalestimated)
            .HasColumnName("arrival_estimated")
            .IsRequired();

        builder.Property(x => x.arrivalactual)
            .HasColumnName("arrival_actual")
            .IsRequired(false);

        builder.Property(x => x.departureactual)
            .HasColumnName("departure_actual")
            .IsRequired(false);

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.cityid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}