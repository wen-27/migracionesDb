using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.TripStatusHistory.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TripStatusHistory.Infrastructure.Repository;

public class TripStatusHistoryRepository
{
    private readonly AppDbContext _context;

    public TripStatusHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TripStatusHistoryEntity>> GetAllAsync()
    {
        return await _context.TripStatusHistory
            .Include(x => x.Trip)
            .ToListAsync();
    }

    public async Task<TripStatusHistoryEntity?> GetByIdAsync(Guid id)
    {
        return await _context.TripStatusHistory
            .Include(x => x.Trip)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<TripStatusHistoryEntity> CreateAsync(TripStatusHistoryEntity entity)
    {
        await _context.TripStatusHistory.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TripStatusHistoryEntity?> UpdateAsync(Guid id, TripStatusHistoryEntity entity)
    {
        var current = await _context.TripStatusHistory.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.tripid = entity.tripid;
        current.statusname = entity.statusname;
        current.locationcoords = entity.locationcoords;
        current.notes = entity.notes;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.TripStatusHistory.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.TripStatusHistory.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}