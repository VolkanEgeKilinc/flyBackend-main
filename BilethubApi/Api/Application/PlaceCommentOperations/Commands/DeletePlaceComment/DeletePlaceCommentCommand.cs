using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Commands.DeletePlaceComment;

public class DeletePlaceCommentCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeletePlaceCommentCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var placeComment = _context.PlaceComments.FirstOrDefault(x => x.Id == Id);
        if (placeComment is null)
            throw new InvalidOperationException("Comment is not found!");

        _context.PlaceComments.Remove(placeComment);
        _context.SaveChanges();
    }
}