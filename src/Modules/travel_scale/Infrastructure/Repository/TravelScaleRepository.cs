using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.TravelScale.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TravelScale.Infrastructure.Repository;

public class TravelScaleRepository
{
    private readonly AppDbContext _context;

    public TravelScaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TravelScaleEntity>> GetAllAsync()
    {
        return await _context.TravelScale
            .Include(x => x.Trip)
            .Include(x => x.City)
            .ToListAsync();
    }

    public async Task<TravelScaleEntity?> GetByIdAsync(Guid id)
    {
        return await _context.TravelScale
            .Include(x => x.Trip)
            .Include(x => x.City)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<TravelScaleEntity> CreateAsync(TravelScaleEntity entity)
    {
        await _context.TravelScale.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TravelScaleEntity?> UpdateAsync(Guid id, TravelScaleEntity entity)
    {
        var current = await _context.TravelScale.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.tripid = entity.tripid;
        current.cityid = entity.cityid;
        current.sequence = entity.sequence;
        current.arrivalestimated = entity.arrivalestimated;
        current.arrivalactual = entity.arrivalactual;
        current.departureactual = entity.departureactual;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.TravelScale.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.TravelScale.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}