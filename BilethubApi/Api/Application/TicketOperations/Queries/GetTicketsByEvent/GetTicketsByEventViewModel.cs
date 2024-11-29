
namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByEvent;

public class GetTicketsByEventViewModel
{
    public int ScannedTicketCount { get; set; }
    public int TicketCount { get; set; }
    public List<GetTicketsByEventTicketViewModel> Tickets {get; set;}= null!;
}

public class GetTicketsByEventTicketViewModel
{
    public int Id { get; set; }
    public string Owner { get; set; } = null!;
    public DateTime Date { get; set; }
    public double Price { get; set; }
}