using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventReminderOperations.Commands.CreateEventReminder;

public class CreateEventReminderCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public CreateEventReminderCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var data = _context.Events
            .Include(x => x.EventReminders)
            .FirstOrDefault(x => x.Id == Id);
        if (data is null)
            throw new InvalidOperationException("Event is not found!");

        if (data.EventReminders.Any(x => x.UserId == UserId))
            throw new InvalidOperationException("Event is already has reminder for current user!");

        data.EventReminders.Add(new EventReminder
        {
            UserId = UserId,
            Date = DateTime.Now
        });
        _context.SaveChanges();
    }
}