using System.ComponentModel.DataAnnotations.Schema;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Entities;

public class Coupon
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Title { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int Quota { get; set; }
    public double Discount { get; set; }
    public DiscountType DiscountType { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; } = true;


    public Event Event { get; set; } = null!;
    public List<Ticket> Tickets { get; set; } = null!;
}