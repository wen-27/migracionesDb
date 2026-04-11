using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.DocumentsCustomers.Infrastructure.Entity;

public sealed class DocumentsCustomersEntityConfiguration : IEntityTypeConfiguration<DocumentsCustomersEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsCustomersEntity> builder)
    {
        builder.ToTable("documents_customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(30);
        builder.Property(x => x.FileUrl).IsRequired().HasColumnType("TEXT");

        builder.HasOne(x => x.Customer)
               .WithMany()
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeDocument)
               .WithMany()
               .HasForeignKey(x => x.TypeDocumentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DocumentStatus)
               .WithMany()
               .HasForeignKey(x => x.DocumentStatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}