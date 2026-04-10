using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TransportCompanies.Infrastructure.Repository;

public class TransportCompaniesRepository
{
    private readonly AppDbContext _context;

    public TransportCompaniesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransportCompaniesEntity>> GetAllAsync()
        => await _context.TransportCompanies
        .Include(x => x.City)
        .Include(x => x.Status)
        .Include(x => x.LegalRepresentative)
        .ToListAsync();

    public async Task<TransportCompaniesEntity?> GetByIdAsync(Guid id)
        => await _context.TransportCompanies
        .Include(x => x.City)
        .Include(x => x.Status)
        .Include(x => x.LegalRepresentative)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(TransportCompaniesEntity entity)
    {
        await _context.TransportCompanies.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TransportCompaniesEntity entity)
    {
        _context.TransportCompanies.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.TransportCompanies.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }   
}
