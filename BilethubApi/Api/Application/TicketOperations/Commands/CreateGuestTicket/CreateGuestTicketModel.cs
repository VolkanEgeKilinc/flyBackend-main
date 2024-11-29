namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateGuestTicket;

public class CreateGuestTicketModel
{
    public int UserId { get; set; }
    public int TicketCategoryId { get; set; }
}