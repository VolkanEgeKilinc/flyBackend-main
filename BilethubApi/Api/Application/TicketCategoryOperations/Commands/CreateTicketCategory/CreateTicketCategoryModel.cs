namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.CreateTicketCategory;

public class CreateTicketCategoryModel
{
    public int EventId { get; set; }
    public string Title { get; set; } = null!;
    public int Quota { get; set; }
    public double Price { get; set; }
}