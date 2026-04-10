using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Modules.PersonStatus.Infrastructure.Entity;

namespace DerTransporte.Modules.Persons.Infrastructure.Entity;

public class PersonsEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // FK

    public Guid CityId { get; set; }
    public CitiesormunicipalitiesEntity City { get; set; } = null!;

    // FK → person_status
    public Guid PersonStatusId { get; set; }
    public PersonStatusEntity PersonStatus { get; set; } = null!;
}
