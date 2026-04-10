using DerTransporte.Modules.TypeDocuments.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TypeDocuments.Infrastructure.Repository;

public class TypeDocumentsRepository
{
    private readonly AppDbContext _context;

    public TypeDocumentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TypeDocumentsEntity>> GetAllAsync()
        => await _context.TypeDocuments.ToListAsync();

    public async Task<TypeDocumentsEntity?> GetByIdAsync(Guid id)
        => await _context.TypeDocuments.FindAsync(id);

    public async Task AddAsync(TypeDocumentsEntity entity)
    {
        await _context.TypeDocuments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TypeDocumentsEntity entity)
    {
        _context.TypeDocuments.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.TypeDocuments.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
