using BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Common.Model;

namespace BilethubApi.Api.Application.ArtistOperations.Queries.GetArtistDetail;

public class GetArtistDetailViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int FollowersCount { get; set; }
    public int CommentsCount { get; set; }
    public bool IsFollowing { get; set; }

    public List<string> Genres { get; set; } = null!;
    public List<GetArtistCommentsViewModel> Comments { get; set; } = null!;
    public List<GetEventsViewModel> Events { get; set; } = null!;
}