namespace DerTransporte.Modules.TypeVehicles.Infrastructure.Entity;

public class TypeVehiclesEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal CapacityKg { get; set; }
    public int Axles { get; set; }
    public decimal CapacityM3 { get; set; }
    public string Description { get; set; } = string.Empty;
}
