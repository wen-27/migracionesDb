using DerTransporte.Modules.Drivers.Infrastructure.Entity;
using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.DocumentsDrivers.Infrastructure.Entity;

public class DocumentsDriversEntity
{
    public Guid Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateOnly ExpirationDate { get; set; }    // DATE → DateOnly
    public string FileUrl { get; set; } = string.Empty;

    // FK → drivers
    public Guid DriverId { get; set; }
    public DriversEntity Driver { get; set; } = null!;

    // FK → type_documents
    public Guid TypeDocumentId { get; set; }
    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    // FK → documents_status
    public Guid DocumentStatusId { get; set; }
    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}