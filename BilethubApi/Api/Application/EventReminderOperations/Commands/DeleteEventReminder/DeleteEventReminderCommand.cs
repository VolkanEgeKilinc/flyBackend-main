using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventReminderOperations.Commands.DeleteEventReminder;

public class DeleteEventReminderCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public DeleteEventReminderCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var place = _context.Events
            .Include(x => x.EventReminders)
            .FirstOrDefault(x => x.Id == Id);
        if (place is null)
            throw new InvalidOperationException("Event is not found!");

        var reminder = place.EventReminders.FirstOrDefault(x => x.UserId == UserId);
        if (reminder is null)
            throw new InvalidOperationException("Event is already has not reminder for current user!");

        place.EventReminders.Remove(reminder);
        _context.SaveChanges();
    }
}