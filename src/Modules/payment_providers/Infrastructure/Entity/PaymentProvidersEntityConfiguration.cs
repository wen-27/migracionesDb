using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.PaymentProviders.Infrastructure.Entity;

public sealed class PaymentProvidersEntityConfiguration : IEntityTypeConfiguration<PaymentProvidersEntity>
{
    public void Configure(EntityTypeBuilder<PaymentProvidersEntity> builder)
    {
        builder.ToTable("payment_providers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}