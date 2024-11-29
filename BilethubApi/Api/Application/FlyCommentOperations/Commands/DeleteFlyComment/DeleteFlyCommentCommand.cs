using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Commands.DeleteArtistComment;

public class DeleteArtistCommentCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteArtistCommentCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var artistComment = _context.ArtistComments.FirstOrDefault(x => x.Id == Id);
        if (artistComment is null)
            throw new InvalidOperationException("Comment is not found!");

        _context.ArtistComments.Remove(artistComment);
        _context.SaveChanges();
    }
}