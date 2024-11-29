using FluentValidation;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.DeletePlace;

public class DeletePlaceCommandValidator : AbstractValidator<DeletePlaceCommand>
{
    public DeletePlaceCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}