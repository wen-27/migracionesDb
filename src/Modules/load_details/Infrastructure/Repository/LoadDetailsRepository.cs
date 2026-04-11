using DerTransporte.Modules.LoadDetails.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.LoadDetails.Infrastructure.Repository;

public class LoadDetailsRepository
{
    private readonly AppDbContext _context;

    public LoadDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LoadDetailsEntity>> GetAllAsync()
        => await _context.LoadDetails
            .Include(x => x.Load)
            .ToListAsync();

    public async Task<LoadDetailsEntity?> GetByIdAsync(Guid id)
        => await _context.LoadDetails
            .Include(x => x.Load)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(LoadDetailsEntity entity)
    {
        await _context.LoadDetails.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LoadDetailsEntity entity)
    {
        _context.LoadDetails.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.LoadDetails.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}