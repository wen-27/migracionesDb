using DerTransporte.Modules.Bids.Infrastructure.Entity;
using DerTransporte.Modules.Loads.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Trips.Infrastructure.Entity;

public class TripsEntityConfiguration : IEntityTypeConfiguration<TripsEntity>
{
    public void Configure(EntityTypeBuilder<TripsEntity> builder)
    {
        builder.ToTable("trips");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.loadid)
            .HasColumnName("loadid")
            .IsRequired();

        builder.Property(x => x.bidid)
            .HasColumnName("bidid")
            .IsRequired();

        builder.Property(x => x.finalprice)
            .HasColumnName("finalprice")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.manifestnumber)
            .HasColumnName("manifestnumber")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.trackingtoken)
            .HasColumnName("trackingtoken")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.starttime)
            .HasColumnName("starttime")
            .IsRequired(false);

        builder.Property(x => x.endtime)
            .HasColumnName("endtime")
            .IsRequired(false);

        builder.Property(x => x.driverid)
            .HasColumnName("driverid")
            .IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany()
            .HasForeignKey(x => x.loadid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Bid)
            .WithMany()
            .HasForeignKey(x => x.bidid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}