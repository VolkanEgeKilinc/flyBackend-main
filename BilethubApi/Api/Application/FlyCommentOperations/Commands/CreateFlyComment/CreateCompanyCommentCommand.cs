using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Commands.CreateArtistComment;

public class CreateArtistCommentCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreateArtistCommentModel Model { get; set; } = null!;

    public CreateArtistCommentCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var artistComment = _mapper.Map<ArtistComment>(Model);

        _context.ArtistComments.Add(artistComment);
        _context.SaveChanges();
    }

}