using DerTransporte.Modules.Vehicles.Infrastructure.Entity;
using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.DocumentsVehicles.Infrastructure.Entity;

public class DocumentsVehiclesEntity
{
    public Guid Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateOnly ExpirationDate { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public DateTime? ReviewedAt { get; set; }

    // FK → vehicles
    public Guid VehicleId { get; set; }
    public VehiclesEntity Vehicle { get; set; } = null!;

    // FK → type_documents
    public Guid TypeDocumentId { get; set; }
    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    // FK → documents_status
    public Guid DocumentStatusId { get; set; }
    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}