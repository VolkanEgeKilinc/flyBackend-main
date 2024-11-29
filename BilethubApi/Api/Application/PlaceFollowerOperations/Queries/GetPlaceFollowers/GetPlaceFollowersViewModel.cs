namespace BilethubApi.Api.Application.PlaceFollowerOperations.Queries.GetPlaceFollowers;

public class GetPlaceFollowersViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = null!;
    public string FullName { get; set; } = null!;
}