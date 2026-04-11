using DerTransporte.Modules.Loads.Infrastructure.Entity;
using DerTransporte.Modules.StatusChat.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.ChatRooms.Infrastructure.Entity;

public class ChatRoomsEntityConfiguration : IEntityTypeConfiguration<ChatRoomsEntity>
{
    public void Configure(EntityTypeBuilder<ChatRoomsEntity> builder)
    {
        builder.ToTable("chat_rooms");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.loadid)
            .HasColumnName("load_id")
            .IsRequired(false);

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired(false);

        builder.Property(x => x.statusid)
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany()
            .HasForeignKey(x => x.loadid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.statusid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}