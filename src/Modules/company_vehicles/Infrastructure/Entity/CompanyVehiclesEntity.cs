using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;
using DerTransporte.Modules.Vehicles.Infrastructure.Entity;

namespace DerTransporte.Modules.CompanyVehicles.Infrastructure.Entity;

public class CompanyVehiclesEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }

    // FK → transport_companies
    public Guid CompanyId { get; set; }
    public TransportCompaniesEntity Company { get; set; } = null!;

    // FK → vehicles
    public Guid VehicleId { get; set; }
    public VehiclesEntity Vehicle { get; set; } = null!;
}