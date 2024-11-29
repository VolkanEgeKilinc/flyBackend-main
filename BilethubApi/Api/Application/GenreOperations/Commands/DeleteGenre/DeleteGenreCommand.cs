using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteGenreCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Id == Id);
        if (genre is null)
            throw new InvalidOperationException("Genre is not found!");

        _context.Genres.Remove(genre);
        _context.SaveChanges();
    }
}