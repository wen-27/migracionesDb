using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Plans.Infrastructure.Entity;
using DerTransporte.Modules.Payments.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.PersonPlans.Infrastructure.Entity;

public class PersonPlansEntityConfiguration : IEntityTypeConfiguration<PersonPlansEntity>
{
    public void Configure(EntityTypeBuilder<PersonPlansEntity> builder)
    {
        builder.ToTable("person_plans");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.personid)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(x => x.planid)
            .HasColumnName("plan_id")
            .IsRequired();

        builder.Property(x => x.paymentid)
            .HasColumnName("payment_id")
            .IsRequired();

        builder.Property(x => x.creditsgranted)
            .HasColumnName("credits_granted")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.unitpriceatpurchase)
            .HasColumnName("unit_price_at_purchase")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(x => x.purchasedat)
            .HasColumnName("purchased_at")
            .IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.personid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Plan)
            .WithMany()
            .HasForeignKey(x => x.planid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Payment)
            .WithMany()
            .HasForeignKey(x => x.paymentid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}