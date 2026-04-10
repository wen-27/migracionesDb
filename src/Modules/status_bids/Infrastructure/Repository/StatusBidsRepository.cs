using DerTransporte.Modules.StatusBids.Infrastructure.Entity;
using DerTransporte.Shared.Context; 
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.StatusBids.Infrastructure.Repository;

public class StatusBidsRepository
{
    private readonly AppDbContext _context;

    public StatusBidsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StatusBidsEntity>> GetAllAsync()
        => await _context.StatusBids.ToListAsync();

    public async Task<StatusBidsEntity?> GetByIdAsync(Guid id)
        => await _context.StatusBids.FindAsync(id);

    public async Task AddAsync(StatusBidsEntity entity)
    {
        await _context.StatusBids.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StatusBidsEntity entity)
    {
        _context.StatusBids.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.StatusBids.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
