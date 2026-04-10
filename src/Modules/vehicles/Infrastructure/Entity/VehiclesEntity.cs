using DerTransporte.Modules.TypeVehicles.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.VehiculesStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.Vehicles.Infrastructure.Entity;

public class VehiclesEntity
{
    public Guid Id { get; set; }
    public string Plate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public string ChassisNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // FK → type_vehicules
    public Guid TypeVehicleId { get; set; }
    public TypeVehiclesEntity TypeVehicule { get; set; } = null!;

    // FK → persons (dueño)
    public Guid OwnerId { get; set; }
    public PersonsEntity Owner { get; set; } = null!;

    // FK → vehicules_status
    public Guid StatusId { get; set; }
    public VehiculesStatusEntity Status { get; set; } = null!;
}