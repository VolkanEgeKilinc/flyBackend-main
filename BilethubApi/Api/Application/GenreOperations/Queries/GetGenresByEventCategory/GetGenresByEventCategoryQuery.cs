using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetGenresByEventCategory;

public class GetGenresByEventCategoryQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int EventCategoryId { get; set; }

    public GetGenresByEventCategoryQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetGenresByEventCategoryViewModel> Handle()
    {
        var genreList = _context.Events
            .Where(x => x.EventCategoryId == EventCategoryId)
            .Include(x => x.EventCategory)
            .Include(x => x.Genre)
            .GroupBy(x => x.GenreId);

        var vm = genreList.Select(x => new GetGenresByEventCategoryViewModel
        {
            Id = x.First().GenreId,
            CategoryId = x.First().EventCategoryId,
            Genre = x.First().Genre.Title,
            Category = x.First().EventCategory.Title,
        }).ToList();

        return vm;
    }
}