using FluentValidation;

namespace BilethubApi.Api.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>{

    public CreateGenreCommandValidator(){
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
    }
}