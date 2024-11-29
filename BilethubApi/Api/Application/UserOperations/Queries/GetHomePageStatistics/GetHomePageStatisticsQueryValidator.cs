using FluentValidation;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetHomePageStatistics;

public class GetHomePageStatisticsQueryValidator : AbstractValidator<GetHomePageStatisticsQuery>
{
    public GetHomePageStatisticsQueryValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}