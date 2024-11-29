namespace BilethubApi.Api.Application.PlaceCommentOperations.Commands.CreatePlaceComment;

public class CreatePlaceCommentModel
{
    public int UserId { get; set; }
    public int PlaceId { get; set; }
    public string Content { get; set; } = null!;
}