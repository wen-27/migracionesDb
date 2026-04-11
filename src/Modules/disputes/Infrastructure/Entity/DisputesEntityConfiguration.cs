using DerTransporte.Modules.DisputesStatus.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.ReasonDisputes.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Disputes.Infrastructure.Entity;

public class DisputesEntityConfiguration : IEntityTypeConfiguration<DisputesEntity>
{
    public void Configure(EntityTypeBuilder<DisputesEntity> builder)
    {
        builder.ToTable("disputes");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired();

        builder.Property(x => x.createdby)
            .HasColumnName("created_by")
            .IsRequired();

        builder.Property(x => x.reasoncategoryid)
            .HasColumnName("reason_category_id")
            .IsRequired();

        builder.Property(x => x.description)
            .HasColumnName("description")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.evidenceurl)
            .HasColumnName("evidence_url")
            .HasColumnType("TEXT")
            .IsRequired(false);

        builder.Property(x => x.statusid)
            .HasColumnName("status_id")
            .IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.createdby)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ReasonCategory)
            .WithMany()
            .HasForeignKey(x => x.reasoncategoryid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.statusid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}