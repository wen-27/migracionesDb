using DerTransporte.Modules.DocumentsCustomers.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.DocumentsCustomers.Infrastructure.Repository;

public class DocumentsCustomersRepository
{
    private readonly AppDbContext _context;

    public DocumentsCustomersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentsCustomersEntity>> GetAllAsync()
        => await _context.DocumentsCustomers
            .Include(x => x.Customer)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .ToListAsync();

    public async Task<DocumentsCustomersEntity?> GetByIdAsync(Guid id)
        => await _context.DocumentsCustomers
            .Include(x => x.Customer)
            .Include(x => x.TypeDocument)
            .Include(x => x.DocumentStatus)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(DocumentsCustomersEntity entity)
    {
        await _context.DocumentsCustomers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentsCustomersEntity entity)
    {
        _context.DocumentsCustomers.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DocumentsCustomers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}