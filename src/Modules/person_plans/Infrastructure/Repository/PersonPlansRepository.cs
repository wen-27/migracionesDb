using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.PersonPlans.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.PersonPlans.Infrastructure.Repository;

public class PersonPlansRepository
{
    private readonly AppDbContext _context;

    public PersonPlansRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonPlansEntity>> GetAllAsync()
    {
        return await _context.PersonPlans
            .Include(x => x.Person)
            .Include(x => x.Plan)
            .Include(x => x.Payment)
            .ToListAsync();
    }

    public async Task<PersonPlansEntity?> GetByIdAsync(Guid id)
    {
        return await _context.PersonPlans
            .Include(x => x.Person)
            .Include(x => x.Plan)
            .Include(x => x.Payment)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<PersonPlansEntity> CreateAsync(PersonPlansEntity entity)
    {
        await _context.PersonPlans.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<PersonPlansEntity?> UpdateAsync(Guid id, PersonPlansEntity entity)
    {
        var current = await _context.PersonPlans.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.personid = entity.personid;
        current.planid = entity.planid;
        current.paymentid = entity.paymentid;
        current.creditsgranted = entity.creditsgranted;
        current.unitpriceatpurchase = entity.unitpriceatpurchase;
        current.purchasedat = entity.purchasedat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.PersonPlans.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.PersonPlans.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}