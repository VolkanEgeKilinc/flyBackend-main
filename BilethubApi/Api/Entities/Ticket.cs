using System.ComponentModel.DataAnnotations.Schema;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Entities;

public class Ticket
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TicketCategoryId { get; set; }
    public int? CouponId { get; set; }
    public string Token { get; set; } = null!;
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public TicketType Type { get; set; }
    public TicketStatus Status { get; set; }


    public User User { get; set; } = null!;
    public Coupon? Coupon { get; set; }
    public TicketCategory TicketCategory { get; set; } = null!;
}