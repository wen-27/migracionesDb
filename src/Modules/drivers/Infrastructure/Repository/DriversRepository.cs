using DerTransporte.Modules.Drivers.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Drivers.Infrastructure.Repository;

public class DriversRepository
{
    private readonly AppDbContext _context;

    public DriversRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DriversEntity>> GetAllAsync()
        => await _context.Drivers
            .Include(x => x.Person)
            .ToListAsync();

    public async Task<DriversEntity?> GetByIdAsync(Guid id)
        => await _context.Drivers
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(DriversEntity entity)
    {
        await _context.Drivers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DriversEntity entity)
    {
        _context.Drivers.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Drivers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}