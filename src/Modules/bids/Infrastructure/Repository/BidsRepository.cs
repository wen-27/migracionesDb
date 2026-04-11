using DerTransporte.Modules.Bids.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Bids.Infrastructure.Repository;

public class BidsRepository
{
    private readonly AppDbContext _context;

    public BidsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BidsEntity>> GetAllAsync()
        => await _context.Bids
            .Include(x => x.Load)
            .ToListAsync();

    public async Task<BidsEntity?> GetByIdAsync(Guid id)
        => await _context.Bids
            .Include(x => x.Load)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(BidsEntity entity)
    {
        await _context.Bids.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BidsEntity entity)
    {
        _context.Bids.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Bids.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}