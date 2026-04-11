using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.ChatRooms.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.ChatRooms.Infrastructure.Repository;

public class ChatRoomsRepository
{
    private readonly AppDbContext _context;

    public ChatRoomsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatRoomsEntity>> GetAllAsync()
    {
        return await _context.ChatRooms
            .Include(x => x.Load)
            .Include(x => x.Trip)
            .Include(x => x.Status)
            .ToListAsync();
    }

    public async Task<ChatRoomsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.ChatRooms
            .Include(x => x.Load)
            .Include(x => x.Trip)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<ChatRoomsEntity> CreateAsync(ChatRoomsEntity entity)
    {
        await _context.ChatRooms.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ChatRoomsEntity?> UpdateAsync(Guid id, ChatRoomsEntity entity)
    {
        var current = await _context.ChatRooms.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.loadid = entity.loadid;
        current.tripid = entity.tripid;
        current.statusid = entity.statusid;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.ChatRooms.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.ChatRooms.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}