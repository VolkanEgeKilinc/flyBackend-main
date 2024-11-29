using NetTopologySuite.Geometries;

namespace BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;

public class GetPlacesViewModel
{
    public int Id { get; set; }
    public string PlaceGenre { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string District { get; set; } = null!;
    public string City { get; set; } = null!;
}