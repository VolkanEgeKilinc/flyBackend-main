using FluentValidation;

namespace BilethubApi.Api.Application.OrganizerOperations.Commands.CreateOrganizer;

public class CreateOrganizerCommandValidator : AbstractValidator<CreateOrganizerCommand>
{

    public CreateOrganizerCommandValidator()
    {
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}