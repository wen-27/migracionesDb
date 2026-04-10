using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.DocumentsDrivers.Infrastructure.Entity;

public sealed class DocumentsDriversEntityConfiguration : IEntityTypeConfiguration<DocumentsDriversEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsDriversEntity> builder)
    {
        builder.ToTable("documents_drivers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(30);
        builder.Property(x => x.ExpirationDate).IsRequired().HasColumnType("DATE");
        builder.Property(x => x.FileUrl).IsRequired().HasColumnType("TEXT");

        // FK → drivers
        builder.HasOne(x => x.Driver)
               .WithMany()
               .HasForeignKey(x => x.DriverId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → type_documents
        builder.HasOne(x => x.TypeDocument)
               .WithMany()
               .HasForeignKey(x => x.TypeDocumentId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → documents_status
        builder.HasOne(x => x.DocumentStatus)
               .WithMany()
               .HasForeignKey(x => x.DocumentStatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}