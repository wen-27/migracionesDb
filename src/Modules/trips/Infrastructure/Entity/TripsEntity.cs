using System;
using DerTransporte.Modules.Loads.Infrastructure.Entity;
using DerTransporte.Modules.Bids.Infrastructure.Entity;

namespace DerTransporte.Modules.Trips.Infrastructure.Entity;

public class TripsEntity
{
    public Guid id { get; set; }

    public Guid loadid { get; set; }
    public LoadsEntity Load { get; set; } = null!;

    public Guid bidid { get; set; }
    public BidsEntity Bid { get; set; } = null!;

    public decimal finalprice { get; set; }
    public string manifestnumber { get; set; } = string.Empty;
    public string trackingtoken { get; set; } = string.Empty;
    public DateTime? starttime { get; set; }
    public DateTime? endtime { get; set; }
    public Guid driverid { get; set; }
}