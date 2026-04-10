using DerTransporte.Modules.DocumentsDrivers.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.DocumentsDrivers.Infrastructure.Repository;

public class DocumentsDriversRepository
{
    private readonly AppDbContext _context;

    public DocumentsDriversRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentsDriversEntity>> GetAllAsync()
        => await _context.DocumentsDrivers
            .Include(x => x.Driver)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .ToListAsync();

    public async Task<DocumentsDriversEntity?> GetByIdAsync(Guid id)
        => await _context.DocumentsDrivers
            .Include(x => x.Driver)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(DocumentsDriversEntity entity)
    {
        await _context.DocumentsDrivers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentsDriversEntity entity)
    {
        _context.DocumentsDrivers.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DocumentsDrivers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}