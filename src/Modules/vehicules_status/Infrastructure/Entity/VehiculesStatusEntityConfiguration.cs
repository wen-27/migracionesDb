using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.VehiculesStatus.Infrastructure.Entity;

public sealed class VehiculesStatusEntityConfiguration : IEntityTypeConfiguration<VehiculesStatusEntity>
{
    public void Configure(EntityTypeBuilder<VehiculesStatusEntity> builder)
    {
        builder.ToTable("vehicules_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}