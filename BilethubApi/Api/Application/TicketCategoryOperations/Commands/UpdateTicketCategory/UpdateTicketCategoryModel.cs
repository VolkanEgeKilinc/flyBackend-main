namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.UpdateTicketCategory;

public class UpdateTicketCategoryModel{
    public string Title { get; set; } = null!;
    public int Quota { get; set; }
    public double Price { get; set; }
}