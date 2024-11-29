using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateTicket;

public class CreateTicketCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateTicketModel Model { get; set; } = null!;

    public CreateTicketCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var ticketCategory = _context.TicketCategories.FirstOrDefault(x => x.Id == Model.TicketCategoryId);
        if (ticketCategory is null)
            throw new InvalidOperationException("Ticket Category is not found!");

        var ticketList = ticketCategory.Tickets.Where(x => x.Type == TicketType.Payment && (x.Status == TicketStatus.Reserved || x.Status == TicketStatus.WaitingForPayment || x.Status == TicketStatus.Paid));

        if(ticketCategory.Quota == ticketList.Count())
            throw new InvalidOperationException("Ticket Category is full!");

        var ticket = _mapper.Map<Ticket>(Model);
        ticket.Status = TicketStatus.Reserved;
        ticket.Type = TicketType.Payment;
        ticket.Date = DateTime.Now;
        ticket.Token = DateTime.Now.ToString();

        _context.Tickets.Add(ticket);
        _context.SaveChanges();
    }

}