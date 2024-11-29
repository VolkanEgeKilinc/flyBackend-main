using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetUsersBySearch;

public class GetUsersBySearchQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public string? Search { get; set; }

    public GetUsersBySearchQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetUsersBySearchViewModel> Handle()
    {
        var userList = Search == null ? _context.Users.Take(10) : _context.Users.Where(x => (x.Name+x.Surname).ToLower().Contains(Search.ToLower()));

        var vm = _mapper.Map<List<GetUsersBySearchViewModel>>(userList);

        return vm;
    }
}