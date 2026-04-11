using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.ChatParticipants.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.ChatParticipants.Infrastructure.Repository;

public class ChatParticipantsRepository
{
    private readonly AppDbContext _context;

    public ChatParticipantsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatParticipantsEntity>> GetAllAsync()
    {
        return await _context.ChatParticipants
            .Include(x => x.ChatRoom)
            .Include(x => x.Person)
            .ToListAsync();
    }

    public async Task<ChatParticipantsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.ChatParticipants
            .Include(x => x.ChatRoom)
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<ChatParticipantsEntity> CreateAsync(ChatParticipantsEntity entity)
    {
        await _context.ChatParticipants.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ChatParticipantsEntity?> UpdateAsync(Guid id, ChatParticipantsEntity entity)
    {
        var current = await _context.ChatParticipants.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.chatroomid = entity.chatroomid;
        current.personid = entity.personid;
        current.joinedat = entity.joinedat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.ChatParticipants.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.ChatParticipants.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}