using FluentValidation;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.UpdatePlaceGenre;

public class UpdatePlaceGenreCommandValidator : AbstractValidator<UpdatePlaceGenreCommand>
{
    public UpdatePlaceGenreCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
    }
}