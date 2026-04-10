using NetTopologySuite.Geometries;
using DerTransporte.Modules.Stateorregions.Infrastructure.Entity;

namespace DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;

public class CitiesormunicipalitiesEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid StateorregionId { get; set; }
    public string Code { get; set; } = string.Empty;
    public Point? Coordinates { get; set; }

    public StateorregionsEntity? Stateorregion { get; set; }
}
