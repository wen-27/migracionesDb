using DerTransporte.Modules.TypeVehicles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TypeVehicles.Infrastructure.Repository;

public class TypeVehiclesRepository
{
    private readonly AppDbContext _context;

    public TypeVehiclesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TypeVehiclesEntity>> GetAllAsync()
        => await _context.TypeVehicles.ToListAsync();

    public async Task<TypeVehiclesEntity?> GetByIdAsync(Guid id)
        => await _context.TypeVehicles.FindAsync(id);

    public async Task AddAsync(TypeVehiclesEntity entity)
    {
        await _context.TypeVehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TypeVehiclesEntity entity)
    {
        _context.TypeVehicles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.TypeVehicles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
