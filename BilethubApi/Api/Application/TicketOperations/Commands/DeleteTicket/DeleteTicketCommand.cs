using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.TicketOperations.Commands.DeleteTicket;

public class DeleteTicketCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteTicketCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var ticket = _context.Tickets.FirstOrDefault(x => x.Id == Id);
        if (ticket is null)
            throw new InvalidOperationException("Ticket is not found!");

        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
    }
}