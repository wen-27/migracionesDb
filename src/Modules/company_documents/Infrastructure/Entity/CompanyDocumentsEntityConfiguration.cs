using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.CompanyDocuments.Infrastructure.Entity;

public sealed class CompanyDocumentsEntityConfiguration : IEntityTypeConfiguration<CompanyDocumentsEntity>
{
    public void Configure(EntityTypeBuilder<CompanyDocumentsEntity> builder)
    {
        builder.ToTable("company_documents");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.FileUrl).IsRequired().HasColumnType("TEXT");
        builder.Property(x => x.ExpirationDate).IsRequired().HasColumnType("DATE");

        // FK → transport_companies
        builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
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