using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;

public class GetArtistCommentsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int ArtistId { get; set; }

    public GetArtistCommentsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetArtistCommentsViewModel> Handle()
    {
        var artistCommentList = _context.ArtistComments.Where(x => x.ArtistId == ArtistId).Include(c => c.User);

        var vm = _mapper.Map<List<GetArtistCommentsViewModel>>(artistCommentList);

        return vm;
    }
}