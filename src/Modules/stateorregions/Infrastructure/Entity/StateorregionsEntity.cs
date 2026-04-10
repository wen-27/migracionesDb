using DerTransporte.Modules.Countries.Infrastructure.Entity;
namespace DerTransporte.Modules.Stateorregions.Infrastructure.Entity;

public class StateorregionsEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    public string Code { get; set; } = string.Empty;

    public CountriesEntity? Country { get; set; }
}
