using System.Net;
using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.CouponOperations.Queries.GetCouponsByEvent;

public class GetCouponsByEventQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventId { get; set; }
    public int UserId { get; set; }

    public GetCouponsByEventQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetCouponsByEventViewModel> Handle()
    {
        var data = _context.Events
            .Include(x => x.Organizer)
            .Include(x => x.Coupons)
            .FirstOrDefault(x => x.Id == EventId);

        if (data is null)
            throw new InvalidOperationException("Event is not found!");

        if (data.Organizer.UserId != UserId)
            throw new HttpRequestException("User is not organizer of this event!", null, HttpStatusCode.Forbidden);

        var couponList = data.Coupons;

        var vm = _mapper.Map<List<GetCouponsByEventViewModel>>(couponList);

        return vm;
    }
}