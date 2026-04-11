using System;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.AssignmentRole.Infrastructure.Entity;

namespace DerTransporte.Modules.TripAssignments.Infrastructure.Entity;

public class TripAssignmentsEntity
{
    public Guid id { get; set; }

    public Guid tripid { get; set; }
    public TripsEntity Trip { get; set; } = null!;

    public Guid personid { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    public Guid assignmentroleid { get; set; }
    public AssignmentRoleEntity AssignmentRole { get; set; } = null!;

    public bool isactive { get; set; }
    public DateTime assignedat { get; set; }
}