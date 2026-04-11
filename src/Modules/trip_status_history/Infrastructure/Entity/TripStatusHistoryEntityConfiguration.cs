using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TripStatusHistory.Infrastructure.Entity;

public class TripStatusHistoryEntityConfiguration : IEntityTypeConfiguration<TripStatusHistoryEntity>
{
    public void Configure(EntityTypeBuilder<TripStatusHistoryEntity> builder)
    {
        builder.ToTable("trip_status_history");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired();

        builder.Property(x => x.statusname)
            .HasColumnName("status_name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.locationcoords)
            .HasColumnName("location_coords")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.notes)
            .HasColumnName("notes")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}