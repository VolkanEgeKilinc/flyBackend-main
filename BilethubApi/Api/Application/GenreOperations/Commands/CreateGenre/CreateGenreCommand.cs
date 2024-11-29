using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateGenreModel Model { get; set; } = null!;

    public CreateGenreCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());

        if (genre is not null)
            throw new InvalidOperationException("Genre with same name is already exist!");

        genre = _mapper.Map<Genre>(Model);

        _context.Genres.Add(genre);
        _context.SaveChanges();
    }
}