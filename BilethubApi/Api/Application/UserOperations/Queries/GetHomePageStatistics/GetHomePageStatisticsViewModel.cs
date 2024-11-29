namespace BilethubApi.Api.Application.UserOperations.Queries.GetHomePageStatistics;

public class GetHomePageStatisticsViewModel
{
    public double Balance { get; set; }
    public double BalanceIncrease { get; set; }
    public List<Object> Views { get; set; } = null!;
}