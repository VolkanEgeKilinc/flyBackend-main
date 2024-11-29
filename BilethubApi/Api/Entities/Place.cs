using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace BilethubApi.Api.Entities;

public class Place
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PlaceGenreId { get; set; }
    public int DistrictId { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public string Address { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Point Location { get; set; } = null!;

    public PlaceGenre PlaceGenre { get; set; } = null!;
    public District District { get; set; } = null!;
    public City City { get; set; } = null!;
    public Country Country { get; set; } = null!;

    public List<Event> Events { get; set; } = null!;
    public List<PlaceFollower> Followers { get; set; } = null!;
    public List<PlaceComment> Comments { get; set; } = null!;
}