using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetTicketCategories;

public class GetTicketCategoriesQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GetTicketCategoriesQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetTicketCategoriesViewModel> Handle()
    {
        var ticketCategoryList = _context.TicketCategories.Include(x => x.Tickets).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetTicketCategoriesViewModel>>(ticketCategoryList);

        return vm;
    }
}