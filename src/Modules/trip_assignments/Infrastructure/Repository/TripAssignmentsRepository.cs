using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.TripAssignments.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.TripAssignments.Infrastructure.Repository;

public class TripAssignmentsRepository
{
    private readonly AppDbContext _context;

    public TripAssignmentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TripAssignmentsEntity>> GetAllAsync()
    {
        return await _context.TripAssignments
            .Include(x => x.Trip)
            .Include(x => x.Person)
            .Include(x => x.AssignmentRole)
            .ToListAsync();
    }

    public async Task<TripAssignmentsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.TripAssignments
            .Include(x => x.Trip)
            .Include(x => x.Person)
            .Include(x => x.AssignmentRole)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<TripAssignmentsEntity> CreateAsync(TripAssignmentsEntity entity)
    {
        await _context.TripAssignments.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TripAssignmentsEntity?> UpdateAsync(Guid id, TripAssignmentsEntity entity)
    {
        var current = await _context.TripAssignments.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.tripid = entity.tripid;
        current.personid = entity.personid;
        current.assignmentroleid = entity.assignmentroleid;
        current.isactive = entity.isactive;
        current.assignedat = entity.assignedat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.TripAssignments.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.TripAssignments.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}