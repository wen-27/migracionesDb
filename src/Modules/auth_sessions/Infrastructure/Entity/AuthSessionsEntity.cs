using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.AuthSessions.Infrastructure.Entity;

public class AuthSessionsEntity
{
    public Guid Id { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public string IpAddress { get; set; } = string.Empty;
    public string DeviceInfo { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // FK → persons
    public Guid PersonId { get; set; }
    public PersonsEntity Person { get; set; } = null!;
}
