using DerTransporte.Modules.Loads.Infrastructure.Entity;

namespace DerTransporte.Modules.LoadImages.Infrastructure.Entity;

public class LoadImagesEntity
{
    public Guid Id { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // FK → loads
    public Guid LoadId { get; set; }
    public LoadsEntity Load { get; set; } = null!;
}