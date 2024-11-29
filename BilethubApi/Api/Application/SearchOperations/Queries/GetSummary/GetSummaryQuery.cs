using AutoMapper;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.SearchOperations.Queries.GetSummary;

public class GetSummaryQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetSummaryQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetSummaryViewModel Handle()
    {
        var summary = new GetSummaryViewModel();

        var eventList = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.TicketCategories)
            .Where(x => x.Start > DateTime.Now).OrderBy(x => x.Id).Take(2);
        var placeList = _context.Places
            .Include(x => x.District)
            .Include(x => x.City)
            .Include(x => x.PlaceGenre)
            .OrderBy(x => x.Id).Take(2);
        var artistList = _context.Artists
            .Include(x => x.ArtistGenres)
                .ThenInclude(g => g.Genre)
            .OrderBy(x => x.Id).Take(2);

        summary.Events = _mapper.Map<List<GetEventsViewModel>>(eventList);
        summary.Places = _mapper.Map<List<GetPlacesViewModel>>(placeList);
        summary.Artists = _mapper.Map<List<GetArtistsViewModel>>(artistList);


        return summary;
    }
}