using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.PlaceCommentOperations.Queries.GetPlaceComments;
using BilethubApi.Api.Common.Model;

namespace BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaceDetail;

public class GetPlaceDetailViewModel
{
    public int Id { get; set; }
    public string PlaceGenre { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string District { get; set; } = null!;
    public string City { get; set; } = null!;
    public LocationModel Location { get; set; } = null!;
    public int FollowersCount { get; set; }
    public int CommentsCount { get; set; }
    public bool IsFollowing { get; set; }

    public List<GetEventsViewModel> Events { get; set; } = null!;
    public List<GetPlaceCommentsViewModel> Comments { get; set; } = null!;
}