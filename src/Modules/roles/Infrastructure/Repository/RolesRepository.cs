using DerTransporte.Modules.Roles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Roles.Infrastructure.Repository;

public class RolesRepository
{
    private readonly AppDbContext _context;

    public RolesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RolesEntity>> GetAllAsync()
        => await _context.Roles.ToListAsync();

    public async Task<RolesEntity?> GetByIdAsync(Guid id)
        => await _context.Roles.FindAsync(id);

    public async Task AddAsync(RolesEntity entity)
    {
        await _context.Roles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RolesEntity entity)
    {
        _context.Roles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
