namespace BilethubApi.Api.Application.ArtistFollowerOperations.Queries.GetArtistFollowers;

public class GetArtistFollowersViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = null!;
    public string FullName { get; set; } = null!;
}