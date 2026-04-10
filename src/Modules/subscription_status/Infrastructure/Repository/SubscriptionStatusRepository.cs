using DerTransporte.Modules.SubscriptionStatus.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.SubscriptionStatus.Infrastructure.Repository;

public class SubscriptionStatusRepository
{
    private readonly AppDbContext _context;

    public SubscriptionStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubscriptionStatusEntity>> GetAllAsync()
        => await _context.SubscriptionStatus.ToListAsync();

    public async Task<SubscriptionStatusEntity?> GetByIdAsync(Guid id)
        => await _context.SubscriptionStatus.FindAsync(id);

    public async Task AddAsync(SubscriptionStatusEntity entity)
    {
        await _context.SubscriptionStatus.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SubscriptionStatusEntity entity)
    {
        _context.SubscriptionStatus.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.SubscriptionStatus.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
