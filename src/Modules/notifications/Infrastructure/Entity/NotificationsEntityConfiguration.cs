using DerTransporte.Modules.NotificationType.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Notifications.Infrastructure.Entity;

public class NotificationsEntityConfiguration : IEntityTypeConfiguration<NotificationsEntity>
{
    public void Configure(EntityTypeBuilder<NotificationsEntity> builder)
    {
        builder.ToTable("notifications");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.personid)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(x => x.title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.body)
            .HasColumnName("body")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.notificationtypeid)
            .HasColumnName("notification_type_id")
            .IsRequired();

        builder.Property(x => x.linkurl)
            .HasColumnName("link_url")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(x => x.isread)
            .HasColumnName("is_read")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.personid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.NotificationType)
            .WithMany()
            .HasForeignKey(x => x.notificationtypeid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}