using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DerTransporte.Modules.Notifications.Infrastructure.Entity;
using DerTransporte.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Modules.Notifications.Infrastructure.Repository;

public class NotificationsRepository
{
    private readonly AppDbContext _context;

    public NotificationsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<NotificationsEntity>> GetAllAsync()
    {
        return await _context.Notifications
            .Include(x => x.Person)
            .Include(x => x.NotificationType)
            .ToListAsync();
    }

    public async Task<NotificationsEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Notifications
            .Include(x => x.Person)
            .Include(x => x.NotificationType)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<NotificationsEntity> CreateAsync(NotificationsEntity entity)
    {
        await _context.Notifications.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<NotificationsEntity?> UpdateAsync(Guid id, NotificationsEntity entity)
    {
        var current = await _context.Notifications.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return null;

        current.personid = entity.personid;
        current.title = entity.title;
        current.body = entity.body;
        current.notificationtypeid = entity.notificationtypeid;
        current.linkurl = entity.linkurl;
        current.isread = entity.isread;
        current.createdat = entity.createdat;

        await _context.SaveChangesAsync();
        return current;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var current = await _context.Notifications.FirstOrDefaultAsync(x => x.id == id);

        if (current == null)
            return false;

        _context.Notifications.Remove(current);
        await _context.SaveChangesAsync();
        return true;
    }
}