using FluentValidation;

namespace BilethubApi.Api.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}