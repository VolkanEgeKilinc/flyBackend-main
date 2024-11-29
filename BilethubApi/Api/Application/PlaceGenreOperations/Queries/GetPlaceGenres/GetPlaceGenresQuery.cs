using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Queries.GetPlaceGenres;

public class GetPlaceGenresQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetPlaceGenresQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetPlaceGenresViewModel> Handle()
    {
        var placeGenreList = _context.PlaceGenres.OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetPlaceGenresViewModel>>(placeGenreList);

        return vm;
    }
}