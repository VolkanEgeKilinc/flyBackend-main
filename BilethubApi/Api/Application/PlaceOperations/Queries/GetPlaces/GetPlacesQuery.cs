using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;

public class GetPlacesQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetPlacesQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetPlacesViewModel> Handle()
    {
        var placeList = _context.Places.Include(x => x.District).Include(x => x.City).Include(x => x.PlaceGenre).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetPlacesViewModel>>(placeList);

        return vm;
    }
}