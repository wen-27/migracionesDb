using DerTransporte.Modules.Countries.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Countries.Infrastructure.Repository;

public class CountriesRepository
{
    private readonly AppDbContext _context;

    public CountriesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CountriesEntity>> GetAllAsync()
        => await _context.Countries.ToListAsync();

    public async Task<CountriesEntity?> GetByIdAsync(Guid id)
        => await _context.Countries.FindAsync(id);

    public async Task AddAsync(CountriesEntity entity)
    {
        await _context.Countries.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CountriesEntity entity)
    {
        _context.Countries.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Countries.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}