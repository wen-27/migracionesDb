using DerTransporte.Modules.Persons.Infrastructure.Entity;
namespace DerTransporte.Modules.AuthCredentials.Infrastructure.Entity;

public class AuthCredentialsEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }       
    public int FailedAttempts { get; set; }
    public DateTime? LockUntil { get; set; }        
    public bool IsActive { get; set; }

    // FK → persons
    public Guid PersonId { get; set; }
    public PersonsEntity Person { get; set; } = null!;
}
