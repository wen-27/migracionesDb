namespace DerTransporte.Modules.Countries.Infrastructure.Entity;

public sealed class CountriesEntity
{
    public Guid Id { get; set; } 
    public string Isocode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneCode { get; set; } = string.Empty;
}
