using System;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.ReasonDisputes.Infrastructure.Entity;
using DerTransporte.Modules.DisputesStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.Disputes.Infrastructure.Entity;

public class DisputesEntity
{
    public Guid id { get; set; }

    public Guid tripid { get; set; }
    public TripsEntity Trip { get; set; } = null!;

    public Guid createdby { get; set; }
    public PersonsEntity CreatedBy { get; set; } = null!;

    public Guid reasoncategoryid { get; set; }
    public ReasonDisputesEntity ReasonCategory { get; set; } = null!;

    public string description { get; set; } = string.Empty;
    public string? evidenceurl { get; set; }

    public Guid statusid { get; set; }
    public DisputesStatusEntity Status { get; set; } = null!;
}