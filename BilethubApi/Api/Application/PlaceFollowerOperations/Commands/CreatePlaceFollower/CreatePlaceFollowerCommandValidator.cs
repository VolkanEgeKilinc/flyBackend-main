using FluentValidation;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Commands.CreatePlaceFollower;

public class CreatePlaceFollowerCommandValidator : AbstractValidator<CreatePlaceFollowerCommand>
{
    public CreatePlaceFollowerCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}