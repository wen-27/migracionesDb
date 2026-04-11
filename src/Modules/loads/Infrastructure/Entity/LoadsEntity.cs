using DerTransporte.Modules.Customers.Infrastructure.Entity;
using DerTransporte.Modules.TypeLoad.Infrastructure.Entity;
using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;

namespace DerTransporte.Modules.Loads.Infrastructure.Entity;

public class LoadsEntity
{
    public Guid Id { get; set; }

    public string OriginAddress { get; set; } = string.Empty;
    public string DestinationAddress { get; set; } = string.Empty;

    // Temporalmente como texto para evitar error de migración
    public string OriginCoords { get; set; } = string.Empty;
    public string DestinationCoords { get; set; } = string.Empty;

    public decimal WeightTons { get; set; }
    public decimal VolumeM3 { get; set; }
    public DateTime PickupDate { get; set; }
    public decimal OfferedPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid CustomerId { get; set; }
    public CustomersEntity Customer { get; set; } = null!;

    public Guid TypeLoadId { get; set; }
    public TypeLoadEntity TypeLoad { get; set; } = null!;

    public Guid OriginCityId { get; set; }
    public CitiesormunicipalitiesEntity OriginCity { get; set; } = null!;

    public Guid DestinationCityId { get; set; }
    public CitiesormunicipalitiesEntity DestinationCity { get; set; } = null!;

    public Guid StatusId { get; set; }
}