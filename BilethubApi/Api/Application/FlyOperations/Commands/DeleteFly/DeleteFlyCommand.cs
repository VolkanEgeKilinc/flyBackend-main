using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.DeleteArtist;

public class DeleteArtistCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteArtistCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var artist = _context.Artists.FirstOrDefault(x => x.Id == Id);
        if (artist is null)
            throw new InvalidOperationException("Artist is not found!");

        _context.Artists.Remove(artist);
        _context.SaveChanges();
    }
}