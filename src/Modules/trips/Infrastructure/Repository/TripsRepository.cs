using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Trips.Infrastructure.Repository;

public class TripsRepository
{
    private readonly AppDbContext _context;

    public TripsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TripsEntity>> GetAllAsync()
    {
        return await _context.Trips
            .Include(x => x.Load)
            .Include(x => x.Bid)
            .ToListAsync();
    }

    public async Task<TripsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Trips
            .Include(x => x.Load)
            .Include(x => x.Bid)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<TripsEntity> CreateAsync(TripsEntity entity)
    {
        await _context.Trips.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TripsEntity?> UpdateAsync(Guid id, TripsEntity entity)
    {
        var current = await _context.Trips.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.loadid = entity.loadid;
        current.bidid = entity.bidid;
        current.finalprice = entity.finalprice;
        current.manifestnumber = entity.manifestnumber;
        current.trackingtoken = entity.trackingtoken;
        current.starttime = entity.starttime;
        current.endtime = entity.endtime;
        current.driverid = entity.driverid;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Trips.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Trips.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}