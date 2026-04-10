using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.RelationType.Infrastructure.Entity;

public sealed class RelationTypeEntityConfiguration : IEntityTypeConfiguration<RelationTypeEntity>
{
    public void Configure(EntityTypeBuilder<RelationTypeEntity> builder)
    {
        builder.ToTable("relation_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}