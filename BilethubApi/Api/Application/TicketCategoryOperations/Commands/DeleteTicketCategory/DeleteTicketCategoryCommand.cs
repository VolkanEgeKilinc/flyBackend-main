using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.DeleteTicketCategory;

public class DeleteTicketCategoryCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteTicketCategoryCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var ticketCategory = _context.TicketCategories.FirstOrDefault(x => x.Id == Id);
        if (ticketCategory is null)
            throw new InvalidOperationException("Ticket Category is not found!");

        _context.TicketCategories.Remove(ticketCategory);
        _context.SaveChanges();
    }
}