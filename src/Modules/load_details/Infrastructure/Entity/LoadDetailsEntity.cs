using DerTransporte.Modules.Loads.Infrastructure.Entity;

namespace DerTransporte.Modules.LoadDetails.Infrastructure.Entity;

public class LoadDetailsEntity
{
    public Guid Id { get; set; }

    public bool RequiresPackaging { get; set; }
    public bool IsFragile { get; set; }
    public bool IsStackable { get; set; }
    public bool RequiredInsurance { get; set; }

    public string SpecialInstructions { get; set; } = string.Empty;
    public string Metadata { get; set; } = string.Empty;

    // FK → loads
    public Guid LoadId { get; set; }
    public LoadsEntity Load { get; set; } = null!;
}