namespace BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetTicketCategories;

public class GetTicketCategoriesViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Quota { get; set; }
    public int Available { get; set; }
    public double Price { get; set; }
}