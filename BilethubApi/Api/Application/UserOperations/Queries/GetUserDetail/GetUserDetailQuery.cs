using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQuery
{

    private IBilethubDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }

    public GetUserDetailQuery(IBilethubDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }


    public GetUserDetailViewModel Handle(){
        var user = _context.Users.FirstOrDefault(x => x.Id == Id);

        if(user is null)
            throw new InvalidOperationException("User is not found!");
        
        var vm = _mapper.Map<GetUserDetailViewModel>(user);

        return vm;
    }
}