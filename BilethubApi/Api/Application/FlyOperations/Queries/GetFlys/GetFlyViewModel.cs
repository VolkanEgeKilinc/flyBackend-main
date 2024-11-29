
namespace BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;

public class GetArtistsViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public List<string> Genres { get; set; } = null!;
}