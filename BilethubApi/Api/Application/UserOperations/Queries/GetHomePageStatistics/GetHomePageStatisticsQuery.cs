using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetHomePageStatistics;

public class GetHomePageStatisticsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }

    public GetHomePageStatisticsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetHomePageStatisticsViewModel Handle()
    {
        if(!_context.Organizers.Any(x => x.UserId == UserId))
            throw new InvalidOperationException("User is not an organizer!");


        var organizer = _context.Users.Include(x=> x.Organizer!.Events).ThenInclude(x => x.TicketCategories).ThenInclude(x => x.Tickets).FirstOrDefault(x => x.Id == UserId)!.Organizer!;

        var today = DateTime.Now;

        var vm = new GetHomePageStatisticsViewModel{
            Balance = organizer.Events.Select(x => x.TicketCategories.Select(tc => tc.Tickets.Where(ticket => ticket.Date.Month == today.Month && ticket.Date.Year == today.Year).Sum(ticket => ticket.Price)).Sum()).Sum(),
            BalanceIncrease = 0,
            Views = new List<object>()
        };

        today.AddMonths(-1);
        var previousMonthBalance = organizer.Events.Select(x => x.TicketCategories.Select(tc => tc.Tickets.Where(ticket => ticket.Date.Month == today.Month && ticket.Date.Year == today.Year).Sum(ticket => ticket.Price)).Sum()).Sum();


        for(int i = 6; i>=0; i--){
            vm.Views.Add(new {
                Date = DateTime.Now.AddDays(-i),
                ViewCount = 0
            });
        }
        // var vm = _mapper.Map<GetHomePageStatisticsViewModel>(organizer);

        return vm;
    }
}