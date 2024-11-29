using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Queries.GetArtistFollowers;

public class GetArtistFollowersQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int ArtistId { get; set; }

    public GetArtistFollowersQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetArtistFollowersViewModel> Handle()
    {
        var artist = _context.Artists
            .Include(a => a.Followers)
                .ThenInclude(flw => flw.User)
            .FirstOrDefault(x => x.Id == ArtistId);

        if (artist is null)
            throw new InvalidOperationException("Artist is not found!");

        var followerList = artist.Followers;

        var vm = _mapper.Map<List<GetArtistFollowersViewModel>>(followerList);

        return vm;
    }
}