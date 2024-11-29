using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.CreateTicketCategory;

public class CreateTicketCategoryCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateTicketCategoryModel Model { get; set; } = null!;

    public CreateTicketCategoryCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var ticketCategory = _context.TicketCategories.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower() &&  x.EventId == Model.EventId);
        if (ticketCategory is not null)
            throw new InvalidOperationException("Ticket Category with same name is already exist!");

        ticketCategory = _mapper.Map<TicketCategory>(Model);

        _context.TicketCategories.Add(ticketCategory);
        _context.SaveChanges();
    }

}