using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetAdminEventTicketCategories;

public class GetAdminEventTicketCategoriesQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }

    public GetAdminEventTicketCategoriesQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetAdminEventTicketCategoriesViewModel> Handle()
    {
        var ticketList = _context.TicketCategories.Include(x => x.Tickets).Where(x => x.EventId == Id).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetAdminEventTicketCategoriesViewModel>>(ticketList);

        return vm;
    }
}