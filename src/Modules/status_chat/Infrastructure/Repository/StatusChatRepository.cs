using DerTransporte.Modules.StatusChat.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.StatusChat.Infrastructure.Repository;

public class StatusChatRepository
{
    private readonly AppDbContext _context;

    public StatusChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StatusChatEntity>> GetAllAsync()
        => await _context.StatusChat.ToListAsync();

    public async Task<StatusChatEntity?> GetByIdAsync(Guid id)
        => await _context.StatusChat.FindAsync(id);

    public async Task AddAsync(StatusChatEntity entity)
    {
        await _context.StatusChat.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StatusChatEntity entity)
    {
        _context.StatusChat.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.StatusChat.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
