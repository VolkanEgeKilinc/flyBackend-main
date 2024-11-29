using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.SearchOperations.Queries.GetSearch;

public class GetSearchViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public SearchType Type { get; set; }

}