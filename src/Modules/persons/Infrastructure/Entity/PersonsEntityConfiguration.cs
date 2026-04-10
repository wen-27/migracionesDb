using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Persons.Infrastructure.Entity;

public sealed class PersonsEntityConfiguration : IEntityTypeConfiguration<PersonsEntity>
{
    public void Configure(EntityTypeBuilder<PersonsEntity> builder)
    {
        builder.ToTable("persons");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        builder.HasOne(x => x.City)
        .WithMany()
        .HasForeignKey(x => x.CityId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.PersonStatus)
        .WithMany()
        .HasForeignKey(x => x.PersonStatusId)
        .OnDelete(DeleteBehavior.Cascade);

    }
}