using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.EventOperations.Commands.DeleteEvent;

public class DeleteEventCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteEventCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var data = _context.Events.FirstOrDefault(x => x.Id == Id);
        if (data is null)
            throw new InvalidOperationException("Event is not found!");

        _context.Events.Remove(data);
        _context.SaveChanges();
    }
}