using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.OrganizerOperations.Queries.GetOrganizers;

public class GetOrganizersQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetOrganizersQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetOrganizersViewModel> Handle()
    {
        var organizer = _context.Organizers.Include(x=> x.User).OrderBy(x => x.Id);
        
        var vm = _mapper.Map<List<GetOrganizersViewModel>>(organizer);

        return vm;
    }
}