using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetSuggestedEvents;

public class GetSuggestedEventsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }
    public int? Limit { get; set; }

    public GetSuggestedEventsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetSuggestedEventsViewModel> Handle()
    {
        //TODO: Return Suggested Events For User
        var eventList = _context.Events.Include(x => x.Genre).Include(x => x.Place).Include(x => x.TicketCategories).Where(x => x.Status == EventStatus.Approved).OrderBy(x => x.Id);
        
        var vm = _mapper.Map<List<GetSuggestedEventsViewModel>>(eventList);

        if (Limit is not null) vm = vm.Take(Limit.Value).ToList();

        return vm;
    }
}