using FluentValidation;

namespace BilethubApi.Api.Application.OrganizerOperations.Commands.DeleteOrganizer;

public class DeleteOrganizerCommandValidator : AbstractValidator<DeleteOrganizerCommand>
{
    public DeleteOrganizerCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}