using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Queries.GetPlaceFollowers;

public class GetPlaceFollowersQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int PlaceId { get; set; }

    public GetPlaceFollowersQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetPlaceFollowersViewModel> Handle()
    {
        var place = _context.Places
            .Include(a => a.Followers)
                .ThenInclude(flw => flw.User)
            .FirstOrDefault(x => x.Id == PlaceId);

        if (place is null)
            throw new InvalidOperationException("Place is not found!");

        var followerList = place.Followers;

        var vm = _mapper.Map<List<GetPlaceFollowersViewModel>>(followerList);

        return vm;
    }
}