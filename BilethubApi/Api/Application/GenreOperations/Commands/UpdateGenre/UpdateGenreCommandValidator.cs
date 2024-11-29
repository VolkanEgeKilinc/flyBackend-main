using FluentValidation;

namespace BilethubApi.Api.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
    }
}