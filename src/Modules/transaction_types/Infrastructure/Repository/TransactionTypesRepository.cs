using DerTransporte.Modules.TransactionTypes.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TransactionTypes.Infrastructure.Repository;

public class TransactionTypesRepository
{
    private readonly AppDbContext _context;

    public TransactionTypesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionTypesEntity>> GetAllAsync()
        => await _context.TransactionTypes.ToListAsync();

    public async Task<TransactionTypesEntity?> GetByIdAsync(Guid id)
        => await _context.TransactionTypes.FindAsync(id);

    public async Task AddAsync(TransactionTypesEntity entity)
    {
        await _context.TransactionTypes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TransactionTypesEntity entity)
    {
        _context.TransactionTypes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.TransactionTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
