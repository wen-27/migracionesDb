namespace DerTransporte.Modules.MessageType.Infrastructure.Entity;

public class MessageTypeEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
