using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;
using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.CompanyDocuments.Infrastructure.Entity;

public class CompanyDocumentsEntity
{
    public Guid Id { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public DateOnly ExpirationDate { get; set; }  // DATE → DateOnly en C#

    // FK → transport_companies
    public Guid CompanyId { get; set; }
    public TransportCompaniesEntity Company { get; set; } = null!;

    // FK → type_documents
    public Guid TypeDocumentId { get; set; }
    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    // FK → documents_status
    public Guid DocumentStatusId { get; set; }
    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}