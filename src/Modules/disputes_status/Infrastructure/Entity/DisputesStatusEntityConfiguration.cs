using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.DisputesStatus.Infrastructure.Entity;

public sealed class DisputesStatusEntityConfiguration : IEntityTypeConfiguration<DisputesStatusEntity>
{
    public void Configure(EntityTypeBuilder<DisputesStatusEntity> builder)
    {
        builder.ToTable("disputes_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}