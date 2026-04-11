using System;
using DerTransporte.Modules.Trips.Infrastructure.Entity;

namespace DerTransporte.Modules.TripStatusHistory.Infrastructure.Entity;

public class TripStatusHistoryEntity
{
    public Guid id { get; set; }

    public Guid tripid { get; set; }
    public TripsEntity Trip { get; set; } = null!;

    public string statusname { get; set; } = string.Empty;
    public string locationcoords { get; set; } = string.Empty;
    public string notes { get; set; } = string.Empty;
    public DateTime createdat { get; set; }
}