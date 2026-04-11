using System;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.NotificationType.Infrastructure.Entity;

namespace DerTransporte.Modules.Notifications.Infrastructure.Entity;

public class NotificationsEntity
{
    public Guid id { get; set; }

    public Guid personid { get; set; }
    public PersonsEntity Person { get; set; } = null!;

    public string title { get; set; } = string.Empty;
    public string body { get; set; } = string.Empty;

    public Guid notificationtypeid { get; set; }
    public NotificationTypeEntity NotificationType { get; set; } = null!;

    public string? linkurl { get; set; }
    public bool isread { get; set; }
    public DateTime createdat { get; set; }
}