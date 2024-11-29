using FluentValidation;

namespace BilethubApi.Api.Application.PlaceGenreOperations.Commands.CreatePlaceGenre;

public class CreatePlaceGenreCommandValidator : AbstractValidator<CreatePlaceGenreCommand>{

    public CreatePlaceGenreCommandValidator(){
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
    }
}