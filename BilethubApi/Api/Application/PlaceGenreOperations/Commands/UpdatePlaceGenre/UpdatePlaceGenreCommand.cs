using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.UpdatePlaceGenre;

public class UpdatePlaceGenreCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdatePlaceGenreModel Model { get; set; } = null!;

    public UpdatePlaceGenreCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var placeGenre = _context.PlaceGenres.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower() && x.Id != Id);
        if(placeGenre is not null)
            throw new InvalidOperationException("Place Genre with same name is already exist!");

        placeGenre = _context.PlaceGenres.FirstOrDefault(x => x.Id == Id);
        if (placeGenre is null)
            throw new InvalidOperationException("Place Genre is not found!");

        placeGenre.Title = Model.Title != default ? Model.Title : placeGenre.Title;

        _context.SaveChanges();
    }
}