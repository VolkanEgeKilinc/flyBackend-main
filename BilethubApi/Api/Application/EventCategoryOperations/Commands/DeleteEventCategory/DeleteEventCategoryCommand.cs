using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.EventCategoryOperations.Commands.DeleteEventCategory;

public class DeleteEventCategoryCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }

    public DeleteEventCategoryCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var eventCategory = _context.EventCategories.FirstOrDefault(x => x.Id == Id);
        if (eventCategory is null)
            throw new InvalidOperationException("EventCategory is not found!");

        _context.EventCategories.Remove(eventCategory);
        _context.SaveChanges();
    }
}