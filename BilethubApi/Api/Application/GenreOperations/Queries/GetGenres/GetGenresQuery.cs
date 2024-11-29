using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.GenreOperations.Queries.GetGenres;

public class GetGenresQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;
    public int Limit { get; set; }

    public GetGenresQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetGenresViewModel> Handle()
    {
        var genreList = _context.Genres.Where(x => x.Status).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetGenresViewModel>>(genreList);

        if (Limit != 0) vm = vm.Take(Limit).ToList();

        return vm;
    }
}