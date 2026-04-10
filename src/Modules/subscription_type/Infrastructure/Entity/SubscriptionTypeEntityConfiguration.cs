using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.SubscriptionType.Infrastructure.Entity;

public sealed class SubscriptionTypeEntityConfiguration : IEntityTypeConfiguration<SubscriptionTypeEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionTypeEntity> builder)
    {
        builder.ToTable("subscription_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}