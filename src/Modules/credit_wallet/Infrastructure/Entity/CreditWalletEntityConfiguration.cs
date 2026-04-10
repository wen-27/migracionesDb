using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.CreditWallet.Infrastructure.Entity;

public sealed class CreditWalletEntityConfiguration : IEntityTypeConfiguration<CreditWalletEntity>
{
    public void Configure(EntityTypeBuilder<CreditWalletEntity> builder)
    {
        builder.ToTable("credit_wallet");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Balance)
               .IsRequired()
               .HasColumnType("DECIMAL(19,4)");

        builder.Property(x => x.LastUpdate)
               .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        // FK nullable → persons
        builder.Property(x => x.PersonId).IsRequired(false);
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK nullable → transport_companies
        builder.Property(x => x.CompanyId).IsRequired(false);
        builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}