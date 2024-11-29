using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetAdminEventDetail;

public class GetAdminEventDetailQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public int UserId { get; set; }

    public GetAdminEventDetailQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetAdminEventDetailViewModel Handle()
    {
        var data = _context.Events
            .Include(x => x.Genre)
            .Include(x => x.Place)
            .Include(x => x.Coupons)
                .ThenInclude(x => x.Tickets)
            .Include(x => x.Organizer)
            .Include(x => x.EventArtists)
            .Include(x => x.TicketCategories)
                .ThenInclude(x => x.Tickets)
                    .ThenInclude(x => x.User)
            .FirstOrDefault(x => x.Status == EventStatus.Approved && x.Id == Id && x.Organizer.UserId == UserId);

        if (data is null)
            throw new InvalidOperationException("Event is not found!");

        var vm = _mapper.Map<GetAdminEventDetailViewModel>(data);

        var coupons = data.Coupons.Select(x => new
        {
            Code = x.Code,
            Used = x.Tickets.Count(),
        }).OrderByDescending(x => x.Used);

        vm.Coupons = coupons.Take(3).Cast<Object>().ToList();

        if(coupons.Count() > 3){
            vm.Coupons.Add(new { Code = "Others", Used = coupons.Skip(3).Sum(x => x.Used)});
        }

        return vm;
    }
}