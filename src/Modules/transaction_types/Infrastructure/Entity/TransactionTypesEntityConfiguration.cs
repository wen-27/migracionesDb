using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TransactionTypes.Infrastructure.Entity;

public sealed class TransactionTypesEntityConfiguration : IEntityTypeConfiguration<TransactionTypesEntity>
{
    public void Configure(EntityTypeBuilder<TransactionTypesEntity> builder)
    {
        builder.ToTable("transaction_types");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}