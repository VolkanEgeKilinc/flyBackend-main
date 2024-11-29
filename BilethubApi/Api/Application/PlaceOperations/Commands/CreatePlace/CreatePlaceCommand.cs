using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.CreatePlace;

public class CreatePlaceCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreatePlaceModel Model { get; set; } = null!;

    public CreatePlaceCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var place = _context.Places.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());
        if (place is not null)
            throw new InvalidOperationException("Place with same name is already exist!");

        place = _mapper.Map<Place>(Model);
        _context.Places.Add(place);
    }
}