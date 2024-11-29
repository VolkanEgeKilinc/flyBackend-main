using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.DeletePlaceGenre;

public class DeletePlaceGenreCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeletePlaceGenreCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var placeGenre = _context.PlaceGenres.FirstOrDefault(x => x.Id == Id);
        if (placeGenre is null)
            throw new InvalidOperationException("Place Genre is not found!");

        _context.PlaceGenres.Remove(placeGenre);
        _context.SaveChanges();
    }
}