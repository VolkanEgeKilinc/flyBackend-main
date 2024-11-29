using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetGuestTickets;

public class GetGuestTicketsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventId { get; set; }
    public int UserId { get; set; }

    public GetGuestTicketsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetGuestTicketsViewModel> Handle()
    {
        var eventData = _context.Events
            .Include(x => x.Organizer)
            .Include(x => x.TicketCategories)
            .ThenInclude(x=> x.Tickets)
            .ThenInclude(x=> x.User)
            .FirstOrDefault(x => x.Id == EventId && x.Organizer.UserId == UserId);

        if(eventData is null)
            throw new InvalidOperationException("Event is not found!");

        var ticketList = eventData.TicketCategories.SelectMany(x => x.Tickets).Where(x => x.Type == TicketType.Guest);

        var vm = _mapper.Map<List<GetGuestTicketsViewModel>>(ticketList);

        return vm;
    }
}