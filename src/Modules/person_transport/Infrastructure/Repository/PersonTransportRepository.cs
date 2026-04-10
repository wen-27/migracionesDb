using DerTransporte.Modules.PersonTransport.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.PersonTransport.Infrastructure.Repository;

public class PersonTransportRepository
{
    private readonly AppDbContext _context;

    public PersonTransportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonTransportEntity>> GetAllAsync()
        => await _context.PersonTransport
            .Include(x => x.Person)
            .Include(x => x.Company)
            .Include(x => x.RelationType)
            .ToListAsync();

    public async Task<PersonTransportEntity?> GetByIdAsync(Guid id)
        => await _context.PersonTransport
            .Include(x => x.Person)
            .Include(x => x.Company)
            .Include(x => x.RelationType)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(PersonTransportEntity entity)
    {
        await _context.PersonTransport.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PersonTransportEntity entity)
    {
        _context.PersonTransport.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.PersonTransport.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}