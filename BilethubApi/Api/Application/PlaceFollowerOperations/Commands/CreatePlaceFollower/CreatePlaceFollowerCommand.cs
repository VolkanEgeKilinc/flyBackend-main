using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Commands.CreatePlaceFollower;

public class CreatePlaceFollowerCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }

    public CreatePlaceFollowerCommand(IBilethubDbContext context)
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

        if (place.Followers.Any(x => x.UserId == UserId))
            throw new InvalidOperationException("Place is already followed!");

        place.Followers.Add(new PlaceFollower
        {
            UserId = UserId,
            Date = DateTime.Now
        });
        _context.SaveChanges();
    }
}