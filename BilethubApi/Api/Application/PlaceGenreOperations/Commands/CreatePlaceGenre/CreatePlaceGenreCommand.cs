using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.CreatePlaceGenre;

public class CreatePlaceGenreCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreatePlaceGenreModel Model { get; set; } = null!;

    public CreatePlaceGenreCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var placeGenre = _context.PlaceGenres.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());

        if (placeGenre is not null)
            throw new InvalidOperationException("Place Genre with same name is already exist!");

        placeGenre = _mapper.Map<PlaceGenre>(Model);

        _context.PlaceGenres.Add(placeGenre);
        _context.SaveChanges();
    }
}