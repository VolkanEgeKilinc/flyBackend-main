using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Common.Model;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventsByLocation;

public class GetEventsByLocationViewModel
{
    public int Id { get; set; }
    public string Place { get; set; } = null!;
    public LocationModel Location { get; set; } = null!;

    public List<GetEventsViewModel> Events { get; set; } = null!;
}