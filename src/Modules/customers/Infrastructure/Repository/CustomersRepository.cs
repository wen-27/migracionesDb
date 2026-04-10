using DerTransporte.Modules.Customers.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Customers.Infrastructure.Repository;

public class CustomersRepository
{
    private readonly AppDbContext _context;

    public CustomersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomersEntity>> GetAllAsync()
        => await _context.Customers
            .Include(x => x.Person)
            .ToListAsync();

    public async Task<CustomersEntity?> GetByIdAsync(Guid id)
        => await _context.Customers
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(CustomersEntity entity)
    {
        await _context.Customers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomersEntity entity)
    {
        _context.Customers.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
