namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateTicket;

public class CreateTicketModel
{
    public int UserId { get; set; }
    public int TicketCategoryId { get; set; }
}