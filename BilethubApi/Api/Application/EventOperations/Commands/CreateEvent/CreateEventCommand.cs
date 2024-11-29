using System.Net;
using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Commands.CreateEvent;

public class CreateEventCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int UserId { get; set; }
    public CreateEventModel Model { get; set; } = null!;

    public CreateEventCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var data = _context.Events.Include(x => x.Organizer).FirstOrDefault(x => x.Organizer.UserId == UserId && x.Start.Month == Model.Start.Month && x.Start.Day == Model.Start.Day);
        if (data is not null)
            throw new HttpRequestException("Event with same organizer and same date is exist!", null, HttpStatusCode.Conflict);
        var organizer = _context.Users.Include(x => x.Organizer).FirstOrDefault(x => x.Id == UserId)?.Organizer;
        if (organizer is null)
            throw new HttpRequestException("User is not an organizer!", null, HttpStatusCode.Forbidden);

        data = _mapper.Map<Event>(Model);

        data.OrganizerId = organizer.Id;

        _context.Events.Add(data);

        Console.WriteLine(_context.SaveChanges());
    }

}