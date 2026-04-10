using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.PersonStatus.Infrastructure.Entity;

public sealed class PersonStatusEntityConfiguration : IEntityTypeConfiguration<PersonStatusEntity>
{
    public void Configure(EntityTypeBuilder<PersonStatusEntity> builder)
    {
        builder.ToTable("person_status");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}