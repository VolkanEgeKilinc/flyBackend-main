using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class TicketCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Title { get; set; } = null!;
    public int Quota { get; set; }
    public double Price { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Status { get; set; }

    public Event Event { get; set; } = null!;
    public List<Ticket> Tickets { get; set; } = null!;
}