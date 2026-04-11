using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.LoadStatusHistory.Infrastructure.Entity;

public sealed class LoadStatusHistoryEntityConfiguration : IEntityTypeConfiguration<LoadStatusHistoryEntity>
{
    public void Configure(EntityTypeBuilder<LoadStatusHistoryEntity> builder)
    {
        builder.ToTable("load_status_history");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.StatusName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.LocationCoords)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.Notes)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        builder.HasOne(x => x.Load)
               .WithMany()
               .HasForeignKey(x => x.LoadId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
