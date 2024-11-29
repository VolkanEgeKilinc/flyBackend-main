using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.EventCategoryOperations.Commands.CreateEventCategory;

public class CreateEventCategoryCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateEventCategoryModel Model { get; set; } = null!;

    public CreateEventCategoryCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var eventCategory = _context.EventCategories.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());

        if (eventCategory is not null)
            throw new InvalidOperationException("EventCategory with same name is already exist!");

        eventCategory = _mapper.Map<EventCategory>(Model);

        _context.EventCategories.Add(eventCategory);
        _context.SaveChanges();
    }
}