using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Commands.DeleteArtistFollower;

public class DeleteArtistFollowerCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public DeleteArtistFollowerCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var artist = _context.Artists
            .Include(x => x.Followers)
            .FirstOrDefault(x => x.Id == Id);
        if (artist is null)
            throw new InvalidOperationException("Artist is not found!");

        var follower = artist.Followers.FirstOrDefault(x => x.UserId == UserId);

        if (follower is null)
            throw new InvalidOperationException("Artist is already unfollowed!");

        artist.Followers.Remove(follower);
        _context.SaveChanges();
    }
}