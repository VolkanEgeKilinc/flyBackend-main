using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;

public class GetArtistsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetArtistsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetArtistsViewModel> Handle()
    {
        var artistList = _context.Artists.Include(x => x.ArtistGenres).ThenInclude(g => g.Genre).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetArtistsViewModel>>(artistList);

        return vm;
    }
}