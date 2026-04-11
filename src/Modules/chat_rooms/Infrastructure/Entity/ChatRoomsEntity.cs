using System;
using DerTransporte.Modules.Loads.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.StatusChat.Infrastructure.Entity;

namespace DerTransporte.Modules.ChatRooms.Infrastructure.Entity;

public class ChatRoomsEntity
{
    public Guid id { get; set; }

    public Guid? loadid { get; set; }
    public LoadsEntity? Load { get; set; }

    public Guid? tripid { get; set; }
    public TripsEntity? Trip { get; set; }

    public Guid statusid { get; set; }
    public StatusChatEntity Status { get; set; } = null!;

    public DateTime createdat { get; set; }
}