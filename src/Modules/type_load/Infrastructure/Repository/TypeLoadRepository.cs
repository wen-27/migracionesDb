using DerTransporte.Modules.TypeLoad.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TypeLoad.Infrastructure.Repository;

public class TypeLoadRepository
{
    private readonly AppDbContext _context;

    public TypeLoadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TypeLoadEntity>> GetAllAsync()
        => await _context.TypeLoad.ToListAsync();

    public async Task<TypeLoadEntity?> GetByIdAsync(Guid id)
        => await _context.TypeLoad.FindAsync(id);

    public async Task AddAsync(TypeLoadEntity entity)
    {
        await _context.TypeLoad.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TypeLoadEntity entity)
    {
        _context.TypeLoad.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.TypeLoad.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
