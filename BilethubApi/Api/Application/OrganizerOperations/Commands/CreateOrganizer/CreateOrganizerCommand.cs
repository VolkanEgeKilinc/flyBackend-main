using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.OrganizerOperations.Commands.CreateOrganizer;

public class CreateOrganizerCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }

    public CreateOrganizerCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        if(_context.Organizers.Any(x => x.UserId == UserId))
            throw new InvalidOperationException("Organizer with same userId is already exist!");

        _context.Organizers.Add(new Organizer
        {
            UserId = UserId
        });
        _context.SaveChanges();
    }

}