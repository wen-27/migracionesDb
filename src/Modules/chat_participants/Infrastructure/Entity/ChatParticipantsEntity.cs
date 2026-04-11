using System;
using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.ChatParticipants.Infrastructure.Entity;

public class ChatParticipantsEntity
{
    public Guid id { get; set; }

    public Guid chatroomid { get; set; }
    public ChatRoomsEntity ChatRoom { get; set; } = null!;

    public Guid personid { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    public DateTime joinedat { get; set; }
}