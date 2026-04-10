using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Roles.Infrastructure.Entity;

namespace DerTransporte.Modules.PersonRoles.Infrastructure.Entity;

public sealed class PersonRolesEntityConfiguration : IEntityTypeConfiguration<PersonRolesEntity>
{
    public void Configure(EntityTypeBuilder<PersonRolesEntity> builder)
    {
        builder.ToTable("person_roles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        // FK → roles
        builder.Property(x => x.RoleId).IsRequired(false);
        builder.HasOne(x => x.Role)
               .WithMany()
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK nullable → persons
        builder.Property(x => x.PersonId).IsRequired(false);
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}