using DerTransporte.Modules.MessageType.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.MessageType.Infrastructure.Repository;

public class MessageTypeRepository
{
    private readonly AppDbContext _context;

    public MessageTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MessageTypeEntity>> GetAllAsync()
        => await _context.MessageType.ToListAsync();

    public async Task<MessageTypeEntity?> GetByIdAsync(Guid id)
        => await _context.MessageType.FindAsync(id);

    public async Task AddAsync(MessageTypeEntity entity)
    {
        await _context.MessageType.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MessageTypeEntity entity)
    {
        _context.MessageType.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.MessageType.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
