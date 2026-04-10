namespace DerTransporte.Modules.DocumentCategory.Infrastructure.Entity;

public class DocumentCategoryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
