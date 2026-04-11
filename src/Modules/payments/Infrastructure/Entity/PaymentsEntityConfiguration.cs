using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Modules.PaymentProviders.Infrastructure.Entity;
using DerTransporte.Modules.PaymentStatuses.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Payments.Infrastructure.Entity;

public class PaymentsEntityConfiguration : IEntityTypeConfiguration<PaymentsEntity>
{
    public void Configure(EntityTypeBuilder<PaymentsEntity> builder)
    {
        builder.ToTable("payments");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.walletid)
            .HasColumnName("wallet_id")
            .IsRequired();

        builder.Property(x => x.paymentproviderid)
            .HasColumnName("payment_provider_id")
            .IsRequired();

        builder.Property(x => x.statusid)
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.externalreference)
            .HasColumnName("external_reference")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.amountmoney)
            .HasColumnName("amount_money")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Wallet)
            .WithMany()
            .HasForeignKey(x => x.walletid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentProvider)
            .WithMany()
            .HasForeignKey(x => x.paymentproviderid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.statusid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}