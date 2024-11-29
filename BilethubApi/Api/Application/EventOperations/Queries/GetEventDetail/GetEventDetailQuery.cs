using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventDetail;

public class GetEventDetailQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public int UserId { get; set; }

    public GetEventDetailQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetEventDetailViewModel Handle()
    {
        var data = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.TicketCategories)
                .ThenInclude(x => x.Tickets)
            .Include(x => x.Organizer.User)
            .Include(x => x.EventReminders)
            .Include(x => x.EventArtists)
                .ThenInclude(a => a.Artist)
                .ThenInclude(a => a.ArtistGenres)
                .ThenInclude(g => g.Genre)
            .FirstOrDefault(x => x.Status == EventStatus.Approved && x.Id == Id);

        if(data is null)
            throw new InvalidOperationException("Event is not found!");

        var hasReminder = data.EventReminders.Any(x => x.UserId == UserId);
        
        var vm = _mapper.Map<GetEventDetailViewModel>(data);
        vm.HasReminder = hasReminder;

        return vm;
    }
}