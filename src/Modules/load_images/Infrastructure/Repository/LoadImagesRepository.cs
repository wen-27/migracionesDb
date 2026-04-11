using DerTransporte.Modules.LoadImages.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.LoadImages.Infrastructure.Repository;

public class LoadImagesRepository
{
    private readonly AppDbContext _context;

    public LoadImagesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LoadImagesEntity>> GetAllAsync()
        => await _context.LoadImages
            .Include(x => x.Load)
            .ToListAsync();

    public async Task<LoadImagesEntity?> GetByIdAsync(Guid id)
        => await _context.LoadImages
            .Include(x => x.Load)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(LoadImagesEntity entity)
    {
        await _context.LoadImages.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LoadImagesEntity entity)
    {
        _context.LoadImages.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.LoadImages.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}