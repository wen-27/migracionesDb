using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Subscriptions.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Subscriptions.Infrastructure.Repository;

public class SubscriptionsRepository
{
    private readonly AppDbContext _context;

    public SubscriptionsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubscriptionsEntity>> GetAllAsync()
    {
        return await _context.Subscriptions
            .Include(x => x.Person)
            .Include(x => x.SubscriptionType)
            .Include(x => x.Status)
            .Include(x => x.Payment)
            .ToListAsync();
    }

    public async Task<SubscriptionsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Subscriptions
            .Include(x => x.Person)
            .Include(x => x.SubscriptionType)
            .Include(x => x.Status)
            .Include(x => x.Payment)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<SubscriptionsEntity> CreateAsync(SubscriptionsEntity entity)
    {
        await _context.Subscriptions.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<SubscriptionsEntity?> UpdateAsync(Guid id, SubscriptionsEntity entity)
    {
        var current = await _context.Subscriptions.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.personid = entity.personid;
        current.subscriptiontypeid = entity.subscriptiontypeid;
        current.startdate = entity.startdate;
        current.enddate = entity.enddate;
        current.statusid = entity.statusid;
        current.autorenew = entity.autorenew;
        current.paymentid = entity.paymentid;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Subscriptions.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Subscriptions.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}