using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.UpdatePlace;

public class UpdatePlaceCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdatePlaceModel Model { get; set; } = null!;

    public UpdatePlaceCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var place = _context.Places.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower() && x.Id != Id);
        if (place is not null)
            throw new InvalidOperationException("Place with same name is already exist!");

        place = _context.Places.FirstOrDefault(x => x.Id == Id);
        if (place is null)
            throw new InvalidOperationException("Place is not found!");

        place.Image = Model.Image != default ? Model.Image : place.Image;
        place.Title = Model.Title != default ? Model.Title : place.Title;
        place.Description = Model.Description != default ? Model.Description : place.Description;

        place.Address = Model.Address != default ? Model.Address : place.Address;
        place.DistrictId = Model.DistrictId != default ? Model.DistrictId : place.DistrictId;
        place.CityId = Model.CityId != default ? Model.CityId : place.CityId;
        place.CountryId = Model.CountryId != default ? Model.CountryId : place.CountryId;
        place.Location = Model.Location != default ? Model.Location : place.Location;

        _context.SaveChanges();
    }
}