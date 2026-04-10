using DerTransporte.Modules.VehiculesStatus.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.VehiculesStatus.Infrastructure.Repository;

public class VehiculesStatusRepository
{
    private readonly AppDbContext _context;

    public VehiculesStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<VehiculesStatusEntity>> GetAllAsync()
        => await _context.VehiculesStatus.ToListAsync();

    public async Task<VehiculesStatusEntity?> GetByIdAsync(Guid id)
        => await _context.VehiculesStatus.FindAsync(id);

    public async Task AddAsync(VehiculesStatusEntity entity)
    {
        await _context.VehiculesStatus.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VehiculesStatusEntity entity)
    {
        _context.VehiculesStatus.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.VehiculesStatus.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
