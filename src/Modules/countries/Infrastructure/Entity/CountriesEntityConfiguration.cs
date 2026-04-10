using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Countries.Infrastructure.Entity;

public sealed class CountriesEntityConfiguration : IEntityTypeConfiguration<CountriesEntity>
{
    public void Configure(EntityTypeBuilder<CountriesEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Isocode).HasMaxLength(3);
        builder.Property(x => x.Name).HasMaxLength(60);
        builder.Property(x => x.PhoneCode).HasMaxLength(5);

        builder.HasIndex(x => x.Isocode).IsUnique();;
    }
}