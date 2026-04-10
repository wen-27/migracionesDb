using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.Customers.Infrastructure.Entity;

public sealed class CustomersEntityConfiguration : IEntityTypeConfiguration<CustomersEntity>
{
    public void Configure(EntityTypeBuilder<CustomersEntity> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.IsFrecuent).HasDefaultValue(true);

        // FK nullable → persons
        builder.Property(x => x.PersonId).IsRequired(false);
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}