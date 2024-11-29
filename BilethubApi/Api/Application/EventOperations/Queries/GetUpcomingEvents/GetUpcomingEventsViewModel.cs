namespace BilethubApi.Api.Application.EventOperations.Queries.GetUpcomingEvents;

public class GetUpcomingEventsViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Place { get; set; } = null!;
    public string Price { get; set; } = null!;
    public DateTime Start { get; set; }
}