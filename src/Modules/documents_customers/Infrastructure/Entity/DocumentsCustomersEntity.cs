using DerTransporte.Modules.Customers.Infrastructure.Entity;
using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.DocumentsCustomers.Infrastructure.Entity;

public class DocumentsCustomersEntity
{
    public Guid Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;

    // FK → customers
    public Guid CustomerId { get; set; }
    public CustomersEntity Customer { get; set; } = null!;

    // FK → type_documents
    public Guid TypeDocumentId { get; set; }
    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    // FK → documents_status
    public Guid DocumentStatusId { get; set; }
    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}