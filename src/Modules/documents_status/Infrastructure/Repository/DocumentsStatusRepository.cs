using DerTransporte.Modules.DocumentsStatus.Infrastructure.Entity;  
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.DocumentsStatus.Infrastructure.Repository;

public class DocumentsStatusRepository
{
    private readonly AppDbContext _context;

    public DocumentsStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentsStatusEntity>> GetAllAsync()
        => await _context.DocumentsStatus.ToListAsync();

    public async Task<DocumentsStatusEntity?> GetByIdAsync(Guid id)
        => await _context.DocumentsStatus.FindAsync(id);

    public async Task AddAsync(DocumentsStatusEntity entity)
    {
        await _context.DocumentsStatus.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentsStatusEntity entity)
    {
        _context.DocumentsStatus.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DocumentsStatus.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
