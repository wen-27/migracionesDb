using DerTransporte.Modules.AuthSessions.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.AuthSessions.Infrastructure.Repository;

public class AuthSessionsRepository
{
    private readonly AppDbContext _context;

    public AuthSessionsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AuthSessionsEntity>> GetAllAsync()
        => await _context.AuthSessions
            .Include(x => x.Person)
            .ToListAsync();

    public async Task<AuthSessionsEntity?> GetByIdAsync(Guid id)
        => await _context.AuthSessions
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<AuthSessionsEntity?> GetByRefreshTokenAsync(string token)
        => await _context.AuthSessions
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.RefreshToken == token);

    public async Task AddAsync(AuthSessionsEntity entity)
    {
        await _context.AuthSessions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AuthSessionsEntity entity)
    {
        _context.AuthSessions.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.AuthSessions.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}