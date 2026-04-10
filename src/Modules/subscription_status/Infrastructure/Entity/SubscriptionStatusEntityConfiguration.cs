using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.SubscriptionStatus.Infrastructure.Entity;

public sealed class SubscriptionStatusEntityConfiguration : IEntityTypeConfiguration<SubscriptionStatusEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionStatusEntity> builder)
    {
        builder.ToTable("subscription_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}