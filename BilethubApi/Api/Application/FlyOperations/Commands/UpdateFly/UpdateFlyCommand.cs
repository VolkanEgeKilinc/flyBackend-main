using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.UpdateArtist;

public class UpdateArtistCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdateArtistModel Model { get; set; } = null!;

    public UpdateArtistCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var artist = _context.Artists.FirstOrDefault(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower());
        if (artist is not null)
            throw new InvalidOperationException("Artist with same name is already exist!");

        artist = _context.Artists.FirstOrDefault(x => x.Id == Id);
        if (artist is null)
            throw new InvalidOperationException("Artist is not found!");

        artist.Image = Model.Image != default ? Model.Image : artist.Image;
        artist.Name = Model.Name != default ? Model.Name : artist.Name;
        artist.Surname = Model.Surname != default ? Model.Surname : artist.Surname;
        artist.Description = Model.Description != default ? Model.Description : artist.Description;

        _context.SaveChanges();
    }
}