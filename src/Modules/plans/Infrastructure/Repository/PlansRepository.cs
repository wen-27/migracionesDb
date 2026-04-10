using DerTransporte.Modules.Plans.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Plans.Infrastructure.Repository;

public class PlansRepository
{
    private readonly AppDbContext _context;

    public PlansRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PlansEntity>> GetAllAsync()
        => await _context.Plans.ToListAsync();

    public async Task<PlansEntity?> GetByIdAsync(Guid id)
        => await _context.Plans.FindAsync(id);

    public async Task AddAsync(PlansEntity entity)
    {
        await _context.Plans.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PlansEntity entity)
    {
        _context.Plans.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Plans.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
