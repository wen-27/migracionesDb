using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Modules.CompaniesStatus.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;

public class TransportCompaniesEntity
{
    public Guid Id { get; set; }
    public string Nit { get; set; } = string.Empty;
    public string CompanieName { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string ContactPhone { get; set; } = string.Empty;
    public string Addres { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public DateTime? VerifiedAt { get; set; }


    // FK → cities (ciudad)
    public Guid CityId { get; set; }
    public CitiesormunicipalitiesEntity City { get; set; } = null!;

    // FK → status (company status)
    public Guid StatusId { get; set; }
    public CompaniesStatusEntity Status { get; set; } = null!;

    // FK → persons (representante legal)
    public Guid LegalRepresentativeId { get; set; }
    public PersonsEntity LegalRepresentative { get; set; } = null!;

}
