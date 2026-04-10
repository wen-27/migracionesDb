using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Persons.Infrastructure.Repository;

public class PersonsRepository
{
    private readonly AppDbContext _context;

    public PersonsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonsEntity>> GetAllAsync()
         => await _context.Persons
            .Include(x => x.City)
            .Include(x => x.PersonStatus)
            .ToListAsync();

    public async Task<PersonsEntity?> GetByIdAsync(Guid id)
         => await _context.Persons
            .Include(x => x.City)
            .Include(x => x.PersonStatus)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(PersonsEntity entity)
    {
        await _context.Persons.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PersonsEntity entity)
    {
        _context.Persons.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
