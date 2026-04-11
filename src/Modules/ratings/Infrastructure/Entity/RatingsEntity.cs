using System;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.Ratings.Infrastructure.Entity;

public class RatingsEntity
{
    public Guid id { get; set; }

    public Guid tripid { get; set; }
    public TripsEntity Trip { get; set; } = null!;

    public Guid evaluatorid { get; set; }
    public PersonsEntity Evaluator { get; set; } = null!;

    public Guid evaluatedid { get; set; }
    public PersonsEntity Evaluated { get; set; } = null!;

    public short score { get; set; }
    public string comment { get; set; } = string.Empty;
    public DateTime createdat { get; set; }
}