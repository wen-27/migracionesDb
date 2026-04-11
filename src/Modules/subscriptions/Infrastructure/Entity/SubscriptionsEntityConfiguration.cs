using DerTransporte.Modules.Payments.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionStatus.Infrastructure.Entity;
using DerTransporte.Modules.SubscriptionType.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Subscriptions.Infrastructure.Entity;

public class SubscriptionsEntityConfiguration : IEntityTypeConfiguration<SubscriptionsEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionsEntity> builder)
    {
        builder.ToTable("subscriptions");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.personid)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(x => x.subscriptiontypeid)
            .HasColumnName("subscription_type_id")
            .IsRequired();

        builder.Property(x => x.startdate)
            .HasColumnName("start_date")
            .IsRequired();

        builder.Property(x => x.enddate)
            .HasColumnName("end_date")
            .IsRequired();

        builder.Property(x => x.statusid)
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.autorenew)
            .HasColumnName("auto_renew")
            .IsRequired();

        builder.Property(x => x.paymentid)
            .HasColumnName("payment_id")
            .IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.personid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SubscriptionType)
            .WithMany()
            .HasForeignKey(x => x.subscriptiontypeid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.statusid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Payment)
            .WithMany()
            .HasForeignKey(x => x.paymentid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}