using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.LoadImages.Infrastructure.Entity;

public sealed class LoadImagesEntityConfiguration : IEntityTypeConfiguration<LoadImagesEntity>
{
    public void Configure(EntityTypeBuilder<LoadImagesEntity> builder)
    {
        builder.ToTable("load_images");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.ImageUrl)
               .IsRequired()
               .HasColumnType("TEXT");

        builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasOne(x => x.Load)
               .WithMany()
               .HasForeignKey(x => x.LoadId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}