using FluentValidation;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>{

    public GetUserDetailQueryValidator(){
        RuleFor(query => query.Id).GreaterThan(0);
    }

}