using DerTransporte.Modules.Vehicles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Vehicles.Infrastructure.Repository;

public class VehiclesRepository
{
    private readonly AppDbContext _context;

    public VehiclesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<VehiclesEntity>> GetAllAsync()
        => await _context.Vehicles
            .Include(x => x.TypeVehicule)
            .Include(x => x.Owner)
            .Include(x => x.Status)
            .ToListAsync();

    public async Task<VehiclesEntity?> GetByIdAsync(Guid id)
        => await _context.Vehicles
            .Include(x => x.TypeVehicule)
            .Include(x => x.Owner)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(VehiclesEntity entity)
    {
        await _context.Vehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VehiclesEntity entity)
    {
        _context.Vehicles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Vehicles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}