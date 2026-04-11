using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Loads.Infrastructure.Entity;

public sealed class LoadsEntityConfiguration : IEntityTypeConfiguration<LoadsEntity>
{
    public void Configure(EntityTypeBuilder<LoadsEntity> builder)
    {
        builder.ToTable("loads");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.OriginAddress)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.DestinationAddress)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.OriginCoords)
               .IsRequired()
               .HasColumnType("GEOGRAPHY(Point, 4326)");

        builder.Property(x => x.DestinationCoords)
               .IsRequired()
               .HasColumnType("GEOGRAPHY(Point, 4326)");

        builder.Property(x => x.WeightTons)
               .IsRequired()
               .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.VolumeM3)
               .IsRequired()
               .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.PickupDate)
               .IsRequired();

        builder.Property(x => x.OfferedPrice)
               .IsRequired()
               .HasColumnType("DECIMAL(19,4)");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        builder.HasOne(x => x.Customer)
               .WithMany()
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeLoad)
               .WithMany()
               .HasForeignKey(x => x.TypeLoadId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginCity)
               .WithMany()
               .HasForeignKey(x => x.OriginCityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DestinationCity)
               .WithMany()
               .HasForeignKey(x => x.DestinationCityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
               .WithMany()
               .HasForeignKey(x => x.StatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}