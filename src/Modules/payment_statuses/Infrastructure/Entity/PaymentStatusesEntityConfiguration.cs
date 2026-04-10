using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.PaymentStatuses.Infrastructure.Entity;

public sealed class PaymentStatusesEntityConfiguration : IEntityTypeConfiguration<PaymentStatusesEntity>
{
    public void Configure(EntityTypeBuilder<PaymentStatusesEntity> builder)
    {
        builder.ToTable("payment_statuses");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}