using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;

namespace BilethubApi.Api.Application.SearchOperations.Queries.GetSummary;

public class GetSummaryViewModel
{
    public List<GetEventsViewModel> Events { get; set; } = null!;
    public List<GetPlacesViewModel> Places { get; set; } = null!;
    public List<GetArtistsViewModel> Artists { get; set; } = null!;
}