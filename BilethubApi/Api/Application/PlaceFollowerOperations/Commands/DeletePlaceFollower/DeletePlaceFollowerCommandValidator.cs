using FluentValidation;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Commands.DeletePlaceFollower;

public class DeletePlaceFollowerCommandValidator : AbstractValidator<DeletePlaceFollowerCommand>
{
    public DeletePlaceFollowerCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}