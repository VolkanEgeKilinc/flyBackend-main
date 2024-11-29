using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.UpdateTicketCategory;

public class UpdateTicketCategoryCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdateTicketCategoryModel Model { get; set; } = null!;

    public UpdateTicketCategoryCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var ticketCategory = _context.TicketCategories.FirstOrDefault(x => x.Id == Id);
        if (ticketCategory is null)
            throw new InvalidOperationException("Ticket Category is not found!");

        var isConflict = _context.TicketCategories.Any(x => x.Title.ToLower() == Model.Title.ToLower() && x.EventId == ticketCategory.EventId && x.Id != Id);
        if (isConflict)
            throw new InvalidOperationException("Ticket Category with same name is already exist!");

        ticketCategory.Title = Model.Title != default ? Model.Title : ticketCategory.Title;
        ticketCategory.Quota = Model.Quota != default ? Model.Quota : ticketCategory.Quota;
        ticketCategory.Price = Model.Price != default ? Model.Price : ticketCategory.Price;

        _context.SaveChanges();
    }
}