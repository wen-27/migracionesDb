using DerTransporte.Modules.CompanyVehicles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.CompanyVehicles.Infrastructure.Repository;

public class CompanyVehiclesRepository
{
    private readonly AppDbContext _context;

    public CompanyVehiclesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CompanyVehiclesEntity>> GetAllAsync()
        => await _context.CompanyVehicles
            .Include(x => x.Company)
            .Include(x => x.Vehicle)
            .ToListAsync();

    public async Task<CompanyVehiclesEntity?> GetByIdAsync(Guid id)
        => await _context.CompanyVehicles
            .Include(x => x.Company)
            .Include(x => x.Vehicle)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(CompanyVehiclesEntity entity)
    {
        await _context.CompanyVehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CompanyVehiclesEntity entity)
    {
        _context.CompanyVehicles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.CompanyVehicles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}