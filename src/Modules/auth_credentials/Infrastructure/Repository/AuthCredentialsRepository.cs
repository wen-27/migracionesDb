using DerTransporte.Modules.AuthCredentials.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.AuthCredentials.Infrastructure.Repository;

public class AuthCredentialsRepository
{
    private readonly AppDbContext _context;

    public AuthCredentialsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AuthCredentialsEntity>> GetAllAsync()
        => await _context.AuthCredentials
            .Include(x => x.Person)
            .ToListAsync();

    public async Task<AuthCredentialsEntity?> GetByIdAsync(Guid id)
        => await _context.AuthCredentials
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<AuthCredentialsEntity?> GetByEmailAsync(string email)
        => await _context.AuthCredentials
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Email == email);

    public async Task AddAsync(AuthCredentialsEntity entity)
    {
        await _context.AuthCredentials.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AuthCredentialsEntity entity)
    {
        _context.AuthCredentials.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.AuthCredentials.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}