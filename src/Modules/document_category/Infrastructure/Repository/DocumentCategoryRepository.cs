using DerTransporte.Modules.DocumentCategory.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.DocumentCategory.Infrastructure.Repository;

public class DocumentCategoryRepository
{
    private readonly AppDbContext _context;
    
    public DocumentCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentCategoryEntity>> GetAllAsync()
        => await _context.DocumentCategory.ToListAsync();

    public async Task<DocumentCategoryEntity?> GetByIdAsync(Guid id)
        => await _context.DocumentCategory.FindAsync(id);

    public async Task AddAsync(DocumentCategoryEntity entity)
    {
        await _context.DocumentCategory.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentCategoryEntity entity)
    {
        _context.DocumentCategory.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DocumentCategory.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
