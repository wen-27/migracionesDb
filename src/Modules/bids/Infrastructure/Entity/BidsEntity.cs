using DerTransporte.Modules.Loads.Infrastructure.Entity;

namespace DerTransporte.Modules.Bids.Infrastructure.Entity;

public class BidsEntity
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime? EtaToPickup { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // FK → loads
    public Guid LoadId { get; set; }
    public LoadsEntity Load { get; set; } = null!;
}