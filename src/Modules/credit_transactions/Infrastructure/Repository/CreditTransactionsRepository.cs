using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.CreditTransactions.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.CreditTransactions.Infrastructure.Repository;

public class CreditTransactionsRepository
{
    private readonly AppDbContext _context;

    public CreditTransactionsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CreditTransactionsEntity>> GetAllAsync()
    {
        return await _context.CreditTransactions
            .Include(x => x.Wallet)
            .Include(x => x.TransactionType)
            .ToListAsync();
    }

    public async Task<CreditTransactionsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.CreditTransactions
            .Include(x => x.Wallet)
            .Include(x => x.TransactionType)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<CreditTransactionsEntity> CreateAsync(CreditTransactionsEntity entity)
    {
        await _context.CreditTransactions.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<CreditTransactionsEntity?> UpdateAsync(Guid id, CreditTransactionsEntity entity)
    {
        var current = await _context.CreditTransactions.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.walletid = entity.walletid;
        current.transactiontypeid = entity.transactiontypeid;
        current.amount = entity.amount;
        current.balanceafter = entity.balanceafter;
        current.referenceid = entity.referenceid;
        current.description = entity.description;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.CreditTransactions.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.CreditTransactions.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}