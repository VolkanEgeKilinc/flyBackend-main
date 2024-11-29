using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketByToken;

public class GetTicketByTokenQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventId { get; set; }
    public string Token { get; set; } = null!;

    public GetTicketByTokenQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetTicketByTokenViewModel Handle()
    {
        var ticket = _context.Tickets.Include(x => x.TicketCategory).Include(x => x.User).FirstOrDefault(x => x.TicketCategory.EventId == EventId && x.Token == Token);
        if (ticket is null)
            throw new InvalidOperationException("Ticket is not found!");

        var vm = _mapper.Map<GetTicketByTokenViewModel>(ticket);

        return vm;
    }
}