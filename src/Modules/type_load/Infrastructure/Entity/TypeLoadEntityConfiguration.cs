using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TypeLoad.Infrastructure.Entity;

public sealed class TypeLoadEntityConfiguration : IEntityTypeConfiguration<TypeLoadEntity>
{
    public void Configure(EntityTypeBuilder<TypeLoadEntity> builder)
    {
        builder.ToTable("type_load");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}