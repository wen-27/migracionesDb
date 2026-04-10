namespace DerTransporte.Modules.Plans.Infrastructure.Entity;

public class PlansEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal CreditAmount { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
