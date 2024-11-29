using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetUpcomingEvents;

public class GetUpcomingEventsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }
    public int? Limit { get; set; }

    public GetUpcomingEventsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetUpcomingEventsViewModel> Handle()
    {
        var eventList = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.TicketCategories)
            .Include(x => x.Organizer.User)
            .Where(x => x.Organizer.UserId == UserId && x.Status == EventStatus.Approved && x.Start > DateTime.Now)
            .OrderBy(x => x.Start);

        var vm = _mapper.Map<List<GetUpcomingEventsViewModel>>(eventList);

        if (Limit is not null) vm = vm.Take(Limit.Value).ToList();

        return vm;
    }
}