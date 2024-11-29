using NetTopologySuite.Geometries;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.CreateArtist;

public class CreateArtistModel
{
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Description { get; set; } = null!;
}