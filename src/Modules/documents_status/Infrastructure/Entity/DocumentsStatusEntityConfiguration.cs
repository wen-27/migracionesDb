using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;

public sealed class DocumentsStatusEntityConfiguration : IEntityTypeConfiguration<DocumentsStatusEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsStatusEntity> builder)
    {
        builder.ToTable("documents_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}