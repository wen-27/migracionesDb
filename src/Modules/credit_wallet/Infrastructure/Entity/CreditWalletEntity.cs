using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;

namespace DerTransporte.Modules.CreditWallet.Infrastructure.Entity;

public class CreditWalletEntity
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastUpdate { get; set; }

    // FK nullable → persons
    public Guid? PersonId { get; set; }
    public PersonsEntity? Person { get; set; }

    // FK nullable → transport_companies
    public Guid? CompanyId { get; set; }
    public TransportCompaniesEntity? Company { get; set; }
}