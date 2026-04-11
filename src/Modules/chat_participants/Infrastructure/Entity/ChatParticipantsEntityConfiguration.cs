using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.ChatParticipants.Infrastructure.Entity;

public class ChatParticipantsEntityConfiguration : IEntityTypeConfiguration<ChatParticipantsEntity>
{
    public void Configure(EntityTypeBuilder<ChatParticipantsEntity> builder)
    {
        builder.ToTable("chat_participants");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.chatroomid)
            .HasColumnName("chat_room_id")
            .IsRequired();

        builder.Property(x => x.personid)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(x => x.joinedat)
            .HasColumnName("joined_at")
            .IsRequired();

        builder.HasOne(x => x.ChatRoom)
            .WithMany()
            .HasForeignKey(x => x.chatroomid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.personid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}