using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Disputes.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Disputes.Infrastructure.Repository;

public class DisputesRepository
{
    private readonly AppDbContext _context;

    public DisputesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DisputesEntity>> GetAllAsync()
    {
        return await _context.Disputes
            .Include(x => x.Trip)
            .Include(x => x.CreatedBy)
            .Include(x => x.ReasonCategory)
            .Include(x => x.Status)
            .ToListAsync();
    }

    public async Task<DisputesEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Disputes
            .Include(x => x.Trip)
            .Include(x => x.CreatedBy)
            .Include(x => x.ReasonCategory)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<DisputesEntity> CreateAsync(DisputesEntity entity)
    {
        await _context.Disputes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<DisputesEntity?> UpdateAsync(Guid id, DisputesEntity entity)
    {
        var current = await _context.Disputes.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.tripid = entity.tripid;
        current.createdby = entity.createdby;
        current.reasoncategoryid = entity.reasoncategoryid;
        current.description = entity.description;
        current.evidenceurl = entity.evidenceurl;
        current.statusid = entity.statusid;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Disputes.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Disputes.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}