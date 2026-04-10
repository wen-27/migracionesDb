using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.ReasonDisputes.Infrastructure.Entity;

public sealed class ReasonDisputesEntityConfiguration : IEntityTypeConfiguration<ReasonDisputesEntity>
{
    public void Configure(EntityTypeBuilder<ReasonDisputesEntity> builder)
    {
        builder.ToTable("reason_disputes");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}