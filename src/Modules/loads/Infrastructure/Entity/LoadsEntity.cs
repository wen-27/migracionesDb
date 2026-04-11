using DerTransporte.Modules.Customers.Infrastructure.Entity;
using DerTransporte.Modules.TypeLoad.Infrastructure.Entity;
using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Modules.LoadStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.Loads.Infrastructure.Entity;

public class LoadsEntity
{
    public Guid Id { get; set; }

    public string OriginAddress { get; set; } = string.Empty;
    public string DestinationAddress { get; set; } = string.Empty;

    public string OriginCoords { get; set; } = string.Empty;
    public string DestinationCoords { get; set; } = string.Empty;

    public decimal WeightTons { get; set; }
    public decimal VolumeM3 { get; set; }
    public DateTime PickupDate { get; set; }
    public decimal OfferedPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    // FK → customers
    public Guid CustomerId { get; set; }
    public CustomersEntity Customer { get; set; } = null!;

    // FK → type_load
    public Guid TypeLoadId { get; set; }
    public TypeLoadEntity TypeLoad { get; set; } = null!;

    // FK → citiesormunicipalities
    public Guid OriginCityId { get; set; }
    public CitiesormunicipalitiesEntity OriginCity { get; set; } = null!;

    // FK → citiesormunicipalities
    public Guid DestinationCityId { get; set; }
    public CitiesormunicipalitiesEntity DestinationCity { get; set; } = null!;

    // FK → load_status
    public Guid StatusId { get; set; }
    public LoadStatusEntity Status { get; set; } = null!;
}