using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaceDetail;

public class GetPlaceDetailQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public int UserId { get; set; }

    public GetPlaceDetailQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetPlaceDetailViewModel Handle()
    {
        var place = _context.Places
            .Include(x => x.District)
            .Include(x => x.City)
            .Include(x => x.PlaceGenre)
            .Include(x => x.Followers)
            .Include(x => x.Comments)
                .ThenInclude(c => c.User)
            .Include(x => x.Events.Where(e => e.Status == EventStatus.Approved && e.Start > DateTime.Now))
                .ThenInclude(x => x.TicketCategories)
            .Include(x => x.Events)
                .ThenInclude(x => x.Genre)
            .FirstOrDefault(x => x.Id == Id);

        if(place is null)
            throw new InvalidOperationException("Place is not found!");

        var isFollowing = place.Followers.Any(x => x.UserId == UserId);

        var vm = _mapper.Map<GetPlaceDetailViewModel>(place);
        vm.IsFollowing = isFollowing;

        return vm;
    }
}