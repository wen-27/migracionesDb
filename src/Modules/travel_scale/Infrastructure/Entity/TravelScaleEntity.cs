using System;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;

namespace DerTransporte.Modules.TravelScale.Infrastructure.Entity;

public class TravelScaleEntity
{
    public Guid id { get; set; }

    public Guid tripid { get; set; }
    public TripsEntity Trip { get; set; } = null!;

    public Guid cityid { get; set; }
    public CitiesormunicipalitiesEntity City { get; set; } = null!;

    public short sequence { get; set; }
    public DateTime arrivalestimated { get; set; }
    public DateTime? arrivalactual { get; set; }
    public DateTime? departureactual { get; set; }
}