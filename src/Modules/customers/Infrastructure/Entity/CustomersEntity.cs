using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.Customers.Infrastructure.Entity;

public class CustomersEntity
{
    public Guid Id { get; set; }
    public bool IsFrecuent { get; set; }

    // FK nullable → persons
    public Guid? PersonId { get; set; }
    public PersonsEntity? Person { get; set; }
}
