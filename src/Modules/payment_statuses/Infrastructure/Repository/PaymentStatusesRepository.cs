using DerTransporte.Modules.PaymentStatuses.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.PaymentStatuses.Infrastructure.Repository;

public class PaymentStatusesRepository
{
    private readonly AppDbContext _context;

    public PaymentStatusesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentStatusesEntity>> GetAllAsync()
        => await _context.PaymentStatuses.ToListAsync();

    public async Task<PaymentStatusesEntity?> GetByIdAsync(Guid id)
        => await _context.PaymentStatuses.FindAsync(id);

    public async Task AddAsync(PaymentStatusesEntity entity)
    {
        await _context.PaymentStatuses.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PaymentStatusesEntity entity)
    {
        _context.PaymentStatuses.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.PaymentStatuses.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
