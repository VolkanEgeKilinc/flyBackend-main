using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Commands.CreateArtistFollower;

public class CreateArtistFollowerCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public CreateArtistFollowerCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var artist = _context.Company
            .Include(x => x.Followers)
            .FirstOrDefault(x => x.Id == Id);
            
        if (artist is null)
            throw new InvalidOperationException("Artist is not found!");

        if (artist.Followers.Any(x => x.UserId == UserId))
            throw new InvalidOperationException("Artist is already followed!");

        artist.Followers.Add(new Company
        {
            UserId = UserId,
            Date = DateTime.Now
        });
        _context.SaveChanges();
    }
}