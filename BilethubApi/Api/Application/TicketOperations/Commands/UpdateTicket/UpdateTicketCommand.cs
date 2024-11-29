using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.TicketOperations.Commands.UpdateTicket;

public class UpdateTicketCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdateTicketModel Model { get; set; } = null!;

    public UpdateTicketCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var ticket = _context.Tickets.FirstOrDefault(x => x.Id == Id);
        if (ticket is null)
            throw new InvalidOperationException("Ticket is not found!");

        ticket.UserId = Model.UserId != default ? Model.UserId : ticket.UserId;

        if (ticket.Status == TicketStatus.Reserved)
        {
            if (Model.CouponId != default)
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.Id == Model.CouponId && x.Status);
                if (coupon == null)
                    throw new InvalidOperationException("Coupon is not found!");

                var couponTicketList = coupon.Tickets.Where(x => x.Status == TicketStatus.Reserved || x.Status == TicketStatus.WaitingForPayment || x.Status == TicketStatus.Paid);
                if (coupon.Quota == couponTicketList.Count())
                    throw new InvalidOperationException("Coupon quota full!");
                ticket.CouponId = Model.CouponId;
            }
        }

        _context.SaveChanges();
    }
}