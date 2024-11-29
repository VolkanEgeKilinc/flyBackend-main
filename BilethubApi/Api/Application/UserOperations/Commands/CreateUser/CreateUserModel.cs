using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.UserOperations.Commands.CreateUser;

public class CreateUserModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Job { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public Gender Gender { get; set; }
}