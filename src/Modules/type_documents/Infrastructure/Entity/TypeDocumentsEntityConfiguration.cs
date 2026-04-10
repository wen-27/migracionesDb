using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;

public sealed class TypeDocumentsEntityConfiguration : IEntityTypeConfiguration<TypeDocumentsEntity>
{
    public void Configure(EntityTypeBuilder<TypeDocumentsEntity> builder)
    {

        builder.ToTable("type_documents");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.CategoryId);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}