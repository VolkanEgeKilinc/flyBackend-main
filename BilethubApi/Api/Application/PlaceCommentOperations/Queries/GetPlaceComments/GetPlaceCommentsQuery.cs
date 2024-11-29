using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Queries.GetPlaceComments;

public class GetPlaceCommentsQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int PlaceId { get; set; }

    public GetPlaceCommentsQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetPlaceCommentsViewModel> Handle()
    {
        var placeCommentList = _context.PlaceComments.Where(x => x.PlaceId == PlaceId).Include(c => c.User);

        var vm = _mapper.Map<List<GetPlaceCommentsViewModel>>(placeCommentList);

        return vm;
    }
}