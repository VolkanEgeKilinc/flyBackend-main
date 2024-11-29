using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByUser;

public class GetTicketsByUserQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }

    public GetTicketsByUserQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetTicketsByUserViewModel> Handle()
    {
        var ticketList = _context.Tickets
            .Include(x => x.TicketCategory.Event.Place.District)
            .Include(x => x.TicketCategory.Event.Place.City)
            .Where(x => x.TicketCategory.Event.End > DateTime.Now && x.UserId == UserId);

        var vm = _mapper.Map<List<GetTicketsByUserViewModel>>(ticketList);

        return vm;
    }
}