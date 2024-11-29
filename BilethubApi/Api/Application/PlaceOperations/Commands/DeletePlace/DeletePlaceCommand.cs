using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.DeletePlace;

public class DeletePlaceCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeletePlaceCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var place = _context.Places.FirstOrDefault(x => x.Id == Id);
        if (place is null)
            throw new InvalidOperationException("Place is not found!");

        _context.Places.Remove(place);
        _context.SaveChanges();
    }
}