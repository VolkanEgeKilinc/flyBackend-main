using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventsMonthlyByCategory;

public class GetEventsMonthlyByCategoryQuery
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventCategoryId { get; set; }
    public int Limit { get; set; }

    public GetEventsMonthlyByCategoryQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public List<GetEventsMonthlyByCategoryViewModel> Handle()
    {
        var nextMonth = DateTime.Now.AddDays(30);
        var eventList = _context.Events
            .Where(x => x.Status == EventStatus.Approved && x.EventCategoryId == EventCategoryId && x.Start < nextMonth)
            .Include(x => x.Genre)
            .Include(x => x.TicketCategories)
            .GroupBy(x => x.Start.Day.ToString() + x.Start.Month.ToString());

        var vm = eventList.Select(x => new GetEventsMonthlyByCategoryViewModel
        {
            Id = x.First().Id,
            Image = x.First().Image,
            Title = x.First().Title,
            Genre = x.First().Genre.Title,
            Price = $"{x.First().TicketCategories.Select(x => x.Price).Min()} - {x.First().TicketCategories.Select(x => x.Price).Max()}",
            EventsCount = x.Count() - 1,
            Start = x.First().Start
        }).ToList();

        if (Limit != 0) vm = vm.Take((int)Limit).ToList();

        return vm;
    }
}