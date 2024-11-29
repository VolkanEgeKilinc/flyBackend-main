using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByEvent;

public class GetTicketsByEventQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventId { get; set; }
    public int UserId { get; set; }

    public GetTicketsByEventQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetTicketsByEventViewModel Handle()
    {
        var eventData = _context.Events
            .Include(x => x.Organizer)
            .Include(x => x.TicketCategories)
            .ThenInclude(x => x.Tickets)
            .ThenInclude(x => x.User)
            .FirstOrDefault(x => x.Id == EventId);

        if (eventData is null)
            throw new InvalidOperationException("Event is not found!");

        if (eventData.Organizer.UserId != UserId)
            throw new InvalidOperationException("User is not organizer of this event!");

        var ticketList = eventData.TicketCategories.SelectMany(x => x.Tickets.Where(t => t.Status == TicketStatus.Paid && t.Type == TicketType.Payment));

        var vm = new GetTicketsByEventViewModel{
            TicketCount = ticketList.Count(),
            ScannedTicketCount = 0,
            Tickets = _mapper.Map<List<GetTicketsByEventTicketViewModel>>(ticketList)
        };

        return vm;
    }
}