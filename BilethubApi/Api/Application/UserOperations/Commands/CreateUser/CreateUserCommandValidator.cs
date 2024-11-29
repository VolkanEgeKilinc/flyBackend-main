using BilethubApi.Api.Enum;
using FluentValidation;

namespace BilethubApi.Api.Application.UserOperations.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Model.Email).MinimumLength(6);
        RuleFor(command => command.Model.Password).MinimumLength(6);
        RuleFor(command => command.Model.Name).MinimumLength(3);
        RuleFor(command => command.Model.Surname).MinimumLength(3);
        RuleFor(command => command.Model.Bio).MinimumLength(0);
        RuleFor(command => command.Model.Job).MinimumLength(0);
        RuleFor(command => command.Model.Phone).MinimumLength(10).MaximumLength(10);
        RuleFor(command => command.Model.Gender).NotEqual(Gender.None);
    }
}