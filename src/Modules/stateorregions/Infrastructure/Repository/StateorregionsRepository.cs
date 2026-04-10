using DerTransporte.Modules.Stateorregions.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Stateorregions.Infrastructure.Repository;

public class StateorregionsRepository
{
    private readonly AppDbContext _context;

    public StateorregionsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StateorregionsEntity>> GetAllAsync()
        => await _context.Stateorregions.ToListAsync();

    public async Task<StateorregionsEntity?> GetByIdAsync(Guid id)
        => await _context.Stateorregions.FindAsync(id);

    public async Task AddAsync(StateorregionsEntity entity)
    {
        await _context.Stateorregions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StateorregionsEntity entity)
    {
        _context.Stateorregions.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Stateorregions.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
