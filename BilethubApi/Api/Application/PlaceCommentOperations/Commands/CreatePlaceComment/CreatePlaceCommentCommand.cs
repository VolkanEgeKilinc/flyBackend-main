using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Commands.CreatePlaceComment;

public class CreatePlaceCommentCommand
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CreatePlaceCommentModel Model { get; set; } = null!;

    public CreatePlaceCommentCommand(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var placeComment = _mapper.Map<PlaceComment>(Model);

        _context.PlaceComments.Add(placeComment);
        _context.SaveChanges();
    }

}