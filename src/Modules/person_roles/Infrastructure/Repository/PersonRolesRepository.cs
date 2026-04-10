using DerTransporte.Modules.PersonRoles.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Roles.Infrastructure.Entity;

namespace DerTransporte.Modules.PersonRoles.Infrastructure.Repository;

public class PersonRolesRepository
{
    private readonly AppDbContext _context;

    public PersonRolesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonRolesEntity>> GetAllAsync()
        => await _context.PersonRoles
            .Include(x => x.Role)
            .Include(x => x.Person)
            .ToListAsync();

    public async Task<PersonRolesEntity?> GetByIdAsync(Guid id)
        => await _context.PersonRoles
            .Include(x => x.Role)
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);        

    public async Task AddAsync(PersonRolesEntity entity)
    {
        await _context.PersonRoles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PersonRolesEntity entity)
    {
        _context.PersonRoles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.PersonRoles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
