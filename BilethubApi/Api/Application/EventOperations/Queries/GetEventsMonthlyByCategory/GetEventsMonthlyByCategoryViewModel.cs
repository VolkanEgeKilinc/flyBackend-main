namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventsMonthlyByCategory;

public class GetEventsMonthlyByCategoryViewModel{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Price { get; set; } = null!;
    public int EventsCount { get; set; }
    public DateTime Start { get; set; }
}