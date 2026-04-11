using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Payments.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Payments.Infrastructure.Repository;

public class PaymentsRepository
{
    private readonly AppDbContext _context;

    public PaymentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentsEntity>> GetAllAsync()
    {
        return await _context.Payments
            .Include(x => x.Wallet)
            .Include(x => x.PaymentProvider)
            .Include(x => x.Status)
            .ToListAsync();
    }

    public async Task<PaymentsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Payments
            .Include(x => x.Wallet)
            .Include(x => x.PaymentProvider)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<PaymentsEntity> CreateAsync(PaymentsEntity entity)
    {
        await _context.Payments.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<PaymentsEntity?> UpdateAsync(Guid id, PaymentsEntity entity)
    {
        var current = await _context.Payments.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.walletid = entity.walletid;
        current.paymentproviderid = entity.paymentproviderid;
        current.statusid = entity.statusid;
        current.externalreference = entity.externalreference;
        current.amountmoney = entity.amountmoney;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Payments.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Payments.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}