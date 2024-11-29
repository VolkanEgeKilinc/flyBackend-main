namespace BilethubApi.Api.Application.ArtistCommentOperations.Commands.CreateArtistComment;

public class CreateArtistCommentModel
{
    public int UserId { get; set; }
    public int ArtistId { get; set; }
    public string Content { get; set; } = null!;
}