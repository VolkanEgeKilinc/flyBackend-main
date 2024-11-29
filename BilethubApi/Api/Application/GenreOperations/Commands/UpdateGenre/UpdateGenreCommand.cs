using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdateGenreModel Model { get; set; } = null!;

    public UpdateGenreCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower() && x.Id != Id);
        if(genre is not null)
            throw new InvalidOperationException("Genre with same name is already exist!");

        genre = _context.Genres.FirstOrDefault(x => x.Id == Id);
        if (genre is null)
            throw new InvalidOperationException("Genre is not found!");

        genre.Title = Model.Title != default ? Model.Title : genre.Title;

        _context.SaveChanges();
    }
}