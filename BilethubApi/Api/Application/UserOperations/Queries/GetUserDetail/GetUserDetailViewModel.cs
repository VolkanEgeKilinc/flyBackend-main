using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.UserOperations.Queries.GetUserDetail;

public class GetUserDetailViewModel{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string Job { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Gender Gender { get; set; }
}