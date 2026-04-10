using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;
using DerTransporte.Modules.RelationType.Infrastructure.Entity;

namespace DerTransporte.Modules.PersonTransport.Infrastructure.Entity;

public class PersonTransportEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime JoinedAt { get; set; }

    // FK → persons
    public Guid PersonId { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    // FK → transport_companies
    public Guid CompanyId { get; set; }
    public TransportCompaniesEntity Company { get; set; } = null!;

    // FK → relation_type
    public Guid RelationTypeId { get; set; }
    public RelationTypeEntity RelationType { get; set; } = null!;
}