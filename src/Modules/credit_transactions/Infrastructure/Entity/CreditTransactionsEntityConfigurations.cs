using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Modules.TransactionTypes.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.CreditTransactions.Infrastructure.Entity;

public class CreditTransactionsEntityConfiguration : IEntityTypeConfiguration<CreditTransactionsEntity>
{
    public void Configure(EntityTypeBuilder<CreditTransactionsEntity> builder)
    {
        builder.ToTable("credit_transactions");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.walletid)
            .HasColumnName("wallet_id")
            .IsRequired();

        builder.Property(x => x.transactiontypeid)
            .HasColumnName("transaction_type_id")
            .IsRequired();

        builder.Property(x => x.amount)
            .HasColumnName("amount")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.balanceafter)
            .HasColumnName("balance_after")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.referenceid)
            .HasColumnName("reference_id")
            .IsRequired();

        builder.Property(x => x.description)
            .HasColumnName("description")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Wallet)
            .WithMany()
            .HasForeignKey(x => x.walletid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TransactionType)
            .WithMany()
            .HasForeignKey(x => x.transactiontypeid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}