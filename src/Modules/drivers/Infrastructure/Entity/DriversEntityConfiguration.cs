using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.Drivers.Infrastructure.Entity;

public sealed class DriversEntityConfiguration : IEntityTypeConfiguration<DriversEntity>
{
    public void Configure(EntityTypeBuilder<DriversEntity> builder)
    {
        builder.ToTable("drivers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.LicenseCategory).IsRequired().HasMaxLength(5);
        builder.Property(x => x.ExperienceYears).IsRequired();
        builder.Property(x => x.IsAvailable).HasDefaultValue(true);

        // FK → persons
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}