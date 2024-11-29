using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.OrganizerOperations.Commands.DeleteOrganizer;

public class DeleteOrganizerCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteOrganizerCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var organizer = _context.Organizers.FirstOrDefault(x => x.Id == Id);
        if (organizer is null)
            throw new InvalidOperationException("Organizer is not found!");

        _context.Organizers.Remove(organizer);
        _context.SaveChanges();
    }
}