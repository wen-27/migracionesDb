using DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Citiesormunicipalities.Infrastructure.Repository;

public class CitiesormunicipalitiesRepository
{
    private readonly AppDbContext _context;

    public CitiesormunicipalitiesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CitiesormunicipalitiesEntity>> GetAllAsync()
        => await _context.Citiesormunicipalities.ToListAsync();

    public async Task<CitiesormunicipalitiesEntity?> GetByIdAsync(Guid id)
        => await _context.Citiesormunicipalities.FindAsync(id);

    public async Task AddAsync(CitiesormunicipalitiesEntity entity)
    {
        await _context.Citiesormunicipalities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CitiesormunicipalitiesEntity entity)
    {
        _context.Citiesormunicipalities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Citiesormunicipalities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
