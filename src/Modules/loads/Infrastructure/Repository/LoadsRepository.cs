using DerTransporte.Modules.Loads.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Loads.Infrastructure.Repository;

public class LoadsRepository
{
    private readonly AppDbContext _context;

    public LoadsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LoadsEntity>> GetAllAsync()
        => await _context.Loads
            .Include(x => x.Customer)
            .Include(x => x.TypeLoad)
            .Include(x => x.OriginCity)
            .Include(x => x.DestinationCity)
            .ToListAsync();

    public async Task<LoadsEntity?> GetByIdAsync(Guid id)
        => await _context.Loads
            .Include(x => x.Customer)
            .Include(x => x.TypeLoad)
            .Include(x => x.OriginCity)
            .Include(x => x.DestinationCity)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(LoadsEntity entity)
    {
        await _context.Loads.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LoadsEntity entity)
    {
        _context.Loads.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Loads.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}