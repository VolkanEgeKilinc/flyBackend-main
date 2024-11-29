using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEvents;

public class GetEventsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public DateTime? StartDate { get; set; }
    public int? CategoryId { get; set; }
    public int? GenreId { get; set; }

    public GetEventsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetEventsViewModel> Handle()
    {
        var eventList = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.TicketCategories)
            .Where(x => x.Status == EventStatus.Approved
                && (GenreId == null ? true : x.GenreId == GenreId)
                && (CategoryId == null ? true : x.EventCategoryId == CategoryId)
                && (StartDate == null ? true : x.Start.Date == StartDate.Value.Date))
            .OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetEventsViewModel>>(eventList);

        return vm;
    }
}