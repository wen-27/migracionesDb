using DerTransporte.Modules.DocumentsVehicles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.DocumentsVehicles.Infrastructure.Repository;

public class DocumentsVehiclesRepository
{
    private readonly AppDbContext _context;

    public DocumentsVehiclesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentsVehiclesEntity>> GetAllAsync()
        => await _context.DocumentsVehicles
            .Include(x => x.Vehicle)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .ToListAsync();

    public async Task<DocumentsVehiclesEntity?> GetByIdAsync(Guid id)
        => await _context.DocumentsVehicles
            .Include(x => x.Vehicle)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(DocumentsVehiclesEntity entity)
    {
        await _context.DocumentsVehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentsVehiclesEntity entity)
    {
        _context.DocumentsVehicles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DocumentsVehicles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}