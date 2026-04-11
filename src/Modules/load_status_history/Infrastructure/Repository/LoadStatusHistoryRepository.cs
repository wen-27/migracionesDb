using DerTransporte.Modules.LoadStatusHistory.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.LoadStatusHistory.Infrastructure.Repository;

public class LoadStatusHistoryRepository
{
    private readonly AppDbContext _context;

    public LoadStatusHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LoadStatusHistoryEntity>> GetAllAsync()
        => await _context.LoadStatusHistories
            .Include(x => x.Load)
            .ToListAsync();

    public async Task<LoadStatusHistoryEntity?> GetByIdAsync(Guid id)
        => await _context.LoadStatusHistories
            .Include(x => x.Load)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(LoadStatusHistoryEntity entity)
    {
        await _context.LoadStatusHistories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LoadStatusHistoryEntity entity)
    {
        _context.LoadStatusHistories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.LoadStatusHistories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}