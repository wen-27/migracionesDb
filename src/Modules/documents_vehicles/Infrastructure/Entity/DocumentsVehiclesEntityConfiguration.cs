using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.DocumentsVehicles.Infrastructure.Entity;

public sealed class DocumentsVehiclesEntityConfiguration : IEntityTypeConfiguration<DocumentsVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsVehiclesEntity> builder)
    {
        builder.ToTable("documents_vehicles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ExpirationDate).IsRequired().HasColumnType("DATE");
        builder.Property(x => x.FileUrl).IsRequired().HasColumnType("TEXT");
        builder.Property(x => x.ReviewedAt).IsRequired(false);

        // FK → vehicles
        builder.HasOne(x => x.Vehicle)
               .WithMany()
               .HasForeignKey(x => x.VehicleId)
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