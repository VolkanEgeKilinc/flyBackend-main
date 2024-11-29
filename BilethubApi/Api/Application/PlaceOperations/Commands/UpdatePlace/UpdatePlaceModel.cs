using NetTopologySuite.Geometries;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.UpdatePlace;

public class UpdatePlaceModel
{
    public int PlaceTypeId { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int DistrictId { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public Point Location { get; set; } = null!;
}