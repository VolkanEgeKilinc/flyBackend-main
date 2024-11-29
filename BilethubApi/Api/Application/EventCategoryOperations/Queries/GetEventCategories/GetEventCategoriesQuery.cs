using AutoMapper;
using BilethubApi.Api.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.Application.EventCategoryOperations.Queries.GetEventCategories;

public class GetEventCategoriesQuery
{
    private IBilethubDbContext _context;
    private IMapper _mapper;
    public int Limit { get; set; }

    public GetEventCategoriesQuery(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetEventCategoriesViewModel> Handle()
    {
        var eventCategoryList = _context.EventCategories.Where(x => x.Status).OrderBy(x => x.Id);

        var vm = _mapper.Map<List<GetEventCategoriesViewModel>>(eventCategoryList);

        if (Limit != 0) vm = vm.Take(Limit).ToList();

        return vm;
    }
}