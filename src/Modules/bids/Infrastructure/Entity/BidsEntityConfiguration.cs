using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Bids.Infrastructure.Entity;

public sealed class BidsEntityConfiguration : IEntityTypeConfiguration<BidsEntity>
{
    public void Configure(EntityTypeBuilder<BidsEntity> builder)
    {
        builder.ToTable("bids");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Amount)
               .IsRequired()
               .HasColumnType("DECIMAL(19,4)");

        builder.Property(x => x.EtaToPickup)
               .IsRequired(false);

        builder.Property(x => x.Notes)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        builder.HasOne(x => x.Load)
               .WithMany()
               .HasForeignKey(x => x.LoadId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}