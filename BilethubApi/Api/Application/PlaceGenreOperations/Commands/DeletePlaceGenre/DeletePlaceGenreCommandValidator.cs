using FluentValidation;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.DeletePlaceGenre;

public class DeletePlaceGenreCommandValidator : AbstractValidator<DeletePlaceGenreCommand>
{
    public DeletePlaceGenreCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}