using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Modules.MessageType.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.ChatMessages.Infrastructure.Entity;

public class ChatMessagesEntityConfiguration : IEntityTypeConfiguration<ChatMessagesEntity>
{
    public void Configure(EntityTypeBuilder<ChatMessagesEntity> builder)
    {
        builder.ToTable("chat_messages");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.chatroomid)
            .HasColumnName("chat_room_id")
            .IsRequired();

        builder.Property(x => x.senderid)
            .HasColumnName("sender_id")
            .IsRequired();

        builder.Property(x => x.messagetypeid)
            .HasColumnName("message_type_id")
            .IsRequired();

        builder.Property(x => x.messagecontent)
            .HasColumnName("message_content")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.isread)
            .HasColumnName("is_read")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.ChatRoom)
            .WithMany()
            .HasForeignKey(x => x.chatroomid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Sender)
            .WithMany()
            .HasForeignKey(x => x.senderid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MessageType)
            .WithMany()
            .HasForeignKey(x => x.messagetypeid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}