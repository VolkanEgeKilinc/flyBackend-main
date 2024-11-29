using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.CreateArtist;

public class CreateArtistCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateArtistModel Model { get; set; } = null!;

    public CreateArtistCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var artist = _context.Company.FirstOrDefault(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower());

        if (artist is not null)
            throw new InvalidOperationException("Artist with same name is already exist!");

        artist = _mapper.Map<Company>(Model);

        _context.Company.Add(artist);
        _context.SaveChanges();
    }
}