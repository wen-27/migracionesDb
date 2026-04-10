using DerTransporte.Modules.CreditWallet.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.CreditWallet.Infrastructure.Repository;

public class CreditWalletRepository
{
    private readonly AppDbContext _context;

    public CreditWalletRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CreditWalletEntity>> GetAllAsync()
        => await _context.CreditWallet
            .Include(x => x.Person)
            .Include(x => x.Company)
            .ToListAsync();

    public async Task<CreditWalletEntity?> GetByIdAsync(Guid id)
        => await _context.CreditWallet
            .Include(x => x.Person)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(CreditWalletEntity entity)
    {
        await _context.CreditWallet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditWalletEntity entity)
    {
        _context.CreditWallet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.CreditWallet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}