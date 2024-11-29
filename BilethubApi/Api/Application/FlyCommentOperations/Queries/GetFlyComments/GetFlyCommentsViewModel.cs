namespace BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;

public class GetArtistCommentsViewModel{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime Date { get; set; }
}