using AutoMapper;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.SearchOperations.Queries.GetSearch;

public class GetSearchQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public string QueryText { get; set; } = null!;

    public GetSearchQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetSearchViewModel> Handle()
    {
        var resultList = new List<GetSearchViewModel>();

        var eventList = _context.Events
            .Include(x => x.Genre)
            .Where(x => x.Start > DateTime.Now && x.Title.ToLower().Contains(QueryText.ToLower()))
            .Take(10);

        var placeList = _context.Places
            .Include(x => x.PlaceGenre)
            .Where(x => x.Title.ToLower().Contains(QueryText.ToLower()))
            .Take(10);

        var artistList = _context.Artists
            .Include(x => x.ArtistGenres)
                .ThenInclude(g => g.Genre)
            .Where(x => $"{x.Name} {x.Surname}".ToLower().Contains(QueryText.ToLower()))
            .Take(10);

        resultList.AddRange(_mapper.Map<List<GetSearchViewModel>>(eventList));
        resultList.AddRange(_mapper.Map<List<GetSearchViewModel>>(placeList));
        resultList.AddRange(_mapper.Map<List<GetSearchViewModel>>(artistList));

        resultList = resultList.OrderBy(x => x.Id).ToList();

        return resultList;
    }
}