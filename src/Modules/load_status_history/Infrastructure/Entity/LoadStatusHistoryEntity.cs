using DerTransporte.Modules.Loads.Infrastructure.Entity;

namespace DerTransporte.Modules.LoadStatusHistory.Infrastructure.Entity;

public class LoadStatusHistoryEntity
{
    public Guid Id { get; set; }

    public string StatusName { get; set; } = string.Empty;

    // Temporalmente como string para evitar problemas con GEOGRAPHY(Point, 4326)
    public string LocationCoords { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // FK → loads
    public Guid LoadId { get; set; }
    public LoadsEntity Load { get; set; } = null!;
}