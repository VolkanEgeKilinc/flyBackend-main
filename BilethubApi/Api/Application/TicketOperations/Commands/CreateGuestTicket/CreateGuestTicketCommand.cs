using System.Net;
using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateGuestTicket;

public class CreateGuestTicketCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateGuestTicketModel Model { get; set; } = null!;
    public int UserId { get; set; }

    public CreateGuestTicketCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var ticketCategory = _context.TicketCategories.Include(x => x.Tickets).Include(x => x.Event.Organizer).FirstOrDefault(x => x.Id == Model.TicketCategoryId);
        if (ticketCategory is null)
            throw new InvalidOperationException("Ticket Category is not found!");

        if(ticketCategory.Event.Organizer.UserId != UserId)
            throw new HttpRequestException("Only organizers can add guest to their events!", null, HttpStatusCode.Forbidden);

        var ticketList = ticketCategory.Tickets.Where(x => (x.Status == TicketStatus.Reserved || x.Status == TicketStatus.WaitingForPayment || x.Status == TicketStatus.Paid));
        if(ticketCategory.Quota == ticketList.Count())
            throw new InvalidOperationException("Ticket Category is full!");

        var hasTicket = ticketCategory.Tickets.Any(x => x.UserId == Model.UserId && x.Type == TicketType.Guest && x.TicketCategoryId == Model.TicketCategoryId);
            
        if(hasTicket)
            throw new InvalidOperationException("Guest has already added to this ticket category!");

        var ticket = _mapper.Map<Ticket>(Model);
        ticket.Status = TicketStatus.Paid;
        ticket.Type = TicketType.Guest;
        ticket.Date = DateTime.Now;
        ticket.Token = DateTime.Now.ToString();

        _context.Tickets.Add(ticket);
        _context.SaveChanges();
    }

}