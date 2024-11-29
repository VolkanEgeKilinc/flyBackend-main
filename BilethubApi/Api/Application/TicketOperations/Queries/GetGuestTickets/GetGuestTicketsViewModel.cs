
namespace BilethubApi.Api.Application.TicketOperations.Queries.GetGuestTickets;

public class GetGuestTicketsViewModel
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime Date { get; set; }
}