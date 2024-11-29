using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistOperations.Queries.GetArtistDetail;

public class GetArtistDetailQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public int UserId { get; set; }

    public GetArtistDetailQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetArtistDetailViewModel Handle()
    {
        var artist = _context.Artists
            .Include(x => x.ArtistGenres)
                .ThenInclude(g => g.Genre)
            .Include(x => x.Followers)
            .Include(x => x.Comments)
                .ThenInclude(c => c.User)
            .Include(x => x.EventArtists.Where(e => e.Event.Status == EventStatus.Approved && e.Event.Start > DateTime.Now))
                .ThenInclude(x => x.Event.TicketCategories)
            .Include(x => x.EventArtists)
                .ThenInclude(x => x.Event.Place)
            .FirstOrDefault(x => x.Id == Id);

        if(artist is null)
            throw new InvalidOperationException("Artist is not found!");

        var isFollowing = artist.Followers.Any(x => x.UserId == UserId);
        
        var vm = _mapper.Map<GetArtistDetailViewModel>(artist);
        vm.IsFollowing = isFollowing;

        return vm;
    }
}