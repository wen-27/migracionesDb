using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.CompaniesStatus.Infrastructure.Entity;

public sealed class CompaniesStatusEntityConfiguration : IEntityTypeConfiguration<CompaniesStatusEntity>
{
    public void Configure(EntityTypeBuilder<CompaniesStatusEntity> builder)
    {
        builder.ToTable("companies_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}