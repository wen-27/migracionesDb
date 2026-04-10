using DerTransporte.Modules.DocumentCategory.Infrastructure.Entity;

namespace DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;

public class TypeDocumentsEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? CategoryId { get; set; }

    public DocumentCategoryEntity? Category { get; set; }
}
