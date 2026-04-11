using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.LoadDetails.Infrastructure.Entity;

public sealed class LoadDetailsEntityConfiguration : IEntityTypeConfiguration<LoadDetailsEntity>
{
    public void Configure(EntityTypeBuilder<LoadDetailsEntity> builder)
    {
        builder.ToTable("load_details");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.RequiresPackaging)
               .IsRequired();

        builder.Property(x => x.IsFragile)
               .IsRequired();

        builder.Property(x => x.IsStackable)
               .IsRequired();

        builder.Property(x => x.RequiredInsurance)
               .IsRequired();

        builder.Property(x => x.SpecialInstructions)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.Metadata)
               .IsRequired()
               .HasColumnType("JSON");

        builder.HasOne(x => x.Load)
               .WithMany()
               .HasForeignKey(x => x.LoadId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}