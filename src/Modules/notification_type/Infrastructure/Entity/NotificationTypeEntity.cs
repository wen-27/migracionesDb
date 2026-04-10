namespace DerTransporte.Modules.NotificationType.Infrastructure.Entity;

public class NotificationTypeEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;    
    public string Description { get; set; } = string.Empty;
}
