using System.Net;
using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Commands.UpdateEvent;

public class UpdateEventCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public int UserId { get; set; }
    public UpdateEventModel Model { get; set; } = null!;

    public UpdateEventCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var data = _context.Events.Include(x => x.Organizer).FirstOrDefault(x => x.Id != Id && x.Organizer.UserId == UserId && x.Start.Month == Model.Start.Month && x.Start.Day == Model.Start.Day);
        if (data is not null)
            throw new InvalidOperationException("Event with same organizer and same date is exist!");

        data = _context.Events.Include(x => x.Organizer).Include(x => x.EventArtists).FirstOrDefault(x => x.Id == Id);
        if (data is null)
            throw new InvalidOperationException("Event is not found!");

        if (data.Organizer.UserId != UserId)
            throw new HttpRequestException("User is not organizer of this event!", null, HttpStatusCode.Forbidden);

        data.PlaceId = Model.PlaceId != default ? Model.PlaceId : data.PlaceId;
        data.GenreId = Model.GenreId != default ? Model.GenreId : data.GenreId;
        data.EventCategoryId = Model.EventCategoryId != default ? Model.EventCategoryId : data.EventCategoryId;
        data.Image = Model.Image != default ? Model.Image : data.Image;
        data.Title = Model.Title != default ? Model.Title : data.Title;
        data.Description = Model.Description != default ? Model.Description : data.Description;
        data.Start = Model.Start != default ? Model.Start : data.Start;
        data.Opening = Model.Opening != default ? Model.Opening : data.Opening;
        data.End = Model.End != default ? Model.End : data.End;
        data.HomePageVisibility = Model.HomePageVisibility != default ? Model.HomePageVisibility : data.HomePageVisibility;
        data.TicketTransfer = Model.TicketTransfer != default ? Model.TicketTransfer : data.TicketTransfer;

        data.EventArtists.RemoveAll(x => !Model.Artists.Any(artistId => artistId == x.ArtistId));

        Model.Artists.ForEach(artistId =>
        {
            var artist = data.EventArtists.FirstOrDefault(eventArtist => eventArtist.ArtistId == artistId);

            if (artist is null)
                data.EventArtists.Add(new EventArtist
                {
                    EventId = Id,
                    ArtistId = artistId
                });
        });

        _context.SaveChanges();
    }
}