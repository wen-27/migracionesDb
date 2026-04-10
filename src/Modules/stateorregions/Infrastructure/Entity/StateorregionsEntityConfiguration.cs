using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Stateorregions.Infrastructure.Entity;

public sealed class StateorregionsEntityConfiguration : IEntityTypeConfiguration<StateorregionsEntity>
{
    public void Configure(EntityTypeBuilder<StateorregionsEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(60);
        builder.Property(X => X.CountryId);
        builder.Property(x => x.Code).HasMaxLength(10);

        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);   
    }
}