using System;
using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.MessageType.Infrastructure.Entity;

namespace DerTransporte.Modules.ChatMessages.Infrastructure.Entity;

public class ChatMessagesEntity
{
    public Guid id { get; set; }

    public Guid chatroomid { get; set; }
    public ChatRoomsEntity ChatRoom { get; set; } = null!;

    public Guid senderid { get; set; }
    public PersonsEntity Sender { get; set; } = null!;

    public Guid messagetypeid { get; set; }
    public MessageTypeEntity MessageType { get; set; } = null!;

    public string messagecontent { get; set; } = string.Empty;
    public bool isread { get; set; }
    public DateTime createdat { get; set; }
}