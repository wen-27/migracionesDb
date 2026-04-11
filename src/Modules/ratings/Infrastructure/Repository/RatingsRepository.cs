using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Ratings.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Ratings.Infrastructure.Repository;

public class RatingsRepository
{
    private readonly AppDbContext _context;

    public RatingsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RatingsEntity>> GetAllAsync()
    {
        return await _context.Ratings
            .Include(x => x.Trip)
            .Include(x => x.Evaluator)
            .Include(x => x.Evaluated)
            .ToListAsync();
    }

    public async Task<RatingsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Ratings
            .Include(x => x.Trip)
            .Include(x => x.Evaluator)
            .Include(x => x.Evaluated)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<RatingsEntity> CreateAsync(RatingsEntity entity)
    {
        await _context.Ratings.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<RatingsEntity?> UpdateAsync(Guid id, RatingsEntity entity)
    {
        var current = await _context.Ratings.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.tripid = entity.tripid;
        current.evaluatorid = entity.evaluatorid;
        current.evaluatedid = entity.evaluatedid;
        current.score = entity.score;
        current.comment = entity.comment;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Ratings.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Ratings.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}