using DerTransporte.Modules.CompanyDocuments.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.CompanyDocuments.Infrastructure.Repository;

public class CompanyDocumentsRepository
{
    private readonly AppDbContext _context;

    public CompanyDocumentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CompanyDocumentsEntity>> GetAllAsync()
        => await _context.CompanyDocuments
            .Include(x => x.Company)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .ToListAsync();

    public async Task<CompanyDocumentsEntity?> GetByIdAsync(Guid id)
        => await _context.CompanyDocuments
            .Include(x => x.Company)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(CompanyDocumentsEntity entity)
    {
        await _context.CompanyDocuments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CompanyDocumentsEntity entity)
    {
        _context.CompanyDocuments.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.CompanyDocuments.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}