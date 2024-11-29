
namespace BilethubApi.Api.Application.UserOperations.Queries.GetUsersBySearch;

public class GetUsersBySearchViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}