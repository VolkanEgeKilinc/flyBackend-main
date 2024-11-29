
namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByUser;

public class GetTicketsByUserViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Price { get; set; }
    public string Address { get; set; } = null!;
    public string Place { get; set; } = null!;
    public string District { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Token { get; set; } = null!;
}