using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Commands.DeletePlaceFollower;

public class DeletePlaceFollowerCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public DeletePlaceFollowerCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var place = _context.Places
            .Include(x => x.Followers)
            .FirstOrDefault(x => x.Id == Id);
        if (place is null)
            throw new InvalidOperationException("Place is not found!");

        var follower = place.Followers.FirstOrDefault(x => x.UserId == UserId);
        if (follower is null)
            throw new InvalidOperationException("Place is already unfollowed!");

        place.Followers.Remove(follower);
        _context.SaveChanges();
    }
}