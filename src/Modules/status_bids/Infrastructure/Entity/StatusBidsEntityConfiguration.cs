using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.StatusBids.Infrastructure.Entity;

public sealed class StatusBidsEntityConfiguration : IEntityTypeConfiguration<StatusBidsEntity>
{
    public void Configure(EntityTypeBuilder<StatusBidsEntity> builder)
    {
        builder.ToTable("status_bids");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}