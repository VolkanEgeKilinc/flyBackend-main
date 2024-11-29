namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketByToken;

public class GetTicketByTokenViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string TicketCategory { get; set; } = null!;
}