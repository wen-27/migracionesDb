using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.Drivers.Infrastructure.Entity;

public class DriversEntity
{
    public Guid Id { get; set; }
    public string LicenseCategory { get; set; } = string.Empty;
    public int ExperienceYears { get; set; }
    public bool IsAvailable { get; set; }

    // FK nullable → persons
    public Guid? PersonId { get; set; }
    public PersonsEntity? Person { get; set; }

}
