namespace BilethubApi.Api.Application.EventOperations.Commands.UpdateEvent;

public class UpdateEventModel
{
    public int PlaceId { get; set; }
    public int GenreId { get; set; }
    public int EventCategoryId { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime? Opening { get; set; }
    public DateTime End { get; set; }
    public bool HomePageVisibility { get; set; }
    public bool TicketTransfer { get; set; }
    public List<int> Artists { get; set; } = null!;
}