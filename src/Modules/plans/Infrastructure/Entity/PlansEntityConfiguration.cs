using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Plans.Infrastructure.Entity;

public sealed class PlansEntityConfiguration : IEntityTypeConfiguration<PlansEntity>
{
    public void Configure(EntityTypeBuilder<PlansEntity> builder)
    {
        builder.ToTable("plans");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.CreditAmount).HasColumnType("decimal(19,4)");
        builder.Property(x => x.Price).HasColumnType("decimal(19,4)");
        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}