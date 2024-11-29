using AutoMapper;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Common.Model;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventsByLocation;

public class GetEventsByLocationQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public Point Location { get; set; } = null!;


    public GetEventsByLocationQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetEventsByLocationViewModel> Handle()
    {
        var eventList = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.TicketCategories)
            .Where(x => x.Status == EventStatus.Approved && x.Start.Subtract(DateTime.Now).TotalDays >= 0 && x.Place.Location.Distance(Location) < 10)
            .GroupBy(x => x.Place.Id);

        var vm = eventList.Select(x => new GetEventsByLocationViewModel
        {
            Id = x.First().Id,
            Place = x.First().Place.Title,
            Location = _mapper.Map<LocationModel>(x.First().Place.Location),
            Events = _mapper.Map<List<GetEventsViewModel>>(x.ToList())

        }).ToList();

        return vm;
    }
}