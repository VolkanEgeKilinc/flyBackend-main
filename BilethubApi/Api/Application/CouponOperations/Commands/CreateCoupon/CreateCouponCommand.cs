using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.CouponOperations.Commands.CreateCoupon;

public class CreateCouponCommand
{


    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateCouponModel Model { get; set; } = null!;

    public CreateCouponCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var data = _context.Events.FirstOrDefault(x => x.Id == Model.EventId);
        if(data is null)
            throw new InvalidOperationException("Event is not found!");

        var coupon = data.Coupons.FirstOrDefault(x => x.Code == Model.Code);
        if (coupon is not null)
            throw new InvalidOperationException("Coupon with same code is exist for event!");

        coupon = _mapper.Map<Coupon>(Model);

        _context.Coupons.Add(coupon);
        _context.SaveChanges();
    }

}