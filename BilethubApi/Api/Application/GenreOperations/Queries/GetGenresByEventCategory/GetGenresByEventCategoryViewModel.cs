namespace BilethubApi.Api.Application.EventOperations.Queries.GetGenresByEventCategory;

public class GetGenresByEventCategoryViewModel
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Genre { get; set; } = null!;
    public string Category { get; set; } = null!;
}