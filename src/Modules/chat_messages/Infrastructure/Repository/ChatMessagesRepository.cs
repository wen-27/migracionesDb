using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.ChatMessages.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.ChatMessages.Infrastructure.Repository;

public class ChatMessagesRepository
{
    private readonly AppDbContext _context;

    public ChatMessagesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatMessagesEntity>> GetAllAsync()
    {
        return await _context.ChatMessages
            .Include(x => x.ChatRoom)
            .Include(x => x.Sender)
            .Include(x => x.MessageType)
            .ToListAsync();
    }

    public async Task<ChatMessagesEntity?> GetByIdAsync(Guid id)
    {
        return await _context.ChatMessages
            .Include(x => x.ChatRoom)
            .Include(x => x.Sender)
            .Include(x => x.MessageType)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<ChatMessagesEntity> CreateAsync(ChatMessagesEntity entity)
    {
        await _context.ChatMessages.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ChatMessagesEntity?> UpdateAsync(Guid id, ChatMessagesEntity entity)
    {
        var current = await _context.ChatMessages.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.chatroomid = entity.chatroomid;
        current.senderid = entity.senderid;
        current.messagetypeid = entity.messagetypeid;
        current.messagecontent = entity.messagecontent;
        current.isread = entity.isread;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.ChatMessages.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.ChatMessages.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}